using Lib.Common.Ds.Ll;
using System.Text;

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

        public abstract void AddEdge(int u, int v);

        public abstract void RemoveEdge(int u, int v);

        public virtual System.Collections.Generic.IEnumerable<int> Adjacent(int v)
        {
            return _al[v];
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Graph has following vertices and edges:");
            for (int i = 0; i < V; i++)
            {
                sb.Append(string.Format("{0}: ", i));
                if (_al[i].Size() > 0)
                {
                    foreach (var e in _al[i])
                    {
                        sb.Append(string.Format("{0} ", e));
                    }

                }
                else
                {
                    sb.Append("no edge");
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}