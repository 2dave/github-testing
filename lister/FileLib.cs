using System.IO;
using System.Collections.Generic;

namespace TwoDave.Lister
{
    internal class FileLib
    {
        public NodeCollection ReadFile(string path)
        {
            NodeCollection templist = new NodeCollection();            

            using (StreamReader file = new StreamReader(path))
            {
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    var temp = line.Split(' ');
                    //templist.Add(temp[0]);
                    //templist.Add(temp[1]);
                    //templist.Add(temp[2]);
                }
            }
            return templist;
        }
    }
}