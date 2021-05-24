using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace innovation101
{
    class TopologyMapNode : Node
    {
        public double x;
        public double y;
        public Dictionary<int, double> edges;

        public TopologyMapNode(double x, double y, Dictionary<int, double> edges)
        {
            this.x = x;
            this.y = y;
            this.edges = edges;
        }

        public TopologyMapNode(double x, double y)
        {
            this.x = x;
            this.y = y;
            this.edges = new Dictionary<int, double>();
        }
    }
}