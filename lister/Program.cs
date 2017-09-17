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

            // Well it took a bit but now I can seem to work in the environment now. I would
            // like a review somtime on how you work on multiple machines sometimes (with the same code)
            // and what that workflow looks like. 
            // Also some questions on working with Visual Studio Code. On a desktop I have
            // I cannot use debugging and it took me a long time to figure out how to go to 
            // TERMINAL and run 'dotnet run' (after building) to get the code to execute. 
            //
            // I created my own branch to work on and pushed it to Github. I'm not sure what the
            // workflow looks like to merge it back with master or when I should. Should I just 
            // keep cloning that branch and pushing it back as I work?
            //
            // Let me know what's next. Finally feels good getting past some of the administrative 
            // stuff and now I can actually code something! Getting VS Code to work on another 
            // machine was a bear - but I am getting a handle on it now. 
            }
         }
    }
}
