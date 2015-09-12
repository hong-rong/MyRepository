using System;
using System.Diagnostics;
using System.Text;

namespace Lib.Common.Al.Graph
{
    /// <summary>
    /// Depth-first search
    /// </summary>
    public class Dfs
    {
        private DfsStats _stats;
        private int _componentCount;
        private int _clock;

        public Dfs(int V)
        {
            _stats = new DfsStats(V);
            _componentCount = 0;
            _clock = 1;
        }

        public DfsStats DepthFirstSearch(GraphBase g)
        {
            for (var i = 0; i < g.V; i++)
                _stats.Visited[i] = false;

            for (var i = 0; i < g.V; i++)
                if (!_stats.Visited[i])
                {
                    _componentCount++;
                    Explore(g, i);
                }

            return _stats;
        }

        public DfsStats StrongConnectedComponentAlgorithm(DirectedGraph g)
        {
            g.ReverseGraph();//reverse G
            var stats = DepthFirstSearch(g);
            var linearization = _stats.Linearization;

            _stats = new DfsStats(g.V);
            _clock = 1;
            _componentCount = 0;

            (g as DirectedGraph).ReverseGraph();//reverse G back
            foreach (var v in linearization)
            {
                if (!_stats.Visited[v])
                {
                    _componentCount++;
                    Explore(g, v);
                }
            }

            return _stats;
        }

        public void Explore(GraphBase g, int v)
        {
            PreVisitVertice(v);

            foreach (var e in g.Adjacent(v))
            {
                if (!_stats.Visited[e.V2])
                {
                    Explore(g, e.V2);
                }
                //else if (e < v)
                //only directed graph has 'back edge'
                else if (g is DirectedGraph && e.V2 < v)//e < v is not right
                {
                    _stats.BackEdges.Add(new Edge { V1 = v, V2 = e.V2 });
                }
            }

            PostVisitVertice(v);
        }

        private void PreVisitVertice(int v)
        {
            _stats.Visited[v] = true;
            _stats.ComponentNum[v] = _componentCount;
            _stats.PreVisit[v] = _clock++;
        }

        private void PostVisitVertice(int v)
        {
            _stats.PostVisit[v] = _clock++;
            _stats.Linearization.AddFirst(v);
        }
    }
}