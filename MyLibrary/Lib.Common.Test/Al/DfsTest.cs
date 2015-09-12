using System.Diagnostics;
using Lib.Common.Al.Graph;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lib.Common.Test.Al
{
    [TestClass]
    public class DfsTest
    {
        [TestMethod]
        public void UndirectedGraph32_Explore_Test()
        {
            var g = GraphFactory.CreateUndirectedGraph32();
            var dfs = new Dfs(g.V);
            dfs.Explore(g, 0);     //explore Vertice A
            Debug.WriteLine(dfs.ToString());
        }

        [TestMethod]
        public void UndirectedGraph36_DepthFirstSearch_Test()
        {
            var g = GraphFactory.CreateUndirectedGraph36();
            var dfs = new Dfs(g.V);
            var dfsStats = dfs.DepthFirstSearch(g);
            Debug.WriteLine(dfsStats);
        }

        [TestMethod]
        public void DirectedGraph37_DepthFirstSearch_Test()
        {
            var g = GraphFactory.CreateDirectGraph37();
            var dfs = new Dfs(g.V);
            var dfsStats = dfs.DepthFirstSearch(g);
            Debug.WriteLine(dfsStats);
        }

        [TestMethod]
        public void DirectedGraph38_Linearization_Test()
        {
            var g = GraphFactory.CreateDirectGraph38();
            var dfs = new Dfs(g.V);
            var dfsStats = dfs.DepthFirstSearch(g);
            var l = dfsStats.Linearization.ToArray();
            Assert.AreEqual(1, l[0]);
            Assert.AreEqual(3, l[1]);
            Assert.AreEqual(0, l[2]);
            Assert.AreEqual(2, l[3]);
            Assert.AreEqual(5, l[4]);
            Assert.AreEqual(4, l[5]);
            Debug.WriteLine(dfsStats);
        }

        [TestMethod]
        public void DirectedGraph39_DepthFirstSearch_Test()
        {
            var g = GraphFactory.CreateDirectGraph39();
            var dfs = new Dfs(g.V);
            var dfsStats = dfs.DepthFirstSearch(g);
            Debug.WriteLine(dfsStats);
        }

        [TestMethod]
        public void DirectedGraph39_StrongConnectedComponentAlgorithm_Test()
        {
            var g = GraphFactory.CreateDirectGraph39();
            var dfs = new Dfs(g.V);
            var dfsStats = dfs.StrongConnectedComponentAlgorithm(g);
            Debug.WriteLine(dfsStats);
        }
    }
}