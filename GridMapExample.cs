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

    class GridMapExample : GridMap
    {
        private TopologyMapNode[] nodes;
        private System.Windows.Forms.WebBrowser webBrowser;
        private int[,] datas;
        private bool com = false;

        static double longitude_start = 116.361258;
        static double  longitude_end = 116.367995;
        static double latitude_start = 39.963742;
        static double latitude_end = 39.971138;
        static int col_number = 34;
        static int row_number = 50;
        double longitude_between = (longitude_end - longitude_start) / col_number;
        double latitude_between = (latitude_end - latitude_start) / row_number;

        public void load_map(System.Windows.Forms.WebBrowser webBrowser)
        {
            if (this.webBrowser == null) this.webBrowser = webBrowser;
            string url = Application.StartupPath + "\\baidumap_grid.html";
            webBrowser.ScriptErrorsSuppressed = true;
            webBrowser.Navigate(url);
            webBrowser.IsWebBrowserContextMenuEnabled = false;
        }
        public void show_path(System.Windows.Forms.WebBrowser webBrowser)
        {
            AStar star = new AStar(datas);
            LinkedList<int[]> list = star.getAns();
            foreach(int[] a in list)
            {
                double x1 = longitude_start + a[0] * longitude_between;
                double x2 = latitude_start + a[1] * latitude_between;
                double x3 = longitude_start + (a[0] + 1) * longitude_between;
                double x4 = latitude_start + (a[1] + 1) * latitude_between;
                this.webBrowser.Document.InvokeScript("addGridPath", new object[] { x1, x2, x3, x4 });
            }
        }

        public void showComPath()
        {
            if (com)
            {
                this.webBrowser.Document.InvokeScript("removePath");
                com = false;
            }
            else
            {
                for (int i = 0; i < nodes.Length; i++)
                {
                    for (int j = i + 1; j < nodes.Length; j++)
                    {
                        object t = this.webBrowser.Document.InvokeScript("getDistance", new object[] { nodes[i].x, nodes[i].y, nodes[j].x, nodes[j].y });
                        string s = t.ToString();
                        double distance = double.Parse(s);
                        if (distance < 150)
                        {
                            this.webBrowser.Document.InvokeScript("addComPath", new object[] { nodes[i].x, nodes[i].y, nodes[j].x, nodes[j].y });
                        }
                    }
                }
                com = true;
            }
        }

        public void show_node(System.Windows.Forms.WebBrowser webBrowser)
        {
            if (this.nodes == null) setNodes();
            for (int i = 1; i < nodes.Length; i++)
            {
                this.webBrowser.Document.InvokeScript("addMarker", new object[] { nodes[i].x, nodes[i].y });
            }
        }
        public void show_grid(System.Windows.Forms.WebBrowser webBrowser)
        {
            this.webBrowser.Document.InvokeScript("addGridK");
            loadDatas();
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
            
        }

        private void loadDatas()
        {

            this.datas = new int[col_number,row_number];//1代表可达   0代表不可达
            for(int i = 0; i < col_number; i++)
            {
                for(int j = 0; j < row_number; j++)
                {
                    datas[i, j] = 1;
                }
            }

            //设置datas数组状态

            int[] temp = new int[] {5,42,11,45,14,43,16,46,20,39,27,43,8,34,12,40,16,27,22,32,7,25,13,29,15,15,20,22,6,14,10,18,14,6,18,11};

            for(int t = 0; t < temp.Length; t += 4)
            {
                for(int i = temp[t]; i < temp[t + 2]; i++)
                {
                    for(int j = temp[t + 1]; j < temp[t + 3]; j++)
                    {
                        datas[i,j] = 0;
                    }
                }
            }

            for(int i = 0; i < col_number; i++)
            {
                for(int j = 0; j < row_number; j++)
                {
                    double x1 = longitude_start + i * longitude_between;
                    double x2 = latitude_start + j * latitude_between;
                    double x3 = longitude_start + (i + 1) * longitude_between;
                    double x4 = latitude_start + (j + 1) * latitude_between;
                    if (datas[i, j] == 0)
                    {
                        this.webBrowser.Document.InvokeScript("addGrid", new object[] { x1, x2, x3, x4 });
                    }
                    else
                    {
                        this.webBrowser.Document.InvokeScript("addGridAll", new object[] { x1,x2,x3,x4 });
                    }
                }
            }
        }
    }
}