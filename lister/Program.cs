using System;
using System.IO;
using System.Collections.Generic;

namespace TwoDave.Lister
{
    class Program
    {
        static int Main(string[] args)
        {
            var path = @".\data\simple-3-list.txt";

            Console.WriteLine("Data file: {0}", path);

            try
            {
                Node n = FileLib.ReadCommand(path);
                //FileLib.DisplayData(n);
                string result = FileLib.GenerateString(n);
                Console.WriteLine(result);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Could not find: {0}", e.FileName);
                return 1;
            }
            return 0;
        }
    }
}
