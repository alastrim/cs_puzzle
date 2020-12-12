using System;
using System.Collections.Generic;
using System.Text;

namespace cs_puzzle
{
    class Graph
    {
        public int V { get; }
        public int E { get; private set; }

        List<List<int>> _edges;

        public Graph(int V)
        {
            this.V = V;
            _edges = new List<List<int>>();
            for (int i = 0; i < V; i++)
                _edges.Add(new List<int>());
        }

        public void AddEdge(int u, int v)
        {
            if (u < 0 || u >= V)
                throw new ArgumentException("u out of bounds");
            if (v < 0 || v >= V)
                throw new ArgumentException("v out of bounds");
            E++;
            _edges[u].Add(v);
            _edges[v].Add(u);
        }

        public IEnumerable<int> Neighbours(int u)
        {
            //if (u < 0 || u >= V)
            //    throw new ArgumentException("u out of bounds");
            return _edges[u];
        }
    }
}
