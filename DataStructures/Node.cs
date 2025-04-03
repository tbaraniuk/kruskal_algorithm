using System;

namespace KruskalAlgorithm.DataStructures;

public class Node
{
    public readonly int Id;
    private readonly HashSet<(Node, int)> AdjacencySet;

    public Node(int id)
    {
        Id = id;
        AdjacencySet = new HashSet<(Node, int)>();
    }

    public void AddEdge(Node node, int weight)
    {
        if (Id == node.Id)
        {
            throw new ArgumentException("The vertex can not be adjacent to itself");
        }

        node.AdjacencySet.Add((this, weight));
        AdjacencySet.Add((node, weight));
    }

    public int GetEdgeWeight(Node node) {
        var edge = AdjacencySet.First(tup => tup.Item1.Id == node.Id);

        return edge.Item2;
    }

    public HashSet<(Node, int)> GetAdjacentVertices()
    {
        return AdjacencySet;
    }
}
