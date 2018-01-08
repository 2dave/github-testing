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

            //REVERSE ORDER - can't start with { data = "a", next = b } because b won't exist at that time            
            //Node h = new Node { data = "h", next = null };
            //Node g = new Node { data = "g", next = h };
            //Node f = new Node { data = "f", next = g };
            //Node e = new Node { data = "e", next = f };
            //Node d = new Node { data = "d", next = e };
            //Node c = new Node { data = "c", next = d };
            //Node b = new Node { data = "b", next = c };
            //Node a = new Node { data = "a", next = b };

            var data2 = new[] { "a", "b", "c", "d", "e", "f", "g", "h" };
            Node a = GenerateNodes(data2);

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
            //string[] data = new string[3];
            //data[0] = "a";

            //string[] data3 = {"a", "b", "c"};
            var data2 = new[] { "a", "b", "c", "d", "e", "f", "g", "h" };

            Node generated = GenerateNodes(data2);
        }

        private Node GenerateNodes(string[] input)
        {
            Node head = null;
            Node previous = null;

            foreach (string n in input)
            {
                Node current = new Node();

                current.data = n; // current -> a.data = first string

                if (previous == null)
                {
                    previous = current;
                }

                if (head == null)
                {
                    head = current; // a is now head
                }

                previous.next = current;

                previous = current;
            }

            return head;
        }
    }
}
