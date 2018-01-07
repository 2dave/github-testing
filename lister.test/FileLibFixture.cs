using System;
using System.IO;
using System.Collections.Generic;
using Xunit;

namespace TwoDave.Lister.Test
{
    public class FileLibFixture
    {
       
        [Fact]
        public void CanHandleBadPath()
        {
            //var path = @".\data\DOESNOTEXIST.txt";
            Action lambda = () =>
            {
                var path = @".\data\DOESNOTEXIST.txt";
                Node n = FileLib.ReadCommand(path);
            };

            Assert.Throws<FileNotFoundException>(lambda);
        }

        [Fact]
        public void CanHandleBadPathNoLamda()
        {
            Action ptr = Foo;
            //ptr();
            Assert.Throws<FileNotFoundException>(ptr);
        }

        private void Foo()
        {
            var path = @".\data\DOESNOTEXIST.txt";
            Node n = FileLib.ReadCommand(path);
        }

        [Fact]
        public void CanFindCorrectHeadNode()
        {
            var path = @".\data\simple-3-list.txt";
            Node HeadNodeTest = FileLib.ReadCommand(path);

            #region TestAnswer Object Initialization
            //REVERSE ORDER
            //Node a = new Node { data = "a", next = b }; //nope - b does not exist yet
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

            //var data2 = new[] { "a", "b", "c", "d", "e", "f", "g", "h" };
            //Node a = GenerateNodes(data2);

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

        [Fact]
        public void CanGenerateNodes()
        {
            string[] data = new string[3];
            data[0] = "a";
            data[1] = "b";
            data[2] = "c";

            //string[] data3 = {"a", "b", "c"};
            var data2 = new[] { "a", "b", "c" };

            Node generated = GenerateNodes(data2);

        }


        //TODO
        private Node GenerateNodes(string[] input)
        {
            Node head = null;
            Node past = null;

            foreach (string n in input)
            {
                Node current = new Node();
                current.data = n;

                if (head == null)
                {
                    head = current;
                }

            }

            return head;
        }

    }
}
