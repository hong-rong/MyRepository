using Lib.Common.Ds.Queue;
using System.Text;

namespace Lib.Common.Al.Graph
{
    public struct Edge
    {
        public int From;
        public int To;
    }

    public enum Color
    {
        White = 0,
        Grey = 1,
        Black = 2
    }

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

        private readonly Queue<int> _linearization;//topological sort

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

            _linearization = new Queue<int>();
        }

        public int[] PreVisit
        {
            get { return _preVisit; }
        }

        public bool[] Visited
        {
            get { return _visited; }
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

        public Queue<int> Linearization
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
                sb.AppendLine(string.Format("From {0} to {1}", b.From, b.To));
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