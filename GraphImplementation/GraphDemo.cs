using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphImplementation
{
    internal class GraphDemo
    {
        private int v;
        private int[,]? graph;

        public void CreateGraph(int nodes)
        {
            v = nodes;
            graph = new int[v,v];
            for (int i = 0; i < v; i++)
            {
                for (int j = 0; j < v; j++)
                {
                    Console.WriteLine($"Enter the value for v{i} to v{j} (999) for infinity");
                    _ = int.TryParse(Console.ReadLine(), out graph[i, j]);
                }
            }
        }

        public void PrintGraph()
        {
            if (graph != null)
            {
                Console.WriteLine("\nGraph Representation : \n");
                for (int i = 0; i < v; i++)
                {
                    for (int j = 0; j < v; j++)
                    {
                        Console.Write($"{graph[i, j]} \t");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
