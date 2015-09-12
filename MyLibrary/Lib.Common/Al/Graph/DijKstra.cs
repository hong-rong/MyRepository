using Lib.Common.Ds.Pq;

namespace Lib.Common.Al.Graph
{
    public class Dijkstra
    {
        /// <summary>
        /// Dijkstra algorithm (shortest path) based on graph g for start vertice s
        /// </summary>
        /// <param name="g">Graph for search</param>
        /// <param name="s">Start vertice</param>
        public static ShortestPathStats ShortestPath(GraphBase g, int s)
        {
            var dijkstraStats = new ShortestPathStats(g.V);

            for (var i = 0; i < dijkstraStats.Dist.Length; i++)
            {
                dijkstraStats.Dist[i] = int.MaxValue;
                dijkstraStats.Prev[i] = -1;
            }

            dijkstraStats.Dist[s] = 0;//start vertice
            var pq = new MinPQ<Distance>(dijkstraStats.Dist.Length);
            pq.Insert(new Distance { Dist = 0, V = s });

            while (!pq.IsEmpty())
            {
                var v = pq.DelMin();

                foreach (var e in g.Adjacent(v.V))
                {
                    if (dijkstraStats.Dist[e.V2] > dijkstraStats.Dist[v.V] + e.Weight)
                    {
                        dijkstraStats.Dist[e.V2] = dijkstraStats.Dist[v.V] + e.Weight;
                        dijkstraStats.Prev[e.V2] = v.V;
                        pq.Insert(new Distance { V = e.V2, Dist = dijkstraStats.Dist[e.V2] });
                    }
                }
            }

            return dijkstraStats;
        }
    }
}