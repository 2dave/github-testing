using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace lister
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @".\data\simple-3-list.txt";

            Console.WriteLine("Importing data from the simple-3-list.txt file in the data directory.");

            try
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

                string[] result = list.ToArray();

                foreach (var item in result)
                {
                    Console.WriteLine(item.ToString());
                }
            }

            catch (FileNotFoundException e)
            {
                Console.WriteLine("Could not find: {0}", e.FileName);
            }
        }

        private static

    }
}
