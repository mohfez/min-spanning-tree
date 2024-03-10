# Minimum Spanning Tree Algorithms
Simple implementation of two algorithms (Kruskal's Algorithm and Prim's Algorithm) to find the minimum spanning tree.

## Kruskal's Algorithm
Kruskal's Algorithm is implemented in the `Kruskal` method.

### Example
```c#
Console.WriteLine("--- Kruskal's algorithm ---");
Edge<int>[] kruskal = MinimumSpanningTree<int>.Kruskal(edges);
foreach (Edge<int> edge in kruskal) Console.WriteLine($"Edge {edge.vert1}->{edge.vert2} weight: {edge.weight}");
Console.WriteLine("Total weight: " + MinimumSpanningTree<int>.GetTotalWeight(kruskal));
```

## Prim's Algorithm
Prim's Algorithm is implemented in the `Prim` method:

### Example
```c#
Console.WriteLine("--- Prim's algorithm ---");
Edge<int>[] prim = MinimumSpanningTree<int>.Prim(edges, 1);
foreach (Edge<int> edge in prim) Console.WriteLine($"Edge {edge.vert1}->{edge.vert2} weight: {edge.weight}");
Console.WriteLine("Total weight: " + MinimumSpanningTree<int>.GetTotalWeight(prim));
```