using System;
using System.IO;
using System.Collections.Generic;
using CustomClasses;

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
                FileLib test = new FileLib();   
                //FileLib answer = new FileLib.ReadFile(path);

                List<string> contents = ReadFile(path);
                
                DisplayContents(contents);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Could not find: {0}", e.FileName);
            }
        }

        private static List<string> ReadFile(string path)
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
       
        private static void DisplayContents(List<string> contents)
        {
            foreach (var line in contents)
            {
                Console.WriteLine(line);
            }
        }
    }
}
