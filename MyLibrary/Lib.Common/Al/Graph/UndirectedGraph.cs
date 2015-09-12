namespace Lib.Common.Al.Graph
{
    public class UndirectedGraph : GraphBase
    {
        public UndirectedGraph(int v)
            : base(v)
        { }

        public override void AddEdge(char u, char v)
        {
            AddEdge(u, v, 0);
        }

        public override void AddEdge(char u, char v, int weight)
        {
            int nu = GetMappedNumber(u);
            int nv = GetMappedNumber(v);
            Al[nu].AddLast(new Edge { V1 = nu, V2 = nv, Weight = weight });
            Al[nv].AddLast(new Edge { V1 = nv, V2 = nu, Weight = weight });

            _E++;
        }

        public override void AddEdge(int u, int v)
        {
            Al[u].AddLast(new Edge { V1 = u, V2 = v });
            Al[v].AddLast(new Edge { V1 = v, V2 = u });
            _E++;
        }

        public override void AddEdge(Edge e)
        {
            Al[e.V1].AddLast(e);
            Al[e.V2].AddLast(e.ReverseVertices());
            _E++;
        }

        public override void RemoveEdge(Edge e)
        {
            Al[e.V1].Remove(e.V2);
            Al[e.V2].Remove(e.V1);
            _E--;
        }
    }
}