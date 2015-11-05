using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lc.Test
{
    [TestClass]
    public class Lc15Test
    {
        [TestMethod]
        public void SingleTest()
        {
            var list = new Lc15().ThreeSum(new[] { -1, 0, 1 });
            Assert.AreEqual(-1, list[0][0]);
            Assert.AreEqual(0, list[0][1]);
            Assert.AreEqual(1, list[0][2]);
        }

        [TestMethod]
        public void AllZeroTest()
        {
            var list = new Lc15().ThreeSum(new[] { 0, 0, 0, 0 });
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(0, list[0][0]);
            Assert.AreEqual(0, list[0][1]);
            Assert.AreEqual(0, list[0][2]);
        }

        [TestMethod]
        public void FourTest()
        {
            var list = new Lc15().ThreeSum(new[] { 1, -1, -1, 0 });
            Assert.AreEqual(-1, list[0][0]);
            Assert.AreEqual(0, list[0][1]);
            Assert.AreEqual(1, list[0][2]);
        }
    }
}
