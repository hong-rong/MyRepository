using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lc.Test
{
    [TestClass]
    public class Lc8Tests
    {
        //int.MaxValue: 2,147,483,647 (0x7FFFFFFF)
        //int.MinValue: -2,147,483,648 (0x80000000)
        [TestMethod]
        public void MyAtoi_OverflowMax_Test()
        {
            var result = new Lc8().MyAtoi("2147483648");

            Assert.AreEqual(int.MaxValue, result);
        }

        [TestMethod]
        public void MyAtoi_OverflowMin_Test()
        {
            var result = new Lc8().MyAtoi("-2147483649");

            Assert.AreEqual(int.MinValue, result);
        }

        [TestMethod]
        public void MyAtoi_NearOverflowMax_Test()
        {
            var result = new Lc8().MyAtoi("2147483647");//0x7FFFFFFF

            Assert.AreEqual(2147483647, result);
        }

        [TestMethod]
        public void MyAtoi_NearOverflowMin_Test()
        {
            var result = new Lc8().MyAtoi("-2147483648");//0x80000000

            Assert.AreEqual(int.MinValue, result);
        }

        [TestMethod]
        public void MyAtoi_NearOverflowMin2_Test()
        {
            var result = new Lc8().MyAtoi("-2147483647");

            Assert.AreEqual(-2147483647, result);
        }

        [TestMethod]
        public void MyAtoi_TwoSigns_Test()
        {
            var result = new Lc8().MyAtoi("+-2");

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void MyAtoi_One_Test()
        {
            var result = new Lc8().MyAtoi("1");

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void MyAtoi_LeadingEmptyAndZeros_Test()
        {
            var result = new Lc8().MyAtoi("  -0012a42");

            Assert.AreEqual(-12, result);
        }
    }
}