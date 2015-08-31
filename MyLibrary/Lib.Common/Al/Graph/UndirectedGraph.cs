using Lib.Common.Ds.Ll;

namespace Lib.Common.Al.Graph
{
    public class UndirectedGraph : GraphBase
    {
        public UndirectedGraph(int V)
            : base(V)
        { }

        public static UndirectedGraph CreateUndirectedGraph41()
        {
            UndirectedGraph g = new UndirectedGraph(6);

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
            int nu = GetMappedNumber(u) == -1 ? _al.Length - 1 : GetMappedNumber(u);
            int nv = GetMappedNumber(v) == -1 ? _al.Length - 1 : GetMappedNumber(v);
            _al[nu].AddLast(nv);
            _al[nv].AddLast(nu);

            _E++;
        }

        public override void AddEdge(int u, int v)
        {
            _al[u].AddLast(v);
            _al[v].AddLast(u);
            _E++;
        }

        public override void RemoveEdge(int u, int v)
        {
            _al[u].Remove(v);
            _al[v].Remove(u);
            _E--;
        }
    }
}