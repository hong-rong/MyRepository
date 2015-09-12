using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Common.Al.Graph
{
    public class GeneralGraphShortestPath
    {
        public static ShortestPathStats ShortestPath(GraphBase g, int s)
        {
            #region Initialization
            var ss = new ShortestPathStats(g.V);
            for (int i = 0; i < ss.Dist.Length; i++)
            {
                ss.Dist[i] = int.MaxValue;
                ss.Prev[i] = -1;
            }
            ss.Dist[0] = 0;
            #endregion

            for (int u = 0; u < g.V; u++)
            {
                foreach (var e in g.Adjacent(u))
                {
                    if (ss.Dist[e.V2] > ss.Dist[e.V2] + ss.Dist[u])
                    {
                        ss.Dist[e.V2] = ss.Dist[e.V2] + ss.Dist[u];
                        ss.Prev[e.V2] = u;
                    }
                }
            }

            return ss;
        }
    }
}
