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
    public class DijkstraTest
    {
        [TestMethod]
        public void Test()
        {
            Dijkstra d = new Dijkstra(DirectedGraph.CreateGraph49());

            d.ShortestPath(0);

            Debug.WriteLine(d.ToString());
        }
    }
}