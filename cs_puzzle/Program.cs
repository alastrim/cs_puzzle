using System;

namespace cs_puzzle
{
    class Program
    {
        static int ReadInt()
        {
            var s = Console.ReadLine();
            return Convert.ToInt32(s);
        }

        static void Main(string[] args)
        {
            int V = ReadInt();
            int E = ReadInt();
            var g = new Graph(V);
            for (int i = 0; i < E; i++)
            {
                int u = ReadInt();
                int v = ReadInt();
                g.AddEdge(u, v);
            }

            int s = ReadInt();
            int t = ReadInt();

            var bfs = new BFS(g);
            Console.WriteLine("Path from {0} to {1} {2}", s, t, (bfs.FindPath(s, t) ? "found" : "not found"));
            //string.Format("Path from {0} to {1} {2}", s, t, (BFS(g, s, t) ? "found" : "not found"));
        }
    }
}
