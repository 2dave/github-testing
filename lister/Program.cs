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

            // You can create your own instance of UTF8Encoding but .NET Core already
            // has one for you to use in a static property on the Encoding class: Encoding.UTF8
            // I never create an instance of UTF8Encoding, I always use Encoding.UTF8.

            while (myFile.Read(b,0,b.Length) > 0)
            {
                Console.WriteLine(temp.GetString(b));
            }

            // Yes, you need this. Well, technically, your process is going to exit
            // immediately after this line of code and any dangling bits will get cleaned
            // up by the operating system (when your process goes any memory or open file
            // handles or other things like that are associated with your process).
            //
            // Also, if this code was in the middle of a larger program, the garbage
            // collector would eventually get around to cleaning up theFileStream object
            // and that would close the underlying file handle. But again, that is
            // sloppy and you generally want to have exact control when a file is
            // released for others to use.
            //
            // But it is good to be in the habit of always cleaning up after yourself.
            //
            // There is also a problem doing it like this. If there is an exception thrown
            // after line 37 (when the FileStream is opened) but before this line then
            // you won't get a chance to close the file. Fortunately, C# provides a
            // mechanism to ensure the file gets closed: the "using" statement.
            //
            myFile.Close(); //do i need this?

            // For your next commit, how about "fixing" up your code to apply the new
            // information then remove all these comments. Don't worry, you can always
            // go back in git history to look up the comments if you want to see them
            // again.
            //
            // Remember, first step is to create a new branch.
        }
    }
}
