using System.Diagnostics.Tracing;

namespace GraphImplementation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome the Graph Implementation!");
            
            // Instantiate Graph 
            GraphDemo graph = new GraphDemo();

            // size of Graph or number of nodes input from User
            int nodes;
            Console.Write("Enter the size of the graph : ");
            _ = int.TryParse(Console.ReadLine(), out nodes);

            graph.CreateGraph(nodes);

            // print the graph 
            graph.PrintGraph();

            // Breadth First Search
            int source;
            Console.Write("Enter the Starting Vertice : ");
            _ = int.TryParse(Console.ReadLine(), out source);
            graph.BFS(source);

            // visited reseted 
            graph.ResetVisited();

            // Depth first Search
            graph.DFS(source);

            // visited reseted 
            graph.ResetVisited();

            // depth first search used for searching of key
            int key;
            Console.Write("\nEnter the Key to be found : ");
            _ = int.TryParse(Console.ReadLine(), out key);
            bool ispresent = graph.DFS_Search(source, key);
            if(ispresent) { Console.WriteLine("Key is found in graph");}
            else { Console.WriteLine("Key is not found in graph"); }

        }
    }
}
