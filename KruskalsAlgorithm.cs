using KruskalAlgorithm.DataStructures;

namespace KruskalAlgorithm;

public class KruskalsAlgorithm
{
    public static int MinimumSpanningTreeOnAdjacencyList(Graph graph)
    {
        var AdjacencyList = graph.GetAdjacencyList();
        var AllNodes = AdjacencyList.Select(x => x.Key).ToHashSet();
        int weightOfMinimumSpanningTree = 0;
        Graph MinimumSpanningTreeAsGraph = new Graph();
        Dictionary<(Node, Node), int> TableOfEdges = new Dictionary<(Node, Node), int>();
        PriorityQueue<(Node, Node), int> priorityQueue = new PriorityQueue<(Node, Node), int>();
        Dictionary<int, int> LabelTable = new Dictionary<int, int>();
        foreach (var pair in AdjacencyList)
        {
            foreach (var nodeValueTuple in pair.Value)
            {
                TableOfEdges[(pair.Key, nodeValueTuple.Item1)] = nodeValueTuple.Item2;
            }
        }

        foreach (var valueTuple in TableOfEdges.OrderBy(x => x.Value))
        {
            priorityQueue.Enqueue(valueTuple.Key,valueTuple.Value); // Push in this case O(1) because we have a sorted dictionary
        }
        foreach (var node in AllNodes)
        {
            MinimumSpanningTreeAsGraph.AddNode(node);
            LabelTable[node.Id] = node.Id;
        }
        
        HashSet<Node> NodesUsedInMinGrap = new HashSet<Node>();

        while (!AllNodes.Equals(NodesUsedInMinGrap))
        {
            var EdgeFromQueue = priorityQueue.Dequeue();
            if (LabelTable[EdgeFromQueue.Item1.Id] != LabelTable[EdgeFromQueue.Item2.Id])
            {
                int OldLabel = LabelTable[EdgeFromQueue.Item1.Id];
                int NewLabel = LabelTable[EdgeFromQueue.Item2.Id];
                foreach (var pair in LabelTable)
                {
                    if (pair.Value == OldLabel)
                    {
                        LabelTable[pair.Key] = NewLabel;
                    }
                }

                weightOfMinimumSpanningTree = weightOfMinimumSpanningTree +
                                              TableOfEdges[(EdgeFromQueue.Item1, EdgeFromQueue.Item2)];
                NodesUsedInMinGrap.Add(EdgeFromQueue.Item1);
                NodesUsedInMinGrap.Add(EdgeFromQueue.Item2);
            }
        }

        return weightOfMinimumSpanningTree;

    }

    /*public static int MinimumSpanningTreeOnAdjacencyListAdjacencyMatrix(Graph graph)
    {
        
    }*/
    
    //public static (int Minimumweight, int[,]) 
}