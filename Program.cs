using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Coursework
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = Directory.GetCurrentDirectory();
            string arg = args[0] + ".cav";

            StreamReader sr = new StreamReader(path + "\\" + arg);

            string file = sr.ReadLine();

            CavParser cp = new CavParser(file);
            cp.createNodes();
            cp.createNodeConnections();
            DistanceCalc dc = new DistanceCalc(cp.nodes);
            cp.nodes = dc.calcDistance();

            PathFinder pf = new PathFinder(cp.nodes);
            List<Node> myPath = pf.calcPath();

            WriteToFile wtf = new WriteToFile();

            if (myPath != null)
            {
                wtf.writeFile(myPath, arg);
            }
            else
            {
                wtf.writeNull(arg);
            }

        }
    }
}
