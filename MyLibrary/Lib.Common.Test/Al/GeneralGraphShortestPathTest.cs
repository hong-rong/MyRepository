using Lib.Common.Al.Graph;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Common.Test.Al
{
    [TestClass]
    public class GeneralGraphShortestPathTest
    {
        [TestMethod]
        public void Test()
        {
            var g = GraphFactory.GreateDirectGraph414();
            var stats = GeneralGraphShortestPath.ShortestPath(g, 7);//node char 'S' is 7
            Debug.WriteLine(stats);
        }
    }
}
