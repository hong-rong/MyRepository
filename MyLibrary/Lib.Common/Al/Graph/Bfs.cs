using Lib.Common.Ds.Queue;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Common.Al.Graph
{
    /// <summary>
    /// Breadth-first search
    /// </summary>
    public class Bfs
    {
        private readonly GraphBase _G;
        private readonly BfsStats _bfsStats;

        public Bfs(GraphBase G)
        {
            _G = G;
            _bfsStats = new BfsStats(G.V);
        }

        public void BreadthFirstSearch(int s)
        {
            _bfsStats.Dist[s] = 0;
            var q = new Queue<int>();
            q.Enqueue(s);
            while (!q.IsEmpty())
            {
                var u = q.Dequeue();
                foreach (var v in _G.Adjacent(u))
                {
                    if (_bfsStats.Dist[v] == int.MaxValue)
                    {
                        q.Enqueue(v);
                        _bfsStats.Dist[v] = _bfsStats.Dist[u] + 1;
                    }
                }
            }
        }

        public override string ToString()
        {
            return _bfsStats.ToString();
        }
    }
}