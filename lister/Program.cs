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
                FileLib.ReadCommand(path);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Could not find: {0}", e.FileName);
                return 1;
            }
            return 0;
        }

/*         private static void DisplayList(NodeCollection data)
        {
            //data.PrintList();
            Console.WriteLine("Debugging:");
        } */
    }
}
