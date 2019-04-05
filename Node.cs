using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Coursework
{
    class Node
    {
        public int id { get; set; }

        public int x { get; set; }
        public int y { get; set; }
        
        public int g { get; set; }
        public int h { get; set; }
        public int f { get; set; }

        public int distance { get; set; }

        public List<Node> connectedNodes { get; set; }

        public Node()
        {
            id = 0;
            x = 0;
            y = 0;

            g = 0;
            h = 0;
            f = 0;

            distance = 0;

            connectedNodes = new List<Node>();
        }  
    }
}
