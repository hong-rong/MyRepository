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
        //map graph node from char to int, e.g., 'A'->0, make it viually easier to understand
        protected static SequentialSearchST<char, int?> Mapping;

        protected readonly int _V;
        protected int _E;
        protected LinkedList<Edge>[] Al;//adjacency list

        static GraphBase()
        {
            Mapping = new SequentialSearchST<char, int?>();
            Mapping.Put('A', 0);
            Mapping.Put('B', 1);
            Mapping.Put('C', 2);
            Mapping.Put('D', 3);
            Mapping.Put('E', 4);
            Mapping.Put('F', 5);
            Mapping.Put('G', 6);
            Mapping.Put('H', 7);
            Mapping.Put('I', 8);
            Mapping.Put('J', 9);
            Mapping.Put('K', 10);
            Mapping.Put('L', 11);
        }

        public GraphBase(int v)
        {
            _V = v;
            _E = 0;
            Al = new LinkedList<Edge>[v];
            for (var i = 0; i < v; i++)
            {
                Al[i] = new LinkedList<Edge>();
            }
        }

        /// <summary>
        /// Get graph char node mapped int number. If not in the mapping list, return -1
        /// </summary>
        /// <param name="key">Graph node with char representation</param>
        /// <returns>The mapped int of the char presentation</returns>
        public static int GetMappedNumber(char key)
        {
            if (Mapping.Contains(key))
                return Mapping.Get(key).Value;

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
        public abstract void AddEdge(char u, char v);

        public abstract void AddEdge(int u, int v);

        public abstract void AddEdge(Edge e);

        public abstract void RemoveEdge(Edge e);

        public virtual System.Collections.Generic.IEnumerable<Edge> Adjacent(int v)
        {
            return Al[v];
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Graph has following vertices and edges:");
            for (int i = 0; i < V; i++)
            {
                sb.Append(string.Format("{0}: ", i));
                if (Al[i].Size() > 0)
                {
                    foreach (var e in Al[i])
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