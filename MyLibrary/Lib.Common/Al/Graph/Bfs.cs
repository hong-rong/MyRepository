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
            var q = new Ds.Queue.Queue<int>();
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

        public override string ToString()
        {
            return _bfsStats.ToString();
        }
    }
}