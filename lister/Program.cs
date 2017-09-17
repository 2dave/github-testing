using System;
using System.IO;
using System.Text; 

namespace lister
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\gitstuff\lister\data\simple-3-list.txt"; 

            Console.WriteLine("Import data from the simple-3-list.txt file in the data directory");

            if (!File.Exists(path))
            {
                Console.WriteLine("simple-3-list.txt does not exist in C:\\gitstuff\\lister\\data");
            }

            FileStream myFile = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None);

            byte[] b = new byte[1024]; 
            UTF8Encoding temp = new UTF8Encoding(true); 

            while (myFile.Read(b,0,b.Length) > 0)
            {
                Console.WriteLine(temp.GetString(b));
            }

            myFile.Close(); //do i need this?

         }
    }
}
