using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace innovation101
{
    class AStar
    {
        private int[,] datas;
        public AStar(int[,] datas)
        {
            this.datas = datas;
        }
        public AStar() { }

        public LinkedList<int[]> getAns()
        {
            int[] start = getStart();
            int[] end = getEnd();
            HashSet<string> openSet = new HashSet<string>();
            HashSet<string> closeSet = new HashSet<string>();
            HashSet<AStarNode> queue = new HashSet<AStarNode>();
            string[,] parent = new string[34, 50];
            queue.Add(new AStarNode(start[0], start[1], getDistance(start, end)));
            openSet.Add(start[0] + "#" + start[1]);
            int[] dx = new int[] { -1, 0, 1, 0 };
            int[] dy = new int[] { 0, -1, 0, 1 };
            while (queue.Count > 0)
            {
                AStarNode node = getPri(queue);
                string s = node.x + "#" + node.y;
                openSet.Remove(s);
                closeSet.Add(s);
                if (node.x == end[0] && node.y == end[1]) break;
                for(int i=0;i<4; i++)
                {
                    int nx = node.x + dx[i];
                    int ny = node.y + dy[i];
                    if (nx >= 0 && nx < 34 && ny >= 0 && ny < 50)
                    {
                        s = nx + "#" + ny;
                        if (openSet.Contains(s)) continue;
                        if (closeSet.Contains(s)) continue;
                        if (datas[nx, ny] == 0) continue;
                        queue.Add(new AStarNode(nx, ny, getDistance(start, new int[] { nx, ny }) + getDistance(end, new int[] { nx, ny })));
                        openSet.Add(s);
                        parent[nx, ny] = node.x + "#" + node.y;
                    }
                }
            }
            LinkedList<int[]> list = new LinkedList<int[]>();
            int x = end[0];
            int y = end[1];
            while (true)
            {
                if (parent[x,y] == null) break;
                list.AddLast(new int[] { x, y });
                string s = parent[x,y];
                string[] a = s.Split('#');
                x = int.Parse(a[0]);
                y = int.Parse(a[1]);
            }
            return list;
        }
        private int[] getStart()
        {
            return new int[] { 33, 45 };
        }
        private int[] getEnd()
        {
            return new int[] { 4, 21 };
        }
        private int getDistance(int[] a,int[] b)
        {
            return Math.Abs(a[0]-b[0])+ Math.Abs(a[1] - b[1])*Math.Abs(a[1]-b[1]);
        }
        private AStarNode getPri(HashSet<AStarNode> queue)
        {
            AStarNode ans = null;
            foreach(AStarNode node in queue)
            {
                if (ans == null)
                {
                    ans = node;
                }
                else
                {
                    if (ans.distance > node.distance)
                    {
                        ans = node;
                    }
                }
            }
            queue.Remove(ans);
            return ans;
        }
    }
}
