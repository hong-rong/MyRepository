using Lib.Common.Al.Dp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Common.Test.Al
{
    [TestClass]
    public class LongestIncreasingSequenceTest
    {
        [TestMethod]
        public void GetLongest_Test()
        {
            LongestIncreasingSequence.GetLongest(new int[] { 5, 2, 8, 6, 3, 6, 9, 7 });
        }
    }
}
