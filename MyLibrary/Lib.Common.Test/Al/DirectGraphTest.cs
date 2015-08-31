using Lib.Common.Al.Graph;
using Lib.Common.Ds.Queue;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Lib.Common.Test.Al
{
    [TestClass]
    public class DirectGraphTest
    {
        [TestMethod]
        public void ToString_Test()
        {
            Debug.WriteLine(DirectedGraph.CreateGraph37());
        }

        [TestMethod]
        public void Reverse_Test()
        {
            var g = DirectedGraph.CreateGraph37();
            g.ReverseGraph();
            
            Debug.WriteLine(g);
        }
    }
}
