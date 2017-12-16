using System;
using Xunit;

namespace TwoDave.Lister.Test
{
    public class FileLibFixture
    {
        //[Fact]
        //public void Test1()
        //{
        //  var x = 0;
        //Assert.Equal(0, x);
        //}

        [Fact]
        public void Test3()
        {
            var path = @".\data\simple-3-list.txt";
            Node n = FileLib.ReadCommand(path);
            string x = FileLib.GenerateString(n);

            Assert.Equal("a > b > c > d > e > f > g > h", x);
            //Assert.Same()
        }



    }

}
