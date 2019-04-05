using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Coursework
{
    class CavParser
    {
        private static String[] parts; // hold the numbers in file in string format
        private int[] values; //array of all numbers in file
        private int[][] matrix; // 2d array to hold matrix 1 and 0
        private int[] x; // array for coordinates on x
        private int[] y; // array for coordinates on y
        private string input;
        public List<Node> nodes { get; set; }

        public CavParser()
        {
            parts = new String[0];
            values = new int[0];
            matrix = new int[0][];
            x = new int[0];
            y = new int[0];
            nodes = new List<Node>();
        }

        public CavParser(string input)
        {
            this.input = input;
            parts = new String[0];
            values = new int[0];
            matrix = new int[0][];
            x = new int[0];
            y = new int[0];
            nodes = new List<Node>();
        }

        public void createNodes()
        {
            parts = new string[0]; // clear parts
            parts = input.Split(','); // splt on comma
            int non = Convert.ToInt32(parts[0]); // take first entry as number of nodes
            int nocoords = non * 2;

            int count = 1;
            for (int i = 1; i < nocoords +1; i+=2)
            {
                Node n = new Node();
                n.id = count;
                n.x = Convert.ToInt32(parts[i]);
                n.y = Convert.ToInt32(parts[i + 1]);
                nodes.Add(n);
                count++;
            }
        }

        public void createNodeConnections()
        {
            parts = new string[0];
            parts = input.Split(',');
            int non = Convert.ToInt32(parts[0]);
            int startPoint = non * 2;
            int c = 1;
            int outerId = 1;
            int innerId = 1;
            for (int i = startPoint + 1; i < parts.Length; i+=non)
            {
                for (int j = 0; j < non; j++)
                {
                    var info = parts[i + j];
                    if(info == "1")
                    {
                        foreach(Node node in nodes)
                        {
                            if(node.id == innerId)
                            {
                                foreach(Node noode in nodes)
                                {
                                    if(noode.id == outerId)
                                    {
                                        node.connectedNodes.Add(noode);
                                    }
                                }
                            }
                        }
                    }
                    innerId++;
                }
                outerId++;
                innerId = 1;
            }
        }          
    }
}
