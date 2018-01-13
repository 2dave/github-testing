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

            #region To remove later - a learning thread of thought
            //REVERSE ORDER - can't start with { data = "a", next = b } because b won't exist at that time            
            //Node h = new Node { data = "h", next = null };
            //Node g = new Node { data = "g", next = h };
            //Node f = new Node { data = "f", next = g };
            //Node e = new Node { data = "e", next = f };
            //Node d = new Node { data = "d", next = e };
            //Node c = new Node { data = "c", next = d };
            //Node b = new Node { data = "b", next = c };
            //Node a = new Node { data = "a", next = b };
            #endregion

            var data2 = new[] { "a", "b", "c", "d", "e", "f", "g", "h" };
            Node a = GenerateNodes(data2);

            string MyAnswer = FileLib.GenerateString(a);
            string TestAnswer = FileLib.GenerateString(HeadNodeTest);

            Assert.Equal(MyAnswer, TestAnswer);
        }

        [Fact]
        public void CanFindCorrectHeadNodeParams()
        {
            Node headNodeTest = FileLib.ReadCommand(@".\data\simple-3-list.txt");
            Node input = GenerateNodes("a", "b", "c", "d", "e", "f", "g", "h");

            string TestAnswer = FileLib.GenerateString(headNodeTest);
            string MyAnswer = FileLib.GenerateString(input);

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
        public void CanGenerateEmptyList()
        {
            var data2 = new string[] { };

            Node generated = GenerateNodes(data2);

            Assert.Null(generated);
        }

        [Fact]
        public void CanGenerateSingleNode()
        {
            var data2 = new[] { "a" };

            Node generated = GenerateNodes(data2);

            Assert.Equal("a", generated.data);
            Assert.Null(generated.next);
        }

        [Fact]
        public void CanGenerateTwoNodes()
        {
            var data2 = new[] { "x", "y" };

            Node x = GenerateNodes(data2);
            Assert.Equal("x", x.data);

            var y = x.next;
            Assert.Equal("y", y.data);
            Assert.Null(y.next);
        }

        [Fact]
        public void CanGenerateManyNodesEasily()
        {
            Node x = GenerateNodes("x", "y", "l", "m", "n");

            Assert.Equal("x", x.data);
            Assert.Equal("y", x.next.data);
            Assert.Equal("l", x.next.next.data);
            Assert.Equal("m", x.next.next.next.data);
            Assert.Equal("n", x.next.next.next.next.data);
        }

        private Node GenerateNodes(params string[] input)
        {
            Node head = null;
            Node previous = null;

            foreach (string n in input)
            {
                var current = new Node();

                current.data = n;

                if (head == null)
                {
                    head = current;
                }

                if (previous != null)
                {
                    previous.next = current;
                }

                previous = current;
            }

            return head;
        }
    }
}
