using Lib.Common.Ds.Ll;
using System.Text;

namespace Lib.Common.Al.Graph
{
    public class Edge
    {
        public int V1 { get; set; }
        public int V2 { get; set; }
        public int Weight { get; set; }

        public Edge ReverseVertices()
        {
            return new Edge { V1 = V2, V2 = V1, Weight = Weight };
        }

        public override string ToString()
        {
            return string.Format("{0} to {1} with weight: {2}", V1, V2, Weight);
        }
    }

    public enum Color
    {
        White = 0,
        Grey = 1,
        Black = 2
    }

    /// <summary>
    /// Statistics for depth-first search results
    /// </summary>
    public class DfsStats
    {
        private readonly int[] _preVisit;
        private readonly bool[] _visited;
        private readonly int[] _postVisit;
        private readonly int[] _componentNum;

        private readonly System.Collections.Generic.List<Edge> _treeDeges;//tree dege or forward edge
        private readonly System.Collections.Generic.List<Edge> _backEdges;
        private readonly System.Collections.Generic.List<Edge> _crossEdges;
        private readonly Color[] _colors;

        private readonly LinkedList<int> _linearization;//topological sort

        public DfsStats(int V)
        {
            _preVisit = new int[V];
            _visited = new bool[V];
            _postVisit = new int[V];
            _componentNum = new int[V];

            _treeDeges = new System.Collections.Generic.List<Edge>();
            _backEdges = new System.Collections.Generic.List<Edge>();
            _crossEdges = new System.Collections.Generic.List<Edge>();
            _colors = new Color[V];

            _linearization = new LinkedList<int>();
        }

        public int[] PreVisit
        {
            get { return _preVisit; }
        }

        public bool[] Visited
        {
            get { return _visited; }
        }

        public void ResetStats()
        {
            for (int i = 0; i < Visited.Length; i++)
            {
                PreVisit[i] = -1;
                Visited[i] = false;
                PostVisit[i] = -1;
                ComponentNum[i] = -1;
            }
        }

        public int[] PostVisit
        {
            get { return _postVisit; }
        }

        public int[] ComponentNum
        {
            get { return _componentNum; }
        }

        public System.Collections.Generic.List<Edge> TreeEdges { get { return _treeDeges; } }

        public System.Collections.Generic.List<Edge> BackEdges { get { return _backEdges; } }

        public System.Collections.Generic.List<Edge> CrossEdges { get { return _crossEdges; } }

        public Color[] Colors { get { return _colors; } }

        public LinkedList<int> Linearization
        {
            get { return _linearization; }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Component number:");
            for (var i = 0; i < _preVisit.Length; i++)
            {
                sb.AppendLine(string.Format("{0}: {1}", i, ComponentNum[i]));
            }

            sb.AppendLine();
            sb.AppendLine("Pre visit order:");
            for (var i = 0; i < _preVisit.Length; i++)
            {
                sb.AppendLine(string.Format("{0}: {1}", i, PreVisit[i]));
            }

            sb.AppendLine();
            sb.AppendLine("Post visit order:");
            for (var i = 0; i < _preVisit.Length; i++)
            {
                sb.AppendLine(string.Format("{0}: {1}", i, PostVisit[i]));
            }

            sb.AppendLine();
            sb.AppendLine("Back edge:");
            foreach (var b in BackEdges)
            {
                sb.AppendLine(string.Format("From {0} to {1}", b.V1, b.V2));
            }

            sb.AppendLine();
            sb.AppendLine("Linearization(topological sort): ");
            foreach (var l in _linearization)
            {
                sb.AppendLine(string.Format("{0}, post number: {1}", l, _postVisit[l]));
            }

            return sb.ToString();
        }
    }
}