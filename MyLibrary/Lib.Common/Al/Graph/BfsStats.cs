using System.Text;

namespace Lib.Common.Al.Graph
{
    /// <summary>
    /// Breadth-first search statistics
    /// </summary>
    public class BfsStats
    {
        //distance for each vertice from a start vertice
        private readonly int[] _dist;

        //previous vertice for each vertice
        private readonly int[] _prev;

        public BfsStats(int V)
        {
            _dist = new int[V];
            for (int i = 0; i < _dist.Length; i++)
            {
                _dist[i] = int.MaxValue;
            }
        }

        public int[] Dist
        {
            get { return _dist; }
        }

        public int[] Prev
        {
            get { return _prev; }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("breadth-first search:");
            for (int i = 0; i < Dist.Length; i++)
            {
                sb.AppendLine(string.Format("{0}: {1}", i, Dist[i]));
            }
            sb.AppendLine();

            return sb.ToString();
        }
    }
}