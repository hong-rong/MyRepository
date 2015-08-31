﻿using Lib.Common.Ds.Ll;
using Lib.Common.Ds.Queue;
using System;

namespace Lib.Common.Al.Graph
{
    /// <summary>
    /// A	0
    /// B	1
    /// C	2
    /// D	3
    /// E	4
    /// F	5
    /// G	6
    /// H	7
    /// I	8
    /// J	9
    /// K	10
    /// L   11
    /// </summary>
    public class DirectedGraph : GraphBase
    {
        public DirectedGraph(int V)
            : base(V)
        { }

        public static DirectedGraph CreateGraph39()
        {
            DirectedGraph g = new DirectedGraph(12);

            #region add edge
            //A
            g.AddEdge(0, 1);
            //B
            g.AddEdge(1, 2);
            g.AddEdge(1, 3);
            g.AddEdge(1, 4);
            //C
            g.AddEdge(2, 5);
            //E
            g.AddEdge(4, 1);
            g.AddEdge(4, 5);
            g.AddEdge(4, 6);
            //F
            g.AddEdge(5, 2);
            g.AddEdge(5, 6);
            //G
            g.AddEdge(6, 7);
            g.AddEdge(6, 9);
            //H
            g.AddEdge(7, 10);
            //I
            g.AddEdge(8, 6);
            //J
            g.AddEdge(9, 8);
            //K
            g.AddEdge(10, 11);
            //L
            g.AddEdge(11, 9);

#endregion

            return g;
        }

        public static DirectedGraph CreateGraph38()
        {
            var g = new DirectedGraph(6);

            g.AddEdge(0, 2);
            g.AddEdge(1, 0);
            g.AddEdge(1, 3);
            g.AddEdge(2, 4);
            g.AddEdge(2, 5);
            g.AddEdge(3, 2);

            return g;
        }

        public static DirectedGraph CreateGraph37()
        {
            var g = new DirectedGraph(8);

            #region add path

            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            g.AddEdge(0, 5);

            g.AddEdge(1, 4);

            g.AddEdge(2, 3);

            g.AddEdge(3, 7);
            g.AddEdge(3, 0);

            g.AddEdge(4, 5);
            g.AddEdge(4, 6);
            g.AddEdge(4, 7);

            g.AddEdge(5, 6);
            g.AddEdge(5, 1);

            g.AddEdge(7, 6);

            #endregion

            return g;
        }

        public void ReverseGraph()
        {
            var q = new Queue<Edge>();
            for (int v = 0; v < _V; v++)
            {
                foreach (var u in _al[v])
                {
                    q.Enqueue(new Edge() { From = u, To = v });//reverse edge
                }
            }

            for (int i = 0; i < _V; i++)
            {
                _al[i].Clear();
            }
            _E = 0;

            foreach (var e in q)
            {
                AddEdge(e.From, e.To);
            }
        }

        public override void AddEdge(char u, char v)
        {
            throw new NotImplementedException();
        }

        public override void AddEdge(int u, int v)
        {
            _al[u].AddLast(v);

            _E++;
        }

        public override void RemoveEdge(int u, int v)
        {
            _al[u].Remove(v);
            _E--;
        }
    }
}