using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lc.Test
{
    [TestClass]
    public class Lc9Tests
    {
        [TestMethod]
        public void IsPalindomeTest()
        {
            //2147483648
            //10000000000
            bool actual = new Lc9().IsPalindrome(1410110141);

            Assert.IsTrue(actual);
        }
    }
}