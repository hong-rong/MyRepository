using Lib.Common.Al.Graph;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Common.Al.Dp
{
    public class LongestIncreasingSequence
    {
        /// <summary>
        /// Give a sequence of number, find the longest increasing subsequence
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public static string GetLongest(int[] numbers)
        {
            //var g = new DirectedGraph(numbers.Length);
            var g = new DirectedGraph(10);
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[i] < numbers[j])
                    {
                        g.AddEdge(numbers[i], numbers[j], 1);
                    }
                }
            }
            
            g.ReverseGraph();
            Debug.WriteLine(g);

            var v = Dfs.GetSource(g);

            var stats = Dijkstra.LongestPath(g, v);

            Debug.WriteLine(stats);

            return string.Empty;
        }
    }
}
