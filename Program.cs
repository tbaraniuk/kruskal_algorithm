using KruskalAlgorithm;

Graph graph = GraphFactory.CreateGraph(10, 0.2);

Console.WriteLine("Graph info:");
Console.WriteLine($"It is {(graph.IsConnected() ? "" : "not")} connected\n");

var AdjacencyList = graph.GetAdjacencyList();

foreach (var pair in AdjacencyList)
{
    Console.WriteLine(pair.Key.Id);
    foreach (var valueTuple in pair.Value)
    {
        Console.Write($"{valueTuple.Item1.Id} - {valueTuple.Item2}\n");
    }
    Console.WriteLine("\n");
}