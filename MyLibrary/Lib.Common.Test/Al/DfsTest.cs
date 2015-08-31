using Lib.Common.Al.Graph;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace Lib.Common.Test.Al
{
    [TestClass]
    public class DfsTest
    {
        [TestMethod]
        public void UndirectedGraph_Explore_Test()
        {
            var g = UndirectedGraph.CreateUndirectedGraph32();

            var dfs = new Dfs(g);
            dfs.Explore(0);//explore Vertice A

            Debug.WriteLine("");
            Debug.WriteLine(dfs.ToString());
        }

        [TestMethod]
        public void UndirectedGraph_Dfs_Test()
        {
            var g = UndirectedGraph.CreateUndirectedGraph36();

            var dfs = new Dfs(g);
            dfs.DepthFirstSearch();

            Debug.WriteLine(dfs.ToString());
        }

        [TestMethod]
        public void DirectedGraph37_Explore_Test()
        {
            var g = DirectedGraph.CreateGraph37();

            var dfs = new Dfs(g);
            dfs.DepthFirstSearch();

            Debug.WriteLine(dfs.ToString());
        }

        [TestMethod]
        public void DirectedGraph38_Explore_Test()
        {
            var g = DirectedGraph.CreateGraph38();

            var dfs = new Dfs(g);
            dfs.DepthFirstSearch();

            Debug.WriteLine(dfs.ToString());
        }

        [TestMethod]
        public void DirectedGraph39_Explore_Test()
        {
            var g = DirectedGraph.CreateGraph39();

            var dfs = new Dfs(g);
            dfs.DepthFirstSearch();

            Debug.WriteLine(dfs.ToString());
        }
    }
}