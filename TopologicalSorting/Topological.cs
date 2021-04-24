using System;
// A C# program to print topological
// sorting of a DAG
using System.Collections.Generic;

namespace TopologicalSorting
{
    public class Topological
    {
        // No. of vertices
        private int V;

        // Adjacency List as ArrayList
        // of ArrayList's
        private List<List<int>> adj;
        public object Top;

        // Constructor
        public Topological(int v)
        {
            V = v;
            adj = new List<List<int>>(v);
            for (int i = 0; i < v; i++)
                adj.Add(new List<int>());
        }

        // Function to add an edge into the graph
        public int AddEdge(int v, int w)
        {

            adj[v].Add(w);
            return 0;
        }

        // A recursive function used by topologicalSort
        public int TopologicalSortUtil(int v, bool[] visited,
                                   Stack<int> stack)
        {

            // Mark the current node as visited.
            visited[v] = true;

            // Recur for all the vertices
            // adjacent to this vertex
            foreach (var vertex in adj[v])
            {
                if (!visited[vertex])
                    TopologicalSortUtil(vertex, visited, stack);
            }

            // Push current vertex to
            // stack which stores result
            stack.Push(v);
            return 0;
        }

        // The function to do Topological Sort.
        // It uses recursive topologicalSortUtil()
        public int i = 0;
        public int[] top = new int[100];
        public int TopologicalSort()
        {
            ;
            Stack<int> stack = new Stack<int>();

            // Mark all the vertices as not visited
            var visited = new bool[V];

            // Call the recursive helper function
            // to store Topological Sort starting
            // from all vertices one by one
            for (int i = 0; i < V; i++)
            {
                if (visited[i] == false)
                    TopologicalSortUtil(i, visited, stack);
            }

            // Print contents of stack
            foreach (var vertex in stack)
            {
                Console.Write(vertex + " ");

                top[i] = vertex;
                i++;
            }

            return 0;
        }



    }
}
