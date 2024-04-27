using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GraphImplementation
{
    internal class GraphDemo
    {
        // vertices or nodes
        private int v;

        // Marked Visited
        private int[]? visited;

        // adjancey matrix
        private int[,]? graph;

        // Intialization graph using number of nodes 
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

        // Reset the Graph visited after every operation
        public void ResetVisited()
        {
            for(int i = 0;i < v; i++) visited[i] = 0;
        }

        public void BFS(int source)
        {
            int[] arr = new int[v];   
            int front = 0, rear = -1;
            visited[source] = 1;
            arr[++rear] = source; 
            while (front <= rear)
            {
                int element = arr[front++];
                Console.Write($"v{element} ");
                for (int i=0; i < v; i++)
                {
                    if (graph[element,i] == 1 && visited[i] != 1)
                    {
                        visited[i] = 1;
                        arr[++rear] = i;
                    }
                }

            }
            Console.WriteLine();
            ResetVisited();
        }

        public bool DFS_Search(int source,int key)
        {
            if (source == key)
                return true;
            else
            {
                visited[source] = 1;
                for (int i = 0; i < v; i++)
                {
                    if (graph[source,i] == 1 && visited[i] != 1)//neighbour and unvisited
                    {
                        DFS_Search(i, key);
                    }
                }
                return false;
            }
        }

        public void DFS(int source)
        {
            visited[source] = 1;
            Console.Write("v" + source+" ");
            for (int i = 0; i < v; i++)
            {
                if (graph[source,i]==1 && visited[i]!=1)
                {
                    DFS(i);
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
