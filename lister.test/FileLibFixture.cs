using System;
using System.IO;
using System.Collections.Generic;
using Xunit;

namespace TwoDave.Lister.Test
{
    public class FileLibFixture
    {
        // Two things:
        // Do I need this because of the try catch block? am I just testing that
        // If I do should this unit test be in another file ProgramFixture.cs maybe?
        [Fact]
        public void CanHandleBadPath()
        {
            try
            {
                var path = @".\data\DOESNOTEXIST.txt";
                //var path = @".\data\simple-3-list.txt";
                Node n = FileLib.ReadCommand(path);                
            }
            catch (FileNotFoundException e)
            {
                
                //string test = "Could not find: {0}", e.FileName;
                //Assert.True(false, test);
                //Assert.Raises(FileNotFoundException);
                // Test passes 
            }


            //Assert.Throws<FileNotFoundException>();
        }

        [Fact]
        public void CanFindCorrectHeadNode()
        {
            var path = @".\data\simple-3-list.txt";
            Node HeadNodeTest = FileLib.ReadCommand(path);

            // Put what the test answer should be here
            // I guess this could use collection initialization if
            // Node implements the IEnumerable 
            #region TestAnswer Object Initialization
            Node a = new Node();
            Node b = new Node();
            Node c = new Node();
            Node d = new Node();
            Node e = new Node();
            Node f = new Node();
            Node g = new Node();
            Node h = new Node();

            a.data = "a";
            a.next = b;
            b.data = "b";
            b.next = c;
            c.data = "c";
            c.next = d;
            d.data = "d";
            d.next = e;
            e.data = "e";
            e.next = f;
            f.data = "f";
            f.next = g;
            g.data = "g";
            g.next = h;
            h.data = "h";
            h.next = null;
            #endregion

            string MyAnswer = FileLib.GenerateString(a);
            string TestAnswer = FileLib.GenerateString(HeadNodeTest);

            Assert.Equal(MyAnswer, TestAnswer);
        }

        [Fact]
        public void CanVerifyOutputCorrectOfManyNodes()
        {
            var path = @".\data\simple-3-list.txt";
            Node n = FileLib.ReadCommand(path);
            string x = FileLib.GenerateString(n);

            Assert.Equal("a > b > c > d > e > f > g > h", x);
        }
    }
}
