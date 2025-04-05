// See https://aka.ms/new-console-template for more information

using KruskalAlgorithm;

Console.WriteLine("Hello, World!");

GraphFactory graphFactory = new GraphFactory();

Graph graph = GraphFactory.CreateGraph(10,30);

var AdjacencyList = graph.GetAdjacencyList();

foreach (var pair in AdjacencyList)
{
    Console.WriteLine(pair.Key);
    foreach (var valueTuple in pair.Value)
    {
        Console.WriteLine("\t");
        Console.Write($"{valueTuple.Item1.Id} - {valueTuple.Item2}");
    }
}