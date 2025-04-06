using KruskalAlgorithm.DataStructures;

namespace KruskalAlgorithm;

public class KruskalsAlgorithm
{
    public static (int, Graph) MinimumSpanningTreeOnAdjacencyList(Graph graph)
    {
        var AdjacencyList = graph.GetAdjacencyList();
        var AllNodes = AdjacencyList.Select(x => x.Key).ToHashSet();
        int weightOfMinimumSpanningTree = 0;
        int EndgesInMinimumSpanningTree = 0;
        int NodesInInputGraph = AllNodes.Count;
        Graph MinimumSpanningTreeAsGraph = new Graph();
        Dictionary<(Node, Node), int> TableOfEdges = new Dictionary<(Node, Node), int>();
        Dictionary<int, int> LabelTable = new Dictionary<int, int>();
        foreach (var pair in AdjacencyList)
        {
            foreach (var nodeValueTuple in pair.Value)
            {
                TableOfEdges[(pair.Key, nodeValueTuple.Item1)] = nodeValueTuple.Item2;
            }
        }
        foreach (var node in AllNodes)
        {
            MinimumSpanningTreeAsGraph.AddNode(node);
            LabelTable[node.Id] = node.Id;
        }
        
        foreach (var Edge in TableOfEdges.OrderBy(x => x.Value))
        {
            if (EndgesInMinimumSpanningTree == NodesInInputGraph -1)
            {
                break;
            }
            
            if (LabelTable[Edge.Key.Item1.Id] != LabelTable[Edge.Key.Item2.Id])
            {
                int OldLabel = LabelTable[Edge.Key.Item1.Id];
                int NewLabel = LabelTable[Edge.Key.Item2.Id];
                
                foreach (var pair in LabelTable)
                {
                    if (pair.Value == OldLabel)
                    {
                        LabelTable[pair.Key] = NewLabel;
                    }
                }

                weightOfMinimumSpanningTree = weightOfMinimumSpanningTree + Edge.Value;
                MinimumSpanningTreeAsGraph.AddEdge(Edge.Key.Item1,Edge.Key.Item2,Edge.Value);
                EndgesInMinimumSpanningTree++;
            }
            
        }
        return (weightOfMinimumSpanningTree,MinimumSpanningTreeAsGraph);
    }

    /*public static (int,Graph) MinimumSpanningTreeOnAdjacencyMatrix(Graph graph)
    {
        var adjacencyMatrix = graph.GetAdjacencyMatrix();
        
    }*/
    
    
}