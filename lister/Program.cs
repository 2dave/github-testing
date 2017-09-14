//Using the File.Open msdn page to understand how c# deals with files. It appears similar to c++

using System;
using System.IO;
using System.Text; //needed for the UTF encoding line

namespace lister
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\gitstuff\lister\data\simple-3-list.txt"; //no escape char because of @...why?

            Console.WriteLine("Import data from the simple-3-list.txt file in the data directory"); 

            if (!File.Exists(path))
            {
                Console.WriteLine("simple-3-list.txt does not exist in C:\\gitstuff\\lister\\data"); 
            }

            FileStream myFile = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None);

            byte[] b = new byte[1024]; //syntax like a dynamic array in c++ but why pass the size? find out
            UTF8Encoding temp = new UTF8Encoding(true); //I need a review of this line and the one above

            while (myFile.Read(b,0,b.Length) > 0)
            {
                Console.WriteLine(temp.GetString(b));
            }
        
            myFile.Close(); //do i need this?
        }
    }
}
