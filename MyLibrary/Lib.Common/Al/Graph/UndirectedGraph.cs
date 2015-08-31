using Lib.Common.Ds.Ll;

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
    public class UndirectedGraph : GraphBase
    {
        public UndirectedGraph(int V)
            : base(V)
        { }

        public static UndirectedGraph CreateGraph32()
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

        public static UndirectedGraph CreateGraph36()
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

        public override void AddEdge(int u, int v)
        {
            _al[u].Add(v);
            _al[v].Add(u);
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