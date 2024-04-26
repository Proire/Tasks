using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GraphImplementation
{
    internal class GraphDemo
    {
        private int v;
        private int[]? visited;
        private int[,]? graph;

        public void CreateGraph(int nodes)
        {
            v = nodes;
            visited = new int[v];  
            graph = new int[v,v];
            for (int i = 0; i < v; i++)
            {
                for (int j = 0; j < v; j++)
                {
                    Console.WriteLine($"Enter 1(edge) or 0(not edge) for v{i} to v{j}");
                    _ = int.TryParse(Console.ReadLine(), out graph[i, j]);
                }
            }
        }

        public void BFS(int source)
        {
            int[] arr = new int[v];   
            int front = 0, rear = -1;
            visited[source] = 1;
            int count = 0;
            arr[++rear] = source; 
            while (front <= rear)
            {
                int element = arr[front++];
                count++;
                if (count != v)
                    Console.Write($"v{element} - ");
                else
                    Console.WriteLine($"v{element}");
                for(int i=0; i < v; i++)
                {
                    if (graph[element,i] == 1 && visited[i] != 1)
                    {
                        visited[i] = 1;
                        arr[++rear] = i;
                    }
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
            Console.WriteLine() ;
        }
    }
}
