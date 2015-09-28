using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lc.Test
{
    [TestClass]
    public class Lc4Tests
    {
        [TestMethod]
        public void FindMedianSortedArrays_Small_Test()
        {
            var a = new int[] { 1, 3, 5, 7 };
            var b = new int[] { 2, 4, 6 };

            var result = new Lc4().FindMedianSortedArrays(a, b);

            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void FindMedianSortedArrays_WithOneElement_Test()
        {
            var a = new int[] { 1, 3, 5, 7 };
            var b = new int[] { 2 };

            var result = new Lc4().FindMedianSortedArrays(a, b);

            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void FindMedianSortedArrays_WithBothOneElement_Test()
        {
            var a = new int[] { 1 };
            var b = new int[] { 2 };

            var result = new Lc4().FindMedianSortedArrays(a, b);

            Assert.AreEqual(1.5, result);
        }

        [TestMethod]
        public void FindMedianSortedArrays_Test()
        {
            var a = new int[] { 10, 12, 30, 32, 66 };
            var b = new int[] { 12, 21, 25, 36, 40, 49, 50, 91 };

            var result = new Lc4().FindMedianSortedArrays(a, b);

            Assert.AreEqual(32, result);
        }

        [TestMethod]
        public void FindKth_Test()
        {
            const int expected = 4;
            var a = new int[] { 1, 3, 5, 7 };
            var b = new int[] { 2, 4, 6 };

            //1 2 3 (4) 5 6 7
            var result = new Lc4().FindKth(a, 0, a.Length - 1, b, 0, b.Length - 1, expected);

            Assert.AreEqual(expected, result);
        }
    }
}