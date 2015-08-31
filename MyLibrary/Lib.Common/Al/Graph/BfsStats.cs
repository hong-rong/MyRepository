using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Common.Al.Graph
{
    /// <summary>
    /// Breadth-first search statistics
    /// </summary>
    public class BfsStats
    {
        private readonly int[] _dist;

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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
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