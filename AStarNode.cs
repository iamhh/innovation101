using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace innovation101
{
    class AStarNode
    {
        public int x;
        public int y;
        public int distance;

        public AStarNode(int x,int y,int distance)
        {
            this.x = x;
            this.y = y;
            this.distance=distance;
        }
        public AStarNode()
        {

        }
    }
}
