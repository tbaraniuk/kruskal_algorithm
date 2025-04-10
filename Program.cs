using System.Diagnostics;
using System.Text;
using KruskalAlgorithm;

Stopwatch graphCreate = new Stopwatch();
graphCreate.Start();
Graph graph = GraphFactory.CreateGraph(1000, 1);
graphCreate.Stop();

while (!graph.IsConnected())
{
    graph = GraphFactory.CreateGraph(1000, 1);
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
var mintreeonmatrix = KruskalsAlgorithm.MinimumSpanningTreeOnAdjacencyMatrix(graph);
Console.WriteLine($"Minimum spanning tree on matrix is  {mintreeonmatrix.Item1}");
var mintree = KruskalsAlgorithm.MinimumSpanningTreeOnAdjacencyList(graph);
Console.WriteLine($"Minimum spanning tree on list is  {mintree.Item1}");
algorhytmTime.Stop();
Console.WriteLine($"Minimum spanning tree is  {mintree.Item1}");


var AdjacencyListMimOnMatrix = mintreeonmatrix.Item2.GetAdjacencyList();
var AdjacencyListmin = mintree.Item2.GetAdjacencyList();

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
/*
string projectRoot = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
string filePath = Path.Combine(projectRoot, "dataMatrix.csv");
StringBuilder csvContent = new StringBuilder();
StringBuilder numbers = new StringBuilder();
for( int i = 0; i < 100; i++)
{
    numbers.Append($"№{i + 1},");
}
csvContent.AppendLine($"Size,Density,{numbers.ToString()}Average");
for (int verticeNumber = 20;verticeNumber <= 200; verticeNumber += 20 ) 
{
    for (double density = 0.2; density <= 1; density += 0.2)
    {
        StringBuilder times = new StringBuilder();
        
        for (int i = 0; i < 100; i++)
        {
            Graph graph = GraphFactory.CreateGraph(verticeNumber, density);
            while (!graph.IsConnected())
            {
                graph = GraphFactory.CreateGraph(verticeNumber, density);
            }
            Stopwatch algorhytmTime = new Stopwatch();
            algorhytmTime.Start();
            var mintree = KruskalsAlgorithm.MinimumSpanningTreeOnAdjacencyMatrix(graph);
            algorhytmTime.Stop();
            var elapsedTime = Math.Round(algorhytmTime.Elapsed.TotalMilliseconds, 2);
            times.Append((elapsedTime).ToString().Replace(",", ".") + ",");
            Console.WriteLine(elapsedTime+ "mls");
        }

        var average = times.ToString().Split(",").Take(20).Select(x => decimal.Parse(x.Replace(".", ","))).Average(x => x).ToString().Replace(",", ".");
        
        csvContent.AppendLine($"{verticeNumber},{Math.Round(density, 1).ToString().Replace(",", ".")},"+ times.ToString()+ average);
    }
}
File.WriteAllText(filePath, csvContent.ToString());
*/