using System;
using System.Linq;
using System.Collections.Generic;

public static class MinimumSpanningTree<T> where T : IComparable<T>
{
    /// <summary>
    /// Apply Kruskal's algorithm to an array of edges.
    /// </summary>
    public static Edge<T>[] Kruskal(Edge<T>[] edges)
    {
        Dictionary<T, T> verts = new Dictionary<T, T>();

        // find the root of a vertex (used for cycle checking)
        T FindRoot(T vertex) => verts.TryGetValue(vertex, out T? root) && root != null && !root.Equals(vertex) ? (verts[vertex] = FindRoot(root)) : vertex;
        
        // sort by weight & check if any cycles occur
        return edges.OrderBy(edge => edge.weight).Where(edge => !FindRoot(edge.vert1).Equals(FindRoot(edge.vert2)))
               .Select(edge =>
               {
                   verts[FindRoot(edge.vert1)] = FindRoot(edge.vert2);
                   return edge;
               }).ToArray(); // return minimum spanning tree
    }

    /// <summary>
    /// Apply Prim's algorithm to an array of edges.
    /// </summary>
    /// <remarks>
    /// Needs a starting vertex.
    /// </remarks>
    public static Edge<T>[] Prim(Edge<T>[] edges, T start)
    {
        HashSet<T> visitedVertices = new HashSet<T>();
        List<Edge<T>> graph = new List<Edge<T>>();
        
        visitedVertices.Add(start);
        int numVerts = edges.SelectMany(edge => new[] { edge.vert1, edge.vert2 }).Distinct().Count();
        while (visitedVertices.Count < numVerts)
        {
            // find the next min weight
            Edge<T> minEdge = edges.Where(edge => (visitedVertices.Contains(edge.vert1) && !visitedVertices.Contains(edge.vert2)) || (visitedVertices.Contains(edge.vert2) && !visitedVertices.Contains(edge.vert1))).OrderBy(edge => edge.weight).First();

            // add the min weighted edge to the graph result
            graph.Add(minEdge);

            // mark verts as visited
            visitedVertices.Add(minEdge.vert1);
            visitedVertices.Add(minEdge.vert2);
        }

        // return minimum spanning tree
        return graph.ToArray();
    }

    /// <summary>
    /// Get the total weight of an array of edges.
    /// </summary>
    public static int GetTotalWeight(Edge<T>[] edges) => edges.Sum(edge => edge.weight);
}