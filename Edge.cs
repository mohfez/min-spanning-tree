public class Edge<T>
{
    public T vert1, vert2;
    public int weight;

    public Edge(T vert1, T vert2, int weight)
    {
        this.vert1 = vert1;
        this.vert2 = vert2;
        this.weight = weight;
    }
}