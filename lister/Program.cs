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
            // The "@" means the following is a "verbatim" string literal. Normal
            // string literals use the backslash (\) as an escape character. For example,
            // you can include a tab in your string by adding "\t". Or you can include a
            // double quote in your string using "\"".
            //
            // In a normal string literal if you need a backslash, you have to escape it
            // like so: "\\". As you can see that can make file paths in strings really
            // ugly. Thus C# provides the verbatim string literal.
            //
            // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/string
            //
            string path = @"C:\gitstuff\lister\data\simple-3-list.txt"; //no escape char because of @...why?

            // Instead of "string" consider using "var" to define implicitly typed
            // variable. You can use this all over. It can really clean up your code, like so:
            // var path = @"C:\gitstuff\lister\data\simple-3-list.txt";

            Console.WriteLine("Import data from the simple-3-list.txt file in the data directory");

            if (!File.Exists(path))
            {
                Console.WriteLine("simple-3-list.txt does not exist in C:\\gitstuff\\lister\\data");
            }

            FileStream myFile = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None);

            // C# uses the "new" keyword to say "Give me one of these" (aka: give me memory
            // for this thing). So in C/C++ you can say "byte b[1024]" and get a 1K of
            // uninitialized memory on the stack, C# requires you to say "byte[] b = new byte[1024]".
            // C# will give you the memory and initialize it to zero.
            //
            // Remember C# is a garbage collected language. In general, you don't control
            // memory as closely in C/C++. For example, C# may choose to move your memory
            // around as it sees fit. So unlike a C/C++ pointer that always points at the
            // same memory address (until you change it), your variable "b" below may be
            // moved by the C# runtime (aka: .NET Core) at any time... and you won't be
            // able to tell.
            //
            byte[] b = new byte[1024]; //syntax like a dynamic array in c++ but why pass the size? find out

            // UTF-8 is way of encoding characters. UTF-16 (also called Unicode) is
            // another way. You need to know what encoding the bytes are if you want
            // to turn the bytes into strings (and not get gobbledy-gook).
            //
            // VS Code will show you the encoding of a text file down in the status bar.
            // the letters "BOM" stand for "Byte Order Mark" which is a set of bytes at
            // the front of the file that tells you what encoding the file uses. A BOM
            // is optional so you can see files with "UTF-8" or "UTF-8 with BOM".
            //
            UTF8Encoding temp = new UTF8Encoding(true); //I need a review of this line and the one above

            while (myFile.Read(b,0,b.Length) > 0)
            {
                Console.WriteLine(temp.GetString(b));
            }

            myFile.Close(); //do i need this?
        }
    }
}
