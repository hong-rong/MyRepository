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
    public class DirectedGraph : GraphBase
    {
        public DirectedGraph(int V)
            : base(V)
        { }

        public static DirectedGraph CreateGraph37()
        {
            var g = new DirectedGraph(8);

            #region add path

            g.AddPath(0, 1);
            g.AddPath(0, 2);
            g.AddPath(0, 5);

            g.AddPath(1, 4);

            g.AddPath(2, 3);

            g.AddPath(3, 7);
            g.AddPath(3, 0);

            g.AddPath(4, 5);
            g.AddPath(4, 6);
            g.AddPath(4, 7);

            g.AddPath(5, 6);
            g.AddPath(5, 1);

            g.AddPath(7, 6);

            #endregion

            return g;
        }

        public override void AddPath(int u, int v)
        {
            _al[u].Add(v);

            _E++;
        }
    }
}
