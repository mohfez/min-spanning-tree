using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string num = "1234567890";

        // set up edges
        Edge<int>[] edges = File.ReadAllLines("./graphs/graph.txt").Select(edge =>
        {
            int[] verts = edge.Split(" ").Select(int.Parse).ToArray();
            return new Edge<int>(verts[0], verts[1], Math.Abs(Convert.ToInt32(num[verts[0] - 1]) - Convert.ToInt32(num[verts[1] - 1])));
        }).ToArray();

        /*
        Edge<char>[] edges =
        {
            new Edge<char>('a', 'b', 4),
            new Edge<char>('b', 'c', 8),
            new Edge<char>('c', 'd', 7),
            new Edge<char>('d', 'e', 9),
            new Edge<char>('e', 'f', 10),
            new Edge<char>('f', 'g', 2),
            new Edge<char>('g', 'h', 1),
            new Edge<char>('h', 'a', 8),
            new Edge<char>('b', 'h', 11),
            new Edge<char>('c', 'i', 2),
            new Edge<char>('i', 'h', 7),
            new Edge<char>('i', 'g', 6),
            new Edge<char>('c', 'f', 4),
            new Edge<char>('d', 'f', 14)
        };
        */

        // list edges with weight before applying any algo
        foreach (Edge<int> edge in edges) Console.WriteLine($"Edge {edge.vert1}->{edge.vert2} weight: {edge.weight}");

        // apply kruskal algo
        Console.WriteLine("--- Kruskal's algorithm ---");
        Edge<int>[] kruskal = MinimumSpanningTree<int>.Kruskal(edges);
        foreach (Edge<int> edge in kruskal) Console.WriteLine($"Edge {edge.vert1}->{edge.vert2} weight: {edge.weight}");
        Console.WriteLine("Total weight: " + MinimumSpanningTree<int>.GetTotalWeight(kruskal));

        // apply prim algo
        Console.WriteLine("--- Prim's algorithm ---");
        Edge<int>[] prim = MinimumSpanningTree<int>.Prim(edges, 1);
        foreach (Edge<int> edge in prim) Console.WriteLine($"Edge {edge.vert1}->{edge.vert2} weight: {edge.weight}");
        Console.WriteLine("Total weight: " + MinimumSpanningTree<int>.GetTotalWeight(prim));
    }
}