using System;
using Xunit;

namespace UnitaireTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            int a = 50;
            int b = 10;

            Assert.Equal(60, a + b);
        }
    }
}
