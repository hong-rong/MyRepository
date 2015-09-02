using Lib.Common.Ds.Pq;
using Lib.Common.Ds.Queue;
using System;
using System.Linq;
using System.Text;

namespace Lib.Common.Al.Graph
{
    /// <summary>
    /// Breadth-first search
    /// </summary>
    public class Bfs
    {
        private readonly GraphBase _G;
        private readonly BfsStats _bfsStats;

        public Bfs(GraphBase g)
        {
            _G = g;
            _bfsStats = new BfsStats(g.V);
        }

        public void BreadthFirstSearch(int s)
        {
            _bfsStats.Dist[s] = 0;
            var q = new Queue<int>();
            q.Enqueue(s);
            while (!q.IsEmpty())
            {
                var u = q.Dequeue();
                foreach (var e in _G.Adjacent(u))
                {
                    if (_bfsStats.Dist[e.V2] == int.MaxValue)
                    {
                        q.Enqueue(e.V2);
                        _bfsStats.Dist[e.V2] = _bfsStats.Dist[u] + 1;
                    }
                }
            }
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

            var pq = new MinPQ<int>();

            while (!pq.IsEmpty())
            {
                var v = pq.DelMin();

                foreach (var e in g.Adjacent(v))
                {
                    if (_bfsStats.Dist[e.V2] > _bfsStats.Dist[v] + e.Weight)
                    {
                        _bfsStats.Dist[e.V2] = _bfsStats.Dist[v] + e.Weight;
                        _bfsStats.Prev[e.V2] = v;
                    }

                    //update weight for e.V2 in pq
                }
            }
        }

        public override string ToString()
        {
            return _bfsStats.ToString();
        }
    }
}