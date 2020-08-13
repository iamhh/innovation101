using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace innovation101
{
    class TopologyMapExample:TopologyMap
    {
        private TopologyMapNode[] nodes;

        public void load_map(System.Windows.Forms.PictureBox picture)
        {

        }
        public void show_node(System.Windows.Forms.PictureBox picture)
        {

        }
        public void show_path(System.Windows.Forms.PictureBox picture, int start_node, int end_node)
        {
            
        }

        private void setNodes()
        {
            this.nodes = new TopologyMapNode[7];
            Dictionary<int, double> map = new Dictionary<int, double>();
            map.Add(1, 5.0);
            map.Add(2, 2.0);
            nodes[0] = new TopologyMapNode(0, 0, map);
            map = new Dictionary<int, double>();
            map.Add(0, 5.0);
            map.Add(3, 1.0);
            map.Add(4, 6.0);
            nodes[1] = new TopologyMapNode(0, 0, map);
            map = new Dictionary<int, double>();
            map.Add(0, 2.0);
            map.Add(3, 6.0);
            map.Add(5, 8.0);
            nodes[2] = new TopologyMapNode(0, 0, map);
            map = new Dictionary<int, double>();
            map.Add(1, 1.0);
            map.Add(2, 6.0);
            map.Add(4, 1.0);
            map.Add(5, 2.0);
            nodes[3] = new TopologyMapNode(0, 0, map);
            map = new Dictionary<int, double>();
            map.Add(3, 1.0);
            map.Add(1, 6.0);
            map.Add(6, 7.0);
            nodes[4] = new TopologyMapNode(0, 0, map);
            map = new Dictionary<int, double>();
            map.Add(2, 8.0);
            map.Add(3, 2.0);
            map.Add(6, 3.0);
            nodes[5] = new TopologyMapNode(0, 0, map);
            map = new Dictionary<int, double>();
            map.Add(4, 7.0);
            map.Add(5, 3.0);
            nodes[6] = new TopologyMapNode(0, 0, map);
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
