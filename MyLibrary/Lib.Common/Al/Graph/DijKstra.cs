using Lib.Common.Ds.Pq;

namespace Lib.Common.Al.Graph
{
    public class Dijkstra
    {
        private readonly GraphBase _G;
        private readonly DijKstraStats _dijkstraStats;

        public Dijkstra(GraphBase g)
        {
            _G = g;
            _dijkstraStats = new DijKstraStats(g.V);
        }

        /// <summary>
        /// Dijkstra algorithm (shortest path)
        /// </summary>
        /// <param name="s">start vertice</param>
        public void ShortestPath(int s)
        {
            for (var i = 0; i < _dijkstraStats.Dist.Length; i++)
            {
                _dijkstraStats.Dist[i] = int.MaxValue;
                _dijkstraStats.Prev[i] = -1;
            }

            _dijkstraStats.Dist[s] = 0;//start vertice
            var pq = new MinPQ<Distance>(_dijkstraStats.Dist.Length);
            pq.Insert(new Distance { Dist = 0, V = s });

            while (!pq.IsEmpty())
            {
                var v = pq.DelMin();

                foreach (var e in _G.Adjacent(v.V))
                {
                    if (_dijkstraStats.Dist[e.V2] > _dijkstraStats.Dist[v.V] + e.Weight)
                    {
                        _dijkstraStats.Dist[e.V2] = _dijkstraStats.Dist[v.V] + e.Weight;
                        _dijkstraStats.Prev[e.V2] = v.V;
                        pq.Insert(new Distance { V = e.V2, Dist = _dijkstraStats.Dist[e.V2] });
                    }
                }
            }
        }

        public override string ToString()
        {
            return _dijkstraStats.ToString();
        }
    }
}