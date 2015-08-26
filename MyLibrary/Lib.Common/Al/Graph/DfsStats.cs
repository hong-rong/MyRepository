using System.Text;

namespace Lib.Common.Al.Graph
{
    public class DfsStats
    {
        private readonly int[] _preVisit;
        private readonly bool[] _visited;
        private readonly int[] _postVisit;
        private readonly int[] _componentNum;

        public DfsStats(int V)
        {
            _preVisit = new int[V];
            _visited = new bool[V];
            _postVisit = new int[V];
            _componentNum = new int[V];
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

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine();
            for (var i = 0; i < _preVisit.Length; i++)
            {
                sb.AppendLine(string.Format("ComponentNum[{0}]: {1}", i, ComponentNum[i]));
            }
            sb.AppendLine();

            for (var i = 0; i < _preVisit.Length; i++)
            {
                sb.AppendLine(string.Format("PreVisit[{0}]: {1}", i, PreVisit[i]));
                sb.AppendLine(string.Format("PostVisit[{0}]: {1}", i, PostVisit[i]));
            }
            sb.AppendLine();

            return sb.ToString();
        }
    }
}
