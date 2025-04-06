using System;
using KruskalAlgorithm.DataStructures;

namespace KruskalAlgorithm;

public class GraphFactory
{
    public static Graph CreateGraph(int size, double density)
    {
        var graph = new Graph();
        var maxEdges = size * (size - 1) / 2;
        var avgEdgesPerNode = density * maxEdges / 2;
        var random = new Random();

        for(var i = 0; i < size; i++)
        {
            var node = new Node(i);

            graph.AddNode(node);
        }


        for(var j = 0; j < avgEdgesPerNode; j++)
        {
            var randIndex = random.Next(size);
            var randIndex2 = random.Next(size);

            var node = graph.Nodes[randIndex];
            var node2 = graph.Nodes[randIndex2];

            while(randIndex2 == randIndex || node.GetEdgeWeight(node2) > 0)
            {
                randIndex = random.Next(size);
                randIndex2 = random.Next(size);

                node = graph.Nodes[randIndex];
                node2 = graph.Nodes[randIndex2];
            }

            var weight = random.Next(1, 5);

            graph.AddEdge(node, node2, weight);
        }

        return graph;
    }
}