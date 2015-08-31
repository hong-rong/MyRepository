using Lib.Common.Ds.Bs;
using Lib.Common.Ds.Ll;
using System.Text;

namespace Lib.Common.Al.Graph
{
    /// <summary>
    /// base class for undirected graph and directed graph
    /// </summary>
    public abstract class GraphBase
    {
        protected static SequentialSearchST<char, int?> _mapping;
        protected readonly int _V;
        protected int _E;
        protected LinkedList<int>[] _al;//adjacency list

        static GraphBase()
        {
            _mapping = new SequentialSearchST<char, int?>();
            _mapping.Put('A', 0);
            _mapping.Put('B', 1);
            _mapping.Put('C', 2);
            _mapping.Put('D', 3);
            _mapping.Put('E', 4);
            _mapping.Put('F', 5);
            _mapping.Put('G', 6);
            _mapping.Put('H', 7);
            _mapping.Put('I', 8);
            _mapping.Put('J', 9);
            _mapping.Put('K', 10);
            _mapping.Put('L', 11);
        }

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

        public int GetMappedNumber(char key)
        {
            if (_mapping.Contains(key))
                return _mapping.Get(key).Value;
            else
                return -1;
        }

        public virtual int V
        {
            get { return _V; }
        }

        public virtual int E
        {
            get { return _E; }
        }

        /// <summary>
        /// add edge based on character which used in a lot of graph example.
        /// It has same effect ad AddEdge(int u, int v)
        /// This make it easier when adding edges from visual graph.
        /// e.g., add edge for 'A' to 'B', same as AddEdge(0, 1) because 'A' is mapped to 0, and 'B' is mapped to 1
        /// </summary>
        /// <param name="u"></param>
        /// <param name="v"></param>
        public abstract void AddEdge(char u, char v);

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