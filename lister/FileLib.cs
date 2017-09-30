using System.Collections.Generic;
using System.IO;

namespace CustomClasses
{
// Why cannot I not name the class the same as the file name unless in a namespace?
// I am also unsure of the proper use of namespaces
    public class FileLib 
    {
        public FileLib()
        {
            // default constructor
        }

        // non-default constructor
        public List<string> ReadFile(string path)
        {
            var list = new List<string>();

            using (StreamReader file = new StreamReader(path))
            {
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    list.Add(line);
                }
            }
            return list;
        }

        // Need to read more on if this is the correct syntax. Does it even need this?
        ~FileLib()
        {
            // Default destructor
        }
    }
}