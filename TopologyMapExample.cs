using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace innovation101
{
    class TopologyMapExample:TopologyMap
    {
        private TopologyMapNode[] nodes;

        public void load_map(System.Windows.Forms.PictureBox picture)
        {
            picture.Image=Image.FromFile(@"..\..\innovation101map.jpg");
        }
        public void show_node(System.Windows.Forms.PictureBox picture)
        {
            setNodes();
            Image bmp = Image.FromFile(@"..\..\innovation101map.jpg");
            Graphics g = Graphics.FromImage(bmp); //建立Graphics对象
            Pen p = new Pen(Color.Red); //---创建画笔
            for(int i = 0; i < nodes.Length; i++)
            {
                g.DrawEllipse(p, (float)nodes[i].x, (float)nodes[i].y, 3, 3);
            }
            g.Dispose();  //把Graphics释放掉
            picture.Image = bmp;  //绑上刚画好的Bitmap
        }
        public void show_path(System.Windows.Forms.PictureBox picture, int start_node, int end_node)
        {
            
        }

        private void setNodes()
        {
            this.nodes = new TopologyMapNode[32];
            int i = 0;
            nodes[i++] = new TopologyMapNode((double)45, (double)65);
            nodes[i++] = new TopologyMapNode((double)75, (double)100);
            nodes[i++] = new TopologyMapNode((double)125, (double)55);
            nodes[i++] = new TopologyMapNode((double)120, (double)110);
            nodes[i++] = new TopologyMapNode((double)165, (double)75);
            nodes[i++] = new TopologyMapNode((double)195, (double)70);
            nodes[i++] = new TopologyMapNode((double)155, (double)115);
            nodes[i++] = new TopologyMapNode((double)190, (double)110);
            nodes[i++] = new TopologyMapNode((double)215, (double)90);
            nodes[i++] = new TopologyMapNode((double)260, (double)100);
            nodes[i++] = new TopologyMapNode((double)60, (double)130);
            nodes[i++] = new TopologyMapNode((double)45, (double)170);
            nodes[i++] = new TopologyMapNode((double)50, (double)210);
            nodes[i++] = new TopologyMapNode((double)80, (double)155);
            nodes[i++] = new TopologyMapNode((double)105, (double)140);
            nodes[i++] = new TopologyMapNode((double)130, (double)160);
            nodes[i++] = new TopologyMapNode((double)195, (double)180);
            nodes[i++] = new TopologyMapNode((double)220, (double)125);
            nodes[i++] = new TopologyMapNode((double)255, (double)130);
            nodes[i++] = new TopologyMapNode((double)270, (double)155);
            nodes[i++] = new TopologyMapNode((double)300, (double)190);
            nodes[i++] = new TopologyMapNode((double)280, (double)220);
            nodes[i++] = new TopologyMapNode((double)255, (double)210);
            nodes[i++] = new TopologyMapNode((double)220, (double)200);
            nodes[i++] = new TopologyMapNode((double)50, (double)270);
            nodes[i++] = new TopologyMapNode((double)55, (double)240);
            nodes[i++] = new TopologyMapNode((double)70, (double)225);
            nodes[i++] = new TopologyMapNode((double)100, (double)225);
            nodes[i++] = new TopologyMapNode((double)120, (double)270);
            nodes[i++] = new TopologyMapNode((double)130, (double)240);
            nodes[i++] = new TopologyMapNode((double)160, (double)220);
            nodes[i++] = new TopologyMapNode((double)200, (double)240);
            setEdges(31, 30);
            setEdges(31, 16);
            setEdges(31, 23);
            setEdges(30, 29);
            setEdges(29, 28);
            setEdges(29, 27);
            setEdges(27, 26);
            setEdges(26, 25);
            setEdges(25, 24);
            setEdges(30, 15);
            setEdges(15, 14);
            setEdges(14, 13);
            setEdges(13, 10);
            setEdges(13, 11);
            setEdges(11, 12);
            setEdges(16, 7);
            setEdges(7, 8);
            setEdges(8, 9);
            setEdges(7, 6);
            setEdges(6, 4);
            setEdges(4, 5);
            setEdges(6, 3);
            setEdges(3, 2);
            setEdges(3, 1);
            setEdges(1, 0);
            setEdges(23, 17);
            setEdges(17, 18);
            setEdges(18, 19);
            setEdges(23, 22);
            setEdges(22, 21);
            setEdges(21, 20);
        }

        private void setEdges(int index1,int index2)
        {
            double distance = Math.Sqrt(Math.Pow(nodes[index1].x - nodes[index2].x, 2) + Math.Pow(nodes[index1].y - nodes[index2].y, 2));
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
