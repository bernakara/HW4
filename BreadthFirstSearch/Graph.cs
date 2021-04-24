
// C# program to print BFS traversal
// from a given source vertex.
// BFS(int s) traverses vertices
// reachable from s.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BreadthFirstSearch
{
    public class Graph
    {
        // No. of vertices    
        private int _V;

        //static array 
        public  int[] array=new int [100];
        //Adjacency Lists
        public LinkedList<int>[] _adj;

        public Graph(int V)
        {
            _adj = new LinkedList<int>[V];
            for (int i = 0; i < _adj.Length; i++)
            {
                _adj[i] = new LinkedList<int>();
            }
            _V = V;
        }

        // Function to add an edge into the graph
        public void AddEdge(int v, int w)
        {
            _adj[v].AddLast(w);

        }

        // Prints BFS traversal from a given source s
        public int BFS(int s)
        {

            // Mark all the vertices as not
            // visited(By default set as false)
            bool[] visited = new bool[_V];
            for (int i = 0; i < _V; i++)
                visited[i] = false;

            // Create a queue for BFS

            LinkedList<int> queue = new LinkedList<int>();

            // Mark the current node as
            // visited and enqueue it
            visited[s] = true;
            queue.AddLast(s);
              int m = 0;
            while (queue.Any())
            {

                // Dequeue a vertex from queue
                // and print it

                //transferred the results to array array[]
                s = queue.First();
                 array[m] = s;
                  m++;
                Console.Write(s + " ");
                queue.RemoveFirst();

                // Get all adjacent vertices of the
                // dequeued vertex s. If a adjacent
                // has not been visited, then mark it
                // visited and enqueue it
                LinkedList<int> list = _adj[s];

                foreach (var val in list)
                {
                    if (!visited[val])
                    {
                        visited[val] = true;
                        queue.AddLast(val);
                    }
                }
            }

            //return statıc array
            return array[m];
        }





    }
}
