using System;
using System.IO;
using System.Text;

namespace lister
{
    class Program
    {
        static void Main(string[] args)
        {
            // This file is included as Content in the project file so it is copied to the output path
            // as part of the build.
            var path = @".\data\simple-3-list.txt";

            Console.WriteLine("Import data from the simple-3-list.txt file in the data directory");

            try
            {
                using (FileStream myFile = File.OpenRead(path))
                {
                    byte[] b = new byte[1024];
                    int read;

                    while ((read = myFile.Read(b, 0, b.Length)) > 0)
                    {
                        Console.WriteLine(Encoding.UTF8.GetString(b, 0, read));
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Could not find: {0}", e.FileName);
            }
            catch (Exception ex)
            {
                 Console.WriteLine(ex);
            }
        }
    }
}
