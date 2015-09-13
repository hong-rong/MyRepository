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
        public static PathStats ShortestPath(GraphBase g, int s)
        {
            return GetPathStats(g, s, true);
        }

        /// <summary>
        /// Dijkstra algorithm (longest path) based on graph g for start vertice s
        /// </summary>
        /// <param name="g">Graph for search</param>
        /// <param name="s">Start vertice</param>
        public static PathStats LongestPath(GraphBase g, int s)
        {
            return GetPathStats(g, s, false);
        }

        private static PathStats GetPathStats(GraphBase g, int s, bool isShortest)
        {
            var ps = new PathStats(g.V);

            for (var i = 0; i < ps.Dist.Length; i++)
            {
                ps.Dist[i] = isShortest ? int.MaxValue : int.MinValue;
                ps.Prev[i] = -1;
            }

            ps.Dist[s] = 0;//start vertice
            var pq = new MinPQ<Distance>(ps.Dist.Length);
            pq.Insert(new Distance { Dist = 0, V = s });

            while (!pq.IsEmpty())
            {
                var v = pq.DelMin();

                foreach (var e in g.Adjacent(v.V))
                {
                    if ((isShortest && ps.Dist[e.V2] > ps.Dist[v.V] + e.Weight) ||  //shortest path
                        (!isShortest && ps.Dist[e.V2] < ps.Dist[v.V] + e.Weight))   //longest path
                    {
                        ps.Dist[e.V2] = ps.Dist[v.V] + e.Weight;
                        ps.Prev[e.V2] = v.V;
                        pq.Insert(new Distance { V = e.V2, Dist = ps.Dist[e.V2] });
                    }
                }
            }

            return ps;
        }
    }
}