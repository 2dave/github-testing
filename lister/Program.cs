using System;
using System.IO;
using System.Collections.Generic;

namespace TwoDave.Lister
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
                //var test = FileLib.Create(); // different way to instantiate (if I define Create())                       

                List<string> contents = test.ReadFile(path);
                
                DisplayContents(contents);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Could not find: {0}", e.FileName);
            }
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
