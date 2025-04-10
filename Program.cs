using System.Diagnostics;
using KruskalAlgorithm;

Stopwatch graphCreate = new Stopwatch();
graphCreate.Start();
Graph graph = GraphFactory.CreateGraph(100, 3);
graphCreate.Stop();

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

Stopwatch algorhytmTime = new Stopwatch();
algorhytmTime.Start();
var mintree = KruskalsAlgorithm.MinimumSpanningTreeOnAdjacencyList(graph);
Console.WriteLine($"Minimum spanning tree on list is  {mintree.Item1}");
var mintreeonmatrix = KruskalsAlgorithm.MinimumSpanningTreeOnAdjacencyMatrix(graph);
Console.WriteLine($"Minimum spanning tree on matrix is  {mintreeonmatrix.Item1}");
Console.WriteLine($"Minimum spanning tree is  {mintree.Item1}");
algorhytmTime.Stop();


var AdjacencyListmin = mintree.Item2.GetAdjacencyList();
var AdjacencyListMimOnMatrix = mintreeonmatrix.Item2.GetAdjacencyList();


Console.WriteLine("Adjacency list from MinimumSpanningTreeOnAdjacencyList");
foreach (var pair in AdjacencyListmin)
{
    Console.WriteLine(pair.Key.Id);
    foreach (var valueTuple in pair.Value)
    {
        Console.Write($"{valueTuple.Item1.Id} - {valueTuple.Item2}\n");
    }
    Console.WriteLine("\n");
}

Console.WriteLine("Adjacency list from MinimumSpanningTreeOnAdjacencyMatrix");
foreach (var pair in AdjacencyListMimOnMatrix)
{
    Console.WriteLine(pair.Key.Id);
    foreach (var valueTuple in pair.Value)
    {
        Console.Write($"{valueTuple.Item1.Id} - {valueTuple.Item2}\n");
    }
    Console.WriteLine("\n");
}
   

Console.WriteLine($"Graph was creating for {graphCreate.ElapsedMilliseconds} mls");
Console.WriteLine($"Kruskal algorhytm took {algorhytmTime.ElapsedMilliseconds} mls");
