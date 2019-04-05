using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Coursework
{
    class WriteToFile
    {
        public WriteToFile()
        {

        }

        public void writeFile(List<Node> myPath, string name)
        {
            myPath.Reverse();
            using (StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + "\\" + name.Substring(0, (name.Length - 3)) + "csn"))
            {
                if(myPath != null)
                {
                    foreach(Node node in myPath)
                    {
                        sw.Write(node.id + " ");
                    }
                }
            }
        }

        public void writeNull(string name)
        {
            using (StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + "\\" + name.Substring(0, (name.Length - 3)) + "csn"))
            {
                sw.Write("0");
            }
        }
    }
}
