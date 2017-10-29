using System;
using System.IO;
using System.Collections.Generic;

namespace TwoDave.Lister
{
    internal class FileLib
    {
        public static string ReadCommandFile(string path)
        {
            using (StreamReader file = new StreamReader(path))
            {
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    var temp = line.Split(' ');

                    List<Node> newnodes = new List<Node>();
                    Node tempnode1 = new Node();
                    Node tempnode2 = new Node();

                    tempnode1.data = temp[0];
                    tempnode2.data = temp[2];

                    newnodes.Add(tempnode1);
                    newnodes.Add(tempnode2);

                    foreach (Node n in newnodes)
                    {
                        Console.WriteLine("The list of nodes --> {0}", n.data.ToString());
                    }
                }
            }

            return "not used";            
        }
    }
}