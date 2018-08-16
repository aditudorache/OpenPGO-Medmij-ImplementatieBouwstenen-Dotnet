using System;
using Xunit;

namespace MedMij.Xunit
{
    public class UnitTest1
    { 
        [Fact]
        public void Test1()
        {
            Assert.Equal(4, 2 + 2);
        }

        [Fact]
        public void Test2()
        {
            Assert.Equal(5, Class1.return5());
        }
    }
}
