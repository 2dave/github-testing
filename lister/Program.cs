﻿using System;
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

            try
            {
                using (FileStream myFile = File.OpenRead(path))
                {
                    // Changing this array to use the length of the file (as opposed to staright 1024) seems to have fixed
                    // of reading too much of the file on a 64-bit machine and displaying a bunch of '?'s in the 
                    // output. Let me know if this was a good solution. I want to make sure I'm not missing something.
                    byte[] b = new byte[myFile.Length];
                    while (myFile.Read(b,0,b.Length) > 0)
                    {
                        Console.WriteLine(Encoding.UTF8.GetString(b));
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("FILE NOT FOUND IN .\\data");
            }
            catch (Exception ex)
            {
                 Console.WriteLine(ex);
            }  
        }
    }

    // I changed the style of the comments. Do you usually just leave some comments of the the 
    // commit you worked on? For example, the only comments in this code at this very moment are
    // ones related to this commit I'm pushing now.
    // Also at this point, I may have resolved all outstanding issues. If that is so, can we do
    // code review so that I can merge this branch with the master?
}
