using Lib.Common.Ds.Pq;

namespace Lib.Common.Al.Graph
{
    public class DijKstra
    {
        private readonly GraphBase _G;
        private readonly DijKstraStats _bfsStats;

        public DijKstra(GraphBase g)
        {
            _G = g;
            _bfsStats = new DijKstraStats(g.V);
        }

        /// <summary>
        /// Dijkstra algorithm (shortest path)
        /// </summary>
        /// <param name="g">graph with positive edge weights</param>
        /// <param name="s">start vertice</param>
        public void Dijkstra(GraphBase g, int s)
        {
            for (var i = 0; i < _bfsStats.Dist.Length; i++)
            {
                _bfsStats.Dist[i] = int.MaxValue;
                _bfsStats.Prev[i] = -1;
            }

            _bfsStats.Dist[s] = 0;//start vertice
            _bfsStats.StartVertice = s;
            var pq = new MinPQ<Distance>(_bfsStats.Dist.Length);
            pq.Insert(new Distance { Dist = 0, Vertice = s });

            //var dists = new List<Distance>();
            //for (var i = 0; i < _bfsStats.Dist.Length; i++)
            //{
            //    dists.Add(new Distance { Vertice = i, Dist = _bfsStats.Dist[i] });
            //}
            //var pq = new MinPQ<Distance>(dists.ToArray());

            while (!pq.IsEmpty())
            {
                var v = pq.DelMin();

                foreach (var e in g.Adjacent(v.Vertice))
                {
                    if (_bfsStats.Dist[e.V2] > _bfsStats.Dist[v.Vertice] + e.Weight)
                    {
                        _bfsStats.Dist[e.V2] = _bfsStats.Dist[v.Vertice] + e.Weight;
                        _bfsStats.Prev[e.V2] = v.Vertice;
                    }

                    pq.Insert(new Distance { Vertice = e.V2, Dist = _bfsStats.Dist[e.V2] });
                }
            }
        }
    }
}
