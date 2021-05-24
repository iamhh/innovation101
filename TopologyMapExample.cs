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
using System.Threading;
using System.Security.Permissions;  //交互JS

namespace innovation101
{

    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]//调用JS代码必要
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]

    class TopologyMapExample : TopologyMap
    {
        private TopologyMapNode[] nodes;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.TextBox use_test;
        private string[] strs;
        private bool com_path_flag = false;
        private bool navi_path_flag = false;
        private int[] isSafety;//1表示安全  -1表示危险
        private System_setting system_Setting = null;

        public TopologyMapExample(System_setting system_Setting)
        {
            this.system_Setting = system_Setting;
            this.system_Setting.button_Switch_Click(null,null);
        }

        public void test(System.Windows.Forms.TextBox use_test)
        {
            this.use_test = use_test;
        }

        public void load_map(System.Windows.Forms.WebBrowser webBrowser)
        {
            if (this.webBrowser == null) this.webBrowser = webBrowser;
            string url = Application.StartupPath + "\\baidumap.html";
            webBrowser.ScriptErrorsSuppressed = true;
            webBrowser.Navigate(url);
            webBrowser.IsWebBrowserContextMenuEnabled = false;
        }
        public void show_node(System.Windows.Forms.WebBrowser webBrowser)
        {
            if (this.nodes == null) setNodes();
            //system_Setting.button_Switch_Click(null, null) ;
            //addTH();
            for (int i = 1; i < nodes.Length; i++)
            {
                this.webBrowser.Document.InvokeScript("addMarker", new object[] { nodes[i].x, nodes[i].y });
            }
        }

        public void fresh_node()
        {
            recieve_unsafety_node();
            this.webBrowser.Document.InvokeScript("freshNodes");
        }

        public void show_path(System.Windows.Forms.WebBrowser webBrowser)
        {
            int end_node = 0;
            int start_node = int.Parse((this.webBrowser.Document.InvokeScript("getStart")).ToString());
            this.webBrowser.Document.InvokeScript("removePath");
            set_unsafety_node();
            int[] nums = dijkstra(start_node, end_node);
            for (int i = 0; i < nums.Length - 1; i++)
            {
                this.webBrowser.Document.InvokeScript("addPath", new object[] { nums[i],nums[i+1] });
            }
            for(int i = nums.Length - 1; i >0; i--)
            {
                int t = 100;
                double dx = (nodes[nums[i]].x - nodes[nums[i - 1]].x) / t;
                double dy = (nodes[nums[i]].y - nodes[nums[i - 1]].y) / t;
                double x = nodes[nums[i]].x;
                double y = nodes[nums[i]].y;
                for(int j=0;j<t;j++)
                {
                    x = x - dx;
                    y = y - dy;
                    this.webBrowser.Document.InvokeScript("robotMove", new object[] { x ,y });
                    Delay(10);
                }
            }
        }

        private void set_unsafety_node()
        {
            string s = this.webBrowser.Document.InvokeScript("getIsSafety").ToString();
            this.isSafety=new int[26];
            if (s.Length == 0) return;
            this.strs = s.Substring(0,s.Length-1).Split('#');
            foreach(string t in strs)
            {
                int x = int.Parse(t);
                foreach(int a in nodes[x].edges.Keys)
                {
                    nodes[a].edges.Remove(x);
                }
            }
            for(int i=0;i<this.isSafety.Length;i++){
                this.isSafety[i]=1;
            }
            foreach(string t in strs){
                int x=int.Parse(t);
                this.isSafety[x]=-1;
            }
        }

        public void show_navigation_path()
        {
            set_unsafety_node();
            if (navi_path_flag)
            {
                navi_path_flag = false;
                this.webBrowser.Document.InvokeScript("removePath");
                return;
            }
            for (int i = 0; i < nodes.Length; i++)
            {
                if(this.isSafety[i]==-1) continue;
                foreach(int t in nodes[i].edges.Keys)
                {
                    this.webBrowser.Document.InvokeScript("addNavigationPath", new object[] { i, t });
                }
            }
            navi_path_flag = true;
        }

        public void show_com_path()
        {
            if (com_path_flag)
            {
                com_path_flag = false;
                this.webBrowser.Document.InvokeScript("removePath");
                return;
            }
            for(int i = 0; i < nodes.Length; i++)
            {
                for(int j = i + 1; j < nodes.Length; j++)
                {
                    object t = this.webBrowser.Document.InvokeScript("getDistance", new object[] { nodes[i].x, nodes[i].y, nodes[j].x, nodes[j].y });
                    string s = t.ToString();
                    double distance = double.Parse(s);
                    if (distance < 150)
                    {
                        this.webBrowser.Document.InvokeScript("addComPath", new object[] { i, j });
                    }
                }
            }
            com_path_flag = true;
        }

        private void recieve_unsafety_node()
        {
            foreach(string s in strs)
            {
                int x = int.Parse(s);
                foreach(int t in nodes[x].edges.Keys)
                {
                    nodes[t].edges.Add(x, nodes[x].edges[t]);
                }
            }
        }

        private void addTH()
        {
            double[] data = system_Setting.getAllData();
            //double[] data = system_Setting.getAllDataA("12:20:26:21:24:23:26:23:28:22:29:24:27:21:26");
            /*bool[] visited = new bool[8];
            int count = 0;
            while (count < 0)
            {
                for (int i = 4; i < data.Length; i += 4)
                {
                    if (visited[i / 4]) continue;
                    if (data[i] == 0) continue;
                    visited[i] = true;
                    double[] temp = zuobiaozhuanhuan(data[i], data[i + 1]);
                    this.nodes[i].x = temp[0];
                    this.nodes[i].y = temp[1];
                    count++;
                    this.webBrowser.Document.InvokeScript("addTH", new object[] { i / 4, data[i + 2], data[i + 3] });
                }
            }*/
            for(int i = 4; i < data.Length; i += 4)
            {
                this.webBrowser.Document.InvokeScript("addTH", new object[] { i / 4, data[i + 2], data[i + 3] });
            }
        }

        private double[] zuobiaozhuanhuan(double x,double y)
        {
            double[] ans = new double[2];
            string s=this.webBrowser.Document.InvokeScript("zuobiaozhuanhuan", new object[] { x, y }).ToString();
            string[] strs = s.Split(',');
            ans[0]= Double.Parse(strs[0]);
            ans[1] = Double.Parse(strs[1]);
            return ans;
        }

        private void setNodes()
        {
            this.nodes = new TopologyMapNode[26];
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
            nodes[i++] = new TopologyMapNode((double)116.362255, (double)39.965899); //21
            nodes[i++] = new TopologyMapNode((double)116.362174, (double)39.966389); //22
            nodes[i++] = new TopologyMapNode((double)116.365309, (double)39.967419); //23
            nodes[i++] = new TopologyMapNode((double)116.365929, (double)39.967972); //24
            nodes[i++] = new TopologyMapNode((double)116.365318, (double)39.967841); //25

            setEdges(0, 14);  
            setEdges(1, 2);
            setEdges(1, 3);
            setEdges(1, 9);
            setEdges(2, 5);
            setEdges(3, 4);
            setEdges(4, 7);
            setEdges(4, 5);
            setEdges(4, 13);
            setEdges(5, 6);
            setEdges(6, 14);
            setEdges(7, 15);
            setEdges(8, 9);
            setEdges(8, 10);
            setEdges(9, 11);
            setEdges(10, 11);
            setEdges(10, 12);
            setEdges(11, 13);
            setEdges(12, 13); 
            setEdges(13, 20);
            setEdges(14, 15);
            setEdges(15, 16);
            setEdges(15, 20);
            setEdges(16, 17);
            setEdges(18, 24);        
            setEdges(21, 22);
            setEdges(21, 17);
            setEdges(0, 22);
            setEdges(16, 22);
            setEdges(20, 23);
            setEdges(19, 23);
            setEdges(19, 24);
            setEdges(24, 25);
            setEdges(23, 25);
            setEdges(20, 25);

        }

        private void setEdges(int index1, int index2)
        {
            object t = this.webBrowser.Document.InvokeScript("getDistance", new object[] { nodes[index1].x,nodes[index1].y,nodes[index2].x,nodes[index2].y });
            string s = t.ToString();
            double distance = double.Parse(s);
            nodes[index1].edges.Add(index2, distance);
            nodes[index2].edges.Add(index1, distance);
        }

        private int[] dijkstra(int startNode, int endNode)
        {
            int size = nodes.Length;
            double[] distances = new double[size];
            int[] pres = new int[size];
            bool[] access = new bool[size];
            for (int i = 0; i < size; i++)
            {
                distances[i] = Double.MaxValue;
            }
            access[startNode] = true;
            pres[startNode] = startNode;
            foreach (int t in nodes[startNode].edges.Keys)
            {
                pres[t] = startNode;
                distances[t] = nodes[startNode].edges[t];
            }
            for (int i = 0; i < size; i++)
            {
                double minDistance = Double.MaxValue;
                int minNode = -1;
                for (int j = 0; j < size; j++)
                {
                    if (!access[j] && distances[j] < minDistance)
                    {
                        minDistance = distances[j];
                        minNode = j;
                    }
                }
                if (minNode == -1) break;
                access[minNode] = true;
                foreach (int t in nodes[minNode].edges.Keys)
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
            for (int i = 0; i < res.Length; i++)
            {
                res[i] = temp[i];
            }
            return res;
        }

        private void Delay(int mm)
        {
            DateTime current = DateTime.Now;
            while (current.AddMilliseconds(mm) > DateTime.Now)
            {
                Application.DoEvents();
            }
            return;
        }

    }
}