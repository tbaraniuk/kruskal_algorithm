using System;
using KruskalAlgorithm.DataStructures;

namespace KruskalAlgorithm;

public class Graph
{
    public List<Node> Nodes;
    public List<(Node, Node, int)> Edges;

    public Graph()
    {
        Nodes = new List<Node>();
        Edges = new List<(Node, Node, int)>();
    }

    public void AddNode(Node node)
    {
        Nodes.Add(node);
    }

    public void AddEdge(Node node1, Node node2, int weight)
    {
        if (node1.Id == node2.Id)
        {
            throw new ArgumentException("The vertex can not be adjacent to itself");
        }

        node1.AdjacencySet.Add((node2, weight));
        node2.AdjacencySet.Add((node1, weight));

        Edges.Add((node1, node2, weight));
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

    public bool IsConnected()
    {
        var visitedPoints = new HashSet<Node>();
        var nodesToVisit = new Queue<Node>();

        nodesToVisit.Enqueue(Nodes[0]);

        while(nodesToVisit.Count > 0)
        {
            var node = nodesToVisit.Dequeue();

            if (visitedPoints.Contains(node))
            {
                continue;
            }

            foreach(var item in node.AdjacencySet)
            {
                nodesToVisit.Enqueue(item.Item1);
            }

            visitedPoints.Add(node);
        }

        return visitedPoints.Count == Nodes.Count;
    }
}
