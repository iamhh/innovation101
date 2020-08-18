using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Net;
using System.IO;
using System.Security.Permissions;  //交互JS

namespace innovation101
{

    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]//调用JS代码必要
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]

    class TopologyMapExample:TopologyMap
    {
        private TopologyMapNode[] nodes;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.TextBox use_test;


        public void test(System.Windows.Forms.TextBox use_test)
        {
            this.use_test = use_test;
        }

        public void load_map(System.Windows.Forms.WebBrowser webBrowser)
        {
            if(this.webBrowser==null) this.webBrowser = webBrowser;
            string url = Application.StartupPath + "\\baidumap.html";
            webBrowser.ScriptErrorsSuppressed = true;
            webBrowser.Navigate(url);
        }
        public void show_node(System.Windows.Forms.WebBrowser webBrowser)
        {
            if(this.nodes==null) setNodes();
            for(int i = 1; i < nodes.Length; i++)
            {
                this.webBrowser.Document.InvokeScript("addMarker", new object[] { nodes[i].x, nodes[i].y });
            }
        }
        public void show_path(System.Windows.Forms.WebBrowser webBrowser, int start_node, int end_node)
        {
            this.webBrowser.Document.InvokeScript("removePath");
            int[] nums = dijkstra(start_node, end_node);
            string s = "";
            for(int i = 0; i < nums.Length - 1; i++)
            {
                this.webBrowser.Document.InvokeScript("addPath", new object[] { nodes[nums[i]].x, nodes[nums[i]].y, nodes[nums[i+1]].x, nodes[nums[i+1]].y });
                s = s + " " + nums[i];
            }
            this.use_test.Text = s;
        }

        private void setNodes()
        {
            this.nodes = new TopologyMapNode[21];
            int i = 0;
            nodes[i++] = new TopologyMapNode((double)116.362118, (double)39.966811);
            nodes[i++] = new TopologyMapNode((double)116.363688, (double)39.970119);
            nodes[i++] = new TopologyMapNode((double)116.362763, (double)39.969897);
            nodes[i++] = new TopologyMapNode((double)116.363708, (double)39.969545);
            nodes[i++] = new TopologyMapNode((double)116.363762, (double)39.969006);
            nodes[i++] = new TopologyMapNode((double)116.362846, (double)39.968957);
            nodes[i++] = new TopologyMapNode((double)116.362028, (double)39.968943);
            nodes[i++] = new TopologyMapNode((double)116.363796, (double)39.968463);
            nodes[i++] = new TopologyMapNode((double)116.366904, (double)39.970357);
            nodes[i++] = new TopologyMapNode((double)116.365253, (double)39.970284);
            nodes[i++] = new TopologyMapNode((double)116.366942, (double)39.969531);
            nodes[i++] = new TopologyMapNode((double)116.36528, (double)39.969469);
            nodes[i++] = new TopologyMapNode((double)116.366906, (double)39.968854);
            nodes[i++] = new TopologyMapNode((double)116.365316, (double)39.968812);
            nodes[i++] = new TopologyMapNode((double)116.362046, (double)39.967997);
            nodes[i++] = new TopologyMapNode((double)116.363825, (double)39.968052);
            nodes[i++] = new TopologyMapNode((double)116.363852, (double)39.966493);
            nodes[i++] = new TopologyMapNode((double)116.363888, (double)39.965871);
            nodes[i++] = new TopologyMapNode((double)116.365954, (double)39.966023);
            nodes[i++] = new TopologyMapNode((double)116.365936, (double)39.967419);
            nodes[i++] = new TopologyMapNode((double)116.3653, (double)39.968156);
            setEdges(0, 16);
            setEdges(0, 14);
            setEdges(16, 17);
            setEdges(14, 6);
            setEdges(14, 15);
            setEdges(17, 18);
            setEdges(18, 19);
            setEdges(6, 5);
            setEdges(5, 2);
            setEdges(15, 7);
            setEdges(7, 4);
            setEdges(4, 3);
            setEdges(3, 1);
            setEdges(15, 20);
            setEdges(20, 13);
            setEdges(13, 11);
            setEdges(13, 12);
            setEdges(11, 9);
            setEdges(9, 8);
            setEdges(12, 10);
        }

        private void setEdges(int index1,int index2)
        {
            object t= this.webBrowser.Document.InvokeScript("getDistance", new object[] { nodes[index1].x, nodes[index1].y, nodes[index2].x, nodes[index2].y });
            string s = t.ToString();
            this.use_test.Text = s;
            double distance = double.Parse(s);
            nodes[index1].edges.Add(index2, distance);
            nodes[index2].edges.Add(index1, distance);
        }

        private int[] dijkstra(int startNode,int endNode)
        {
            int size = nodes.Length;
            double[] distances = new double[size];
            int[] pres = new int[size];
            bool[] access = new bool[size];
            for(int i = 0; i < size; i++)
            {
                distances[i] = Double.MaxValue;
            }
            access[startNode] = true;
            pres[startNode] = startNode;
            foreach(int t in nodes[startNode].edges.Keys)
            {
                pres[t] = startNode;
                distances[t] = nodes[startNode].edges[t];
            }
            for(int i = 0; i < size; i++)
            {
                double minDistance = Double.MaxValue;
                int minNode = -1;
                for(int j = 0; j < size; j++)
                {
                    if (!access[j] && distances[j] < minDistance)
                    {
                        minDistance = distances[j];
                        minNode = j;
                    }
                }
                if (minNode == -1) break;
                access[minNode] = true;
                foreach(int t in nodes[minNode].edges.Keys)
                {
                    if (access[t]) continue;
                    double weight = nodes[minNode].edges[t];
                    if (weight + minDistance < distances[t])
                    {
                        distances[t] = weight + minDistance;
                        pres[t] = minNode;
                    }
                }
            }
            List<int> temp = new List<int>();
            int index = endNode;
            while (pres[index] != index)
            {
                temp.Add(index);
                index = pres[index];
            }
            temp.Add(index);
            int[] res = new int[temp.Count];
            for(int i = 0; i < res.Length; i++)
            {
                res[i] = temp[i];
            }
            return res;
        }
    }
}
