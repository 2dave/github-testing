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

            // Using two different ways to get the output of a file on the console screen. 
            try
            {
                using (FileStream myFile = File.OpenRead(path))
                {
                    Console.WriteLine("Using Read on a file stream to populate a byte array. Then displaying the byte array.");
                    byte[] b = new byte[1024];
                    int read;

                    while ((read = myFile.Read(b, 0, b.Length)) > 0)
                    {
                        Console.WriteLine(Encoding.UTF8.GetString(b, 0, read));
                    }
                }

                using (StreamReader file = new StreamReader(path))
                {
                    Console.WriteLine("Using StreamReader to populate a new string array and then displaying that array.");
                    string line;

                    // Taken from a stackoverflow example. I have not used this generic collection before but 'List' 
                    // seemed simple enough to use and manipulate.
                    var list = new List<string>();

                    while((line = file.ReadLine()) != null)
                        {
                            //Console.WriteLine (line);
                            list.Add(line);
                        } 
                    string[] result = list.ToArray();

                    // Using 'foreach' is new to me. I could not translate it into an equivalent 'for' loop. I would like to know how
                    // to convert it into a regular 'for' loop so that I understand the syntax of 'foreach' better.
                    foreach (var item in result)
                    {
                        Console.WriteLine(item.ToString());
                    }
                }
            }
            
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Could not find: {0}", e.FileName);
            }
        }
    }
}
