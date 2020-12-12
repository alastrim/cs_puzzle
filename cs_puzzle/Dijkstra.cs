using Priority_Queue;
using System;
using System.Collections.Generic;
using System.Text;

namespace cs_puzzle
{
    class Dijkstra
    {
        public WeightedGraph G { get; }

        public Dijkstra(WeightedGraph g)
        {
            G = g;
        }

        public double FindPath(int s, int t)
        {
            if (s == t)
                return 0;

            ;
            var queue = new SimplePriorityQueue<(int, double), double>();
            var visited = new double[G.V];
            for (int i = 0; i < G.V; i++)
                visited[i] = double.MaxValue;

            visited[s] = 0;
            queue.Enqueue((s, 0), 0);

            while (queue.Count > 0)
            {
                (int u, double l) = queue.Dequeue();
                if (visited[u] < l)
                    continue;

                foreach ((int v, double w) in G.Neighbours(u))
                {
                    if (v == t)
                        return l + w;

                    if (l + w < visited[v])
                    {
                        visited[v] = l + w;
                        queue.Enqueue((v, l+w), l+w);
                    }
                }
            }

            return double.MaxValue;
        }
    }
}
