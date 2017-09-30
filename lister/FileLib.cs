using System.IO;
using System.Collections.Generic;

namespace TwoDave.Lister
{
    internal class FileLib
    {

#if add_to_onenote
        // Add to OneNote
        private FileLib()
        {
            // default constructor
        }

        public static FileLib Create()
        {
            var t = new FileLib();
            return t;
        }
#endif

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