using KruskalAlgorithm;

Graph graph = GraphFactory.CreateGraph(7, 0.5);

while (!graph.IsConnected())
{
    graph = GraphFactory.CreateGraph(7, 0.5);
}

var AdjacencyList = graph.GetAdjacencyList();
var AdjacencyMatrix = graph.GetAdjacencyMatrix();

for (int i = 0; i < AdjacencyMatrix.GetLength(0); i++)
{
    for (int j = 0; j < AdjacencyMatrix.GetLength(1); j++)
    {
        Console.Write(AdjacencyMatrix[i,j]);
    }
    Console.WriteLine();
}

foreach (var pair in AdjacencyList)
{
    Console.WriteLine(pair.Key.Id);
    foreach (var valueTuple in pair.Value)
    {
        Console.Write($"{valueTuple.Item1.Id} - {valueTuple.Item2}\n");
    }
    Console.WriteLine("\n");
}

var mintree = KruskalsAlgorithm.MinimumSpanningTreeOnAdjacencyList(graph);
Console.WriteLine($"Minimum spanning tree is  {mintree.Item1}");


var AdjacencyListmin = mintree.Item2.GetAdjacencyList();

foreach (var pair in AdjacencyListmin)
{
    Console.WriteLine(pair.Key.Id);
    foreach (var valueTuple in pair.Value)
    {
        Console.Write($"{valueTuple.Item1.Id} - {valueTuple.Item2}\n");
    }
    Console.WriteLine("\n");
}