using System;
using System.IO;
using System.Text; 

namespace lister
{
    class Program
    {
        static void Main(string[] args)
        {
            // I included the suggested 'ItemGroup' inside the .csproj to make the path more manageable
            var path = @".\data\simple-3-list.txt";

            Console.WriteLine("Import data from the simple-3-list.txt file in the data directory");

            if (!File.Exists(path))
            {
                Console.WriteLine("simple-3-list.txt does not exist in \\data directory");
            }
  
            using (FileStream myFile = File.OpenRead(path))
            {
                byte[] b = new byte[1024];
              
                while (myFile.Read(b,0,b.Length) > 0)
                    {
                        Console.WriteLine(Encoding.UTF8.GetString(b));
                    } 

            }
         }
    }
}
