using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lc.Test
{
    [TestClass]
    public class Lc21Tests
    {
        [TestMethod]
        public void TwoAndOneTest()
        {
            var result = new Lc21().MergeTwoLists(new ListNode(2), new ListNode(1));
            Assert.AreEqual(1, result.val);
            Assert.AreEqual(2, result.next.val);
        }
    }
}
