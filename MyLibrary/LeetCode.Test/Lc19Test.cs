using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lc.Test
{
    [TestClass]
    public class Lc19Test
    {
        [TestMethod]
        public void Test()
        {
            var result = new Lc19().RemoveNthFromEnd(new ListNode(1), 1);
            Assert.IsNull(result);
        }
    }
}
