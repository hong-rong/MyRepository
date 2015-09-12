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
            var g = UndirectedGraph.CreateUndirectedGraph32();
            var dfs = new Dfs(g);
            dfs.Explore(0);     //explore Vertice A
            Debug.WriteLine(dfs.ToString());
        }

        [TestMethod]
        public void UndirectedGraph36_DepthFirstSearch_Test()
        {
            var g = UndirectedGraph.CreateUndirectedGraph36();
            var dfs = new Dfs(g);
            var dfsStats = dfs.DepthFirstSearch();
            Debug.WriteLine(dfsStats);
        }

        [TestMethod]
        public void DirectedGraph37_DepthFirstSearch_Test()
        {
            var g = DirectedGraph.CreateGraph37();
            var dfs = new Dfs(g);
            var dfsStats = dfs.DepthFirstSearch();
            Debug.WriteLine(dfsStats);
        }

        [TestMethod]
        public void DirectedGraph38_DepthFirstSearch_Test()
        {
            var g = DirectedGraph.CreateGraph38();
            var dfs = new Dfs(g);
            var dfsStats = dfs.DepthFirstSearch();
            Debug.WriteLine(dfsStats);
        }

        [TestMethod]
        public void DirectedGraph39_DepthFirstSearch_Test()
        {
            var g = DirectedGraph.CreateGraph39();
            var dfs = new Dfs(g);
            var dfsStats = dfs.DepthFirstSearch();
            Debug.WriteLine(dfsStats);
        }

        [TestMethod]
        public void DirectedGraph39_StrongConnectedComponentAlgorithm_Test()
        {
            var g = DirectedGraph.CreateGraph39();
            var dfs = new Dfs(g);
            var dfsStats = dfs.StrongConnectedComponentAlgorithm();
            Debug.WriteLine(dfsStats);
        }
    }
}