using System;

namespace KruskalAlgorithm.DataStructures;

public class Node
{
    public readonly int Id;
    public readonly HashSet<(Node, int)> AdjacencySet;

    public Node(int id)
    {
        Id = id;
        AdjacencySet = new HashSet<(Node, int)>();
    }

    public int GetEdgeWeight(Node node) {
        var edge = AdjacencySet.FirstOrDefault(tup => tup.Item1.Id == node.Id);

        if(edge.Item1 == null)
        {
            return 0;
        }

        return edge.Item2;
    }

    public HashSet<(Node, int)> GetAdjacentVertices()
    {
        return AdjacencySet;
    }
}
