using System.IO;
using System.Collections.Generic;

namespace TwoDave.Lister
{
    internal class FileLib
    {
        public MyLinkedList ReadFile(string path)
        {
            MyLinkedList templist = new MyLinkedList();

            using (StreamReader file = new StreamReader(path))
            {
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    var temp = line.Split(' ');
                    templist.AddToEnd(temp[0]);
                    templist.AddToEnd(temp[2]);
                }
            }
            return templist;
        }
    }
}