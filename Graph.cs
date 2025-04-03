using System;
using KruskalAlgorithm.DataStructures;

namespace KruskalAlgorithm;

public class Graph
{
    public List<Node> Nodes;

    public Graph()
    {
        Nodes = new List<Node>();
    }

    public void AddNode(Node node)
    {
        Nodes.Add(node);
    }

    public int[,] GetAdjacencyMatrix()
    {
        var matrix = new int[Nodes.Count, Nodes.Count];

        for(var i = 0; i < Nodes.Count; i++)
        {
            var currentNode = Nodes[0];
            var adjacentVertices = currentNode.GetAdjacentVertices();

            foreach(var (node, weight) in adjacentVertices)
            {
                var index = Nodes.FindIndex(n => n.Id == node.Id);

                matrix[i, index] = weight;
            }
        }

        return matrix;
    }

    public Dictionary<Node, List<(Node, int)>> GetAdjacencyList()
    {
        var dict = new Dictionary<Node, List<(Node, int)>>();

        foreach(var node in Nodes)
        {
            dict.Add(node, new List<(Node, int)>());

            foreach(var (item, weight) in node.GetAdjacentVertices())
            {
                dict[node].Add((item, weight));
            }
        }

        return dict;
    }
}
