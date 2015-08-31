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
    public class BfsTest
    {
        [TestMethod]
        public void BreadthFirstSearch_Test()
        {
            var ug = UndirectedGraph.CreateUndirectedGraph41();
            var bfs = new Bfs(ug);
            bfs.BreadthFirstSearch(5);

            Debug.WriteLine(bfs.ToString());
        }
    }
}
