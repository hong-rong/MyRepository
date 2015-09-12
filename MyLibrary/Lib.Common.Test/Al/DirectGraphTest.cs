using System;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Lib.Common.Al.Graph;
using Lib.Common.Ds.Queue;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lib.Common.Test.Al
{
    [TestClass]
    public class DirectGraphTest
    {
        [TestMethod]
        public void ToString_Test()
        {
            var dg = GraphFactory.CreateGraph37();
            Assert.AreEqual(8, dg.V);
            Assert.AreEqual(13, dg.E);
        }

        [TestMethod]
        public void Reverse_Test()
        {
            var dg = GraphFactory.CreateGraph37();
            dg.ReverseGraph();
            var adj = dg.Adjacent(5).ToList();//reversed neibour of node 5
            Assert.AreEqual(8, dg.V);
            Assert.AreEqual(13, dg.E);
            Assert.AreEqual(0, adj[0].V2);
            Assert.AreEqual(4, adj[1].V2);
        }
    }
}
