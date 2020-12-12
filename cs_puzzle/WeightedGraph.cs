using System;
using System.Collections.Generic;
using System.Text;

namespace cs_puzzle
{
    class WeightedGraph
    {
        public int V { get; }
        public int E { get; private set; }

        List<List<(int, double)>> _edges;

        public WeightedGraph(int V)
        {
            this.V = V;
            _edges = new List<List<(int, double)>>();
            for (int i = 0; i < V; i++)
                _edges.Add(new List<(int, double)>());
        }

        public void AddEdge(int u, int v, double w)
        {
            if (u < 0 || u >= V)
                throw new ArgumentException("u out of bounds");
            if (v < 0 || v >= V)
                throw new ArgumentException("v out of bounds");
            E++;
            _edges[u].Add((v, w));
            _edges[v].Add((u, w));
        }

        public IEnumerable<(int, double)> Neighbours(int u)
        {
            //if (u < 0 || u >= V)
            //    throw new ArgumentException("u out of bounds");
            return _edges[u];
        }
    }
}
