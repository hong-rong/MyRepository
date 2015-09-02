namespace Lib.Common.Al.Graph
{
    public class UndirectedGraph : GraphBase
    {
        public UndirectedGraph(int v)
            : base(v)
        { }

        public static UndirectedGraph CreateUndirectedGraph41()
        {
            var g = new UndirectedGraph(6);

            g.AddEdge('A', 'B');
            g.AddEdge('A', 'S');
            g.AddEdge('B', 'C');
            g.AddEdge('C', 'S');
            g.AddEdge('D', 'E');
            g.AddEdge('D', 'S');
            g.AddEdge('E', 'S');

            return g;
        }

        public static UndirectedGraph CreateUndirectedGraph36()
        {
            var g = new UndirectedGraph(12);

            #region add path

            //first component
            g.AddEdge(0, 1);
            g.AddEdge(0, 4);

            g.AddEdge(4, 8);
            g.AddEdge(4, 9);

            g.AddEdge(8, 9);

            //second component
            //node F is alone

            //third component
            g.AddEdge(2, 3);
            g.AddEdge(2, 6);
            g.AddEdge(2, 7);

            g.AddEdge(3, 7);

            g.AddEdge(6, 7);
            g.AddEdge(6, 10);

            g.AddEdge(7, 10);
            g.AddEdge(7, 11);

            #endregion

            return g;
        }

        public static UndirectedGraph CreateUndirectedGraph32()
        {
            var g = new UndirectedGraph(10);

            #region add path

            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            g.AddEdge(0, 3);

            g.AddEdge(1, 4);
            g.AddEdge(1, 5);

            g.AddEdge(2, 5);

            g.AddEdge(3, 6);
            g.AddEdge(3, 7);

            g.AddEdge(4, 8);
            g.AddEdge(4, 9);

            g.AddEdge(6, 7);

            g.AddEdge(8, 9);

            #endregion

            return g;
        }

        public override void AddEdge(char u, char v)
        {
            int nu = GetMappedNumber(u) == -1 ? Al.Length - 1 : GetMappedNumber(u);
            int nv = GetMappedNumber(v) == -1 ? Al.Length - 1 : GetMappedNumber(v);
            Al[nu].AddLast(new Edge { V1 = nu, V2 = nv });
            Al[nv].AddLast(new Edge { V1 = nv, V2 = nu });

            _E++;
        }

        public override void AddEdge(int u, int v)
        {
            Al[u].AddLast(new Edge { V1 = u, V2 = v });
            Al[v].AddLast(new Edge { V1 = v, V2 = u });
            _E++;
        }

        public override void AddEdge(Edge e)
        {
            Al[e.V1].AddLast(e);
            Al[e.V2].AddLast(e.ReverseVertices());
            _E++;
        }

        public override void RemoveEdge(Edge e)
        {
            Al[e.V1].Remove(e.V2);
            Al[e.V2].Remove(e.V1);
            _E--;
        }
    }
}