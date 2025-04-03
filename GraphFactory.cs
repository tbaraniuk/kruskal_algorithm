using System;
using KruskalAlgorithm.DataStructures;

namespace KruskalAlgorithm;

public class GraphFactory
{
    public static Graph CreateGraph(int size, float density)
    {
        var graph = new Graph();
        var maxEdges = size * (size - 1) / 2;
        var avgEdgesPerNode = density * maxEdges / 2;
        var radnom = new Random();

        for(var i = 0; i < size; i++)
        {
            var node = new Node(i);

            graph.AddNode(node);
        }

        for(var i = 0; i < size; i++)
        {
            var node = graph.Nodes[i];

            for(var j = 0; j < avgEdgesPerNode; j++)
            {
                var randIndex = radnom.Next(size - 1);
                var node2 = graph.Nodes[randIndex];

                while(randIndex == j || node.GetEdgeWeight(node2) > 0)
                {
                    randIndex = radnom.Next(size - 1);
                }

                var weight = radnom.Next(20);

                node.AddEdge(node2, weight);
            }
        }

        return graph;
    }
}