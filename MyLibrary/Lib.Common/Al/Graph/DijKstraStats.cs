using System;

namespace Lib.Common.Al.Graph
{
    /// <summary>
    /// Vertice distance for Dijkstra's algorithm in priority queue
    /// </summary>
    public class Distance : IComparable<Distance>
    {
        public int Vertice { get; set; }
        public int Dist { get; set; }

        public int CompareTo(Distance other)
        {
            return Dist.CompareTo(other.Dist);
        }
    }

    public class DijKstraStats
    {
        //distance for each vertice from a start vertice
        private readonly int[] _dist;

        //previous vertice for each vertice
        private readonly int[] _prev;

        public DijKstraStats(int V)
        {
            _dist = new int[V];
            for (var i = 0; i < _dist.Length; i++)
            {
                _dist[i] = int.MaxValue;
            }

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

        public int StartVertice { get; set; }
    }
}
