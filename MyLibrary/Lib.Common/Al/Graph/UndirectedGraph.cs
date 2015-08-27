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

            g.AddPath(0, 1);
            g.AddPath(0, 2);
            g.AddPath(0, 3);

            g.AddPath(1, 4);
            g.AddPath(1, 5);

            g.AddPath(2, 5);

            g.AddPath(3, 6);
            g.AddPath(3, 7);

            g.AddPath(4, 8);
            g.AddPath(4, 9);

            g.AddPath(6, 7);

            g.AddPath(8, 9);

            #endregion

            return g;
        }

        public static UndirectedGraph CreateGraph36()
        {
            var g = new UndirectedGraph(12);

            #region add path

            //first component
            g.AddPath(0, 1);
            g.AddPath(0, 4);

            g.AddPath(4, 8);
            g.AddPath(4, 9);

            g.AddPath(8, 9);

            //second component
            //node F is alone

            //third component
            g.AddPath(2, 3);
            g.AddPath(2, 6);
            g.AddPath(2, 7);

            g.AddPath(3, 7);

            g.AddPath(6, 7);
            g.AddPath(6, 10);

            g.AddPath(7, 10);
            g.AddPath(7, 11);

            #endregion

            return g;
        }

        public override void AddPath(int u, int v)
        {
            _al[u].Add(v);
            _al[v].Add(u);

            _E++;
        }
    }
}
