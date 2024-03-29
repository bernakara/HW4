﻿using System;
using System.Collections.Generic;
using System.Linq;
namespace StronglyConnectedComponents
{
    public class StronglyConnectedComponent
    {
        private int _verticesCount;
        private List<int>[] _vertexAdjancedVertices; // i-th element contains info about all adjanced vertices of vertex #i

        public StronglyConnectedComponent(int[,] edges)
        {
            _verticesCount = edges.Cast<int>().Max() + 1;
            _vertexAdjancedVertices = new List<int>[_verticesCount];
            for (int i = 0; i < _verticesCount; ++i)
                _vertexAdjancedVertices[i] = new List<int>();

            for (int i = 0; i < edges.GetLength(0); ++i)
                AddDirectedEdge(edges[i, 0], edges[i, 1]);
        }

        public void AddEdge(int vertex1, int vertex2, bool directed = false)
        {
            AddDirectedEdge(vertex1, vertex2);
            if (!directed)
                AddDirectedEdge(vertex2, vertex1);
        }

        public void AddDirectedEdge(int vertex1, int vertex2)
        {
            _vertexAdjancedVertices[vertex1].Add(vertex2);
        }

        public List<List<int>> GetStronglyConnectedComponents()
        {
            //DFS
            var processed = new bool[_verticesCount];
            var minConnectedValue = new int[_verticesCount];
            var sccCompleted = new bool[_verticesCount];
            int currentTime = 0;

            for (int startingVertex = 0; startingVertex < _verticesCount; ++startingVertex)
                if (!processed[startingVertex])
                    GetStronglyConnectedComponents(startingVertex, ref currentTime, processed, minConnectedValue, sccCompleted);

            var res = minConnectedValue.Select((mcv, i) => new { Vertex = i, MinConnectedValue = mcv })
                .GroupBy(vmcv => vmcv.MinConnectedValue)
                .Select(g => g.Select(vmcv => vmcv.Vertex).ToList()).ToList();
            return res;
        }

        private void GetStronglyConnectedComponents(int vertex, ref int currentTime, bool[] processed, int[] minConnectedValue, bool[] sccCompleted)
        {
            processed[vertex] = true;
            ++currentTime;
            //var currentDiscoveryTime = currentTime;
            minConnectedValue[vertex] = currentTime; // initialize to current time
            sccCompleted[vertex] = false;
            foreach (var neighbour in _vertexAdjancedVertices[vertex])
            {
                if (!processed[neighbour])
                {
                    GetStronglyConnectedComponents(neighbour, ref currentTime, processed, minConnectedValue, sccCompleted);
                    minConnectedValue[vertex] = Math.Min(minConnectedValue[vertex], minConnectedValue[neighbour]); // if we will ever find cycle
                }
                else if (!sccCompleted[minConnectedValue[neighbour]]) // ignore references to completed sccs
                {
                    minConnectedValue[vertex] = Math.Min(minConnectedValue[vertex], minConnectedValue[neighbour]); // we've reached processed vertex - use it as a minConnectedValue we could reach to (if smaller)
                }
            }
            if (minConnectedValue[vertex] == vertex) // we are going up to the stack, meaning that we are done with all the descendands
                sccCompleted[vertex] = true; // mark as completed in case if we are the root of current scc
        }
    }
}
