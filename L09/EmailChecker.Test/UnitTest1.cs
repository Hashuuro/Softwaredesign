using System;
using Xunit;

namespace EmailChecker.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            string mailaddress = "irgendwas@web.de";
            bool result = Program.IsEmailAddress(mailaddress);
            Assert.True(result, "Expected " + mailaddress + " to be a valid email address.");

        }

        [Fact]
        public void Test2()
        {
            string mailaddress = "@web.de";
            bool result = Program.IsEmailAddress(mailaddress);
            Assert.True(result, "Expected " + mailaddress + " to be a valid email address.");

        }

         [Fact]
        public void Test3()
        {
            string mailaddress = "irgendwas@web.";
            bool result = Program.IsEmailAddress(mailaddress);
            Assert.False(result, "Expected " + mailaddress + " to be a invalid email address.");

        }

         [Fact]
        public void Test4()
        {
            string mailaddress = "a.b@web.de";
            bool result = Program.IsEmailAddress(mailaddress);
            Assert.True(result, "Expected " + mailaddress + " to be a valid email address.");

        }

         [Fact]
        public void Test5()
        {
            string mailaddress = "a@.";
            bool result = Program.IsEmailAddress(mailaddress);
            Assert.False(result, "Expected " + mailaddress + " to be a invalid email address.");

        }
    }
}
