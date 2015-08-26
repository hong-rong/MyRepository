using System.Diagnostics;
using System.Text;

namespace Lib.Common.Al.Graph
{
    public class Dfs
    {
        private readonly DfsStats _dfsStats;

        private int _componentCount;
        private int _clock;

        private readonly UndirectedGraph _G;

        public Dfs(UndirectedGraph G)
        {
            _dfsStats = new DfsStats(G.V);

            _componentCount = 0;
            _clock = 1;

            _G = G;
        }

        public void Explore(int v)
        {
            _dfsStats.Visited[v] = true;

            _dfsStats.ComponentNum[v] = _componentCount;


            PreVisitVertice(v);

            foreach (var e in _G.Adjacent(v))
                if (!_dfsStats.Visited[e])
                    Explore(e);

            PostVisitVertice(v);
        }

        private void PreVisitVertice(int v)
        {
            _dfsStats.PreVisit[v] = _clock++;
            Debug.WriteLine(string.Format("pre[{0}]: {1}", v, _dfsStats.PreVisit[v]));
        }

        private void PostVisitVertice(int v)
        {
            _dfsStats.PostVisit[v] = _clock++;
            Debug.WriteLine(string.Format("post[{0}]: {1}", v, _dfsStats.PostVisit[v]));
        }

        public void DepthFirstSearch()
        {
            for (var i = 0; i < _G.V; i++)
                _dfsStats.Visited[i] = false;

            for (var i = 0; i < _G.V; i++)
                if (!_dfsStats.Visited[i])
                {
                    _componentCount++;
                    Explore(i);
                }
        }

        public override string ToString()
        {
            return _dfsStats.ToString();
            //var sb = new StringBuilder();
            //for (var i = 0; i < _G.V; i++)
            //{
            //    sb.AppendLine("ComponentNum: " + _dfsStats.ComponentNum[i]);
            //    sb.AppendLine(string.Format("PreVisit[{0}]: {1}", i, _dfsStats.PreVisit[i]));
            //    sb.AppendLine(string.Format("PostVisit[{0}]: {1}", i, _dfsStats.PostVisit[i]));
            //}

            //return sb.ToString();
        }
    }
}