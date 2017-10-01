using System.IO;
using System.Collections.Generic;

namespace TwoDave.Lister
{
    internal class FileLib 
    {
        public List<string> ReadFile(string path)
        {
            var list = new List<string>();

            using (StreamReader file = new StreamReader(path))
            {
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    var temp = line.Split(' ');
                    list.Add(line);
                }
            }
            return list;
        }
    }
}