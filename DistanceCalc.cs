using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Coursework
{
    class DistanceCalc
    {
        private List<Node> nodes;
        public DistanceCalc(List<Node> nodes)
        {
            this.nodes = nodes;
        }

        public List<Node> calcDistance()
        {
            foreach(Node node in nodes)
            {
                foreach(Node noode in node.connectedNodes)
                {                    
                    double weight = Math.Sqrt(((noode.x - node.x) * (noode.x - node.x))+((noode.y - node.y)*(noode.y - node.y)));
                    noode.distance = (int)Math.Round(weight);
                }
            }

            return nodes;
        }
    }
}
