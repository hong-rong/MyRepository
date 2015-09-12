using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Common.Al.Graph
{
    /// <summary>
    /// Shortest path for DAG
    /// </summary>
    public class DagShortestPath
    {
        public static ShortestPathStats ShortestPath(DirectedGraph g, int s)
        {
            #region Initialization
            var stats = new ShortestPathStats(g.V);
            for (int i = 0; i < stats.Dist.Length; i++)
            {
                stats.Dist[i] = int.MaxValue;
                stats.Prev[i] = -1;
            }
            stats.Dist[s] = 0;
            #endregion

            var dfs = new Dfs(g.V);
            var dfsStats = dfs.DepthFirstSearch(g);
            var linearization = dfsStats.Linearization;
            Debug.WriteLine(dfsStats);
            foreach (var u in linearization)
            {
                foreach (var v in g.Adjacent(u))
                {
                    if (stats.Dist[v.V2] > stats.Dist[v.V1] + v.Weight)
                    {
                        stats.Dist[v.V2] = stats.Dist[v.V1] + v.Weight;
                        stats.Prev[v.V2] = u;
                    }
                }
            }

            return stats;
        }
    }
}
