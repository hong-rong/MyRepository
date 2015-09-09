using Lib.Common.Ds.Queue;
using System;

namespace Lib.Common.Al.Graph
{
    public class DirectedGraph : GraphBase
    {
        public DirectedGraph(int v)
            : base(v)
        { }

        public static DirectedGraph CreateGraph49()
        {
            var g = new DirectedGraph(5);

            g.AddEdge('A', 'B');
            g.AddEdge('A', 'C');
            g.AddEdge('B', 'C');
            g.AddEdge('B', 'D');
            g.AddEdge('B', 'E');
            g.AddEdge('C', 'B');
            g.AddEdge('C', 'D');
            g.AddEdge('C', 'E');
            g.AddEdge('E', 'D');

            return g;
        }

        public static DirectedGraph CreateGraph39()
        {
            var g = new DirectedGraph(12);

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
            for (var v = 0; v < _V; v++)
            {
                foreach (var e in Al[v])
                {
                    q.Enqueue(new Edge { V1 = e.V2, V2 = v });//reverse edge
                }
            }

            for (var i = 0; i < _V; i++)
            {
                Al[i].Clear();
            }
            _E = 0;

            foreach (var e in q)
            {
                AddEdge(e);
            }
        }

        public override void AddEdge(char u, char v)
        {
            int nu = GetMappedNumber(u) == -1 ? Al.Length - 1 : GetMappedNumber(u);
            int nv = GetMappedNumber(u) == -1 ? Al.Length - 1 : GetMappedNumber(v);

            Al[nu].AddLast(new Edge { V1 = nu, V2 = nv });
            _E++;
        }

        public override void AddEdge(int u, int v)
        {
            Al[u].AddLast(new Edge { V1 = u, V2 = v });
            _E++;
        }

        public override void AddEdge(Edge e)
        {
            Al[e.V1].AddLast(e);
            _E++;
        }

        public override void RemoveEdge(Edge e)
        {
            Al[e.V1].Remove(e.V2);
            _E--;
        }
    }
}