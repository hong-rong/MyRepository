using System;
using System.Text;

namespace Lib.Common.Al.Graph
{
    /// <summary>
    /// Vertice distance for Dijkstra's algorithm in priority queue
    /// </summary>
    public class Distance : IComparable<Distance>
    {
        public int V { get; set; }
        public int Dist { get; set; }

        public int CompareTo(Distance other)
        {
            return Dist.CompareTo(other.Dist);
        }
    }

    public class ShortestPathStats
    {
        //distance for each vertice from a start vertice
        private readonly int[] _dist;

        //previous vertice for each vertice
        private readonly int[] _prev;

        public ShortestPathStats(int V)
        {
            _dist = new int[V];
            _prev = new int[V];
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
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Shortest path:");
            for (int i = 0; i < Prev.Length; i++)
            {
                sb.AppendLine(string.Format("{0}: {1}", i, Prev[i].ToString()));
            }
            sb.AppendLine();

            sb.AppendLine("Vertice distance:");
            for (int i = 0; i < Dist.Length; i++)
            {
                sb.AppendLine(string.Format("{0}: {1}", i, Dist[i]));
            }
            sb.AppendLine();

            return sb.ToString();
        }
    }
}
