using Lib.Common.Ds.Ll;

namespace Lib.Common.Al.Graph
{
    public abstract class GraphBase
    {
        protected readonly int _V;
        protected int _E;
        protected LinkedList<int>[] _al;//adjacency list

        public GraphBase(int V)
        {
            _V = V;
            _E = 0;
            _al = new LinkedList<int>[V];
            for (int i = 0; i < V; i++)
            {
                _al[i] = new LinkedList<int>();
            }
        }

        public virtual int V
        {
            get { return _V; }
        }

        public virtual int E
        {
            get { return _E; }
        }

        public abstract void AddPath(int u, int v);

        public virtual System.Collections.Generic.IEnumerable<int> Adjacent(int v)
        {
            return _al[v];
        }
    }
}
