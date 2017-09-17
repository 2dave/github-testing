using System;
using System.IO;
using System.Text; 

namespace lister
{
    class Program
    {
        static void Main(string[] args)
        {
            //I couldn't get the syntax ".\data\simple-3-list.txt" syntax to work. 
            //is there a better way to do this line?
            var path = @"C:\gittraining\github-testing\lister\data\simple-3-list.txt";

            Console.WriteLine("Import data from the simple-3-list.txt file in the data directory");

            if (!File.Exists(path))
            {
                //Simplifying the path
                Console.WriteLine("simple-3-list.txt does not exist in \\data directory");
            }

            //rewrote to utilize the 'using' statement and removed myFile.Close as this block
            //should automatically.            
            using (FileStream myFile = File.OpenRead(path))
            {
                byte[] b = new byte[1024];

                //No longer creating my own instance but want to make sure syntax below
                //Encoding.UTF8.GetString(b) is correct.
                //Encoding temp = Encoding.UTF8; 
               
                while (myFile.Read(b,0,b.Length) > 0)
                    {
                        Console.WriteLine(Encoding.UTF8.GetString(b));
                    } 
            }
         }
    }
}
