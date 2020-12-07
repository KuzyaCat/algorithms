using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace shortest_paths
{
    public class Dijkstra
    {
        private int NodesCount;
        private int[][] Matrix;
        private Node[] Nodes;
        private PathsTable Paths;
        private int StartNodeIndex;
        
        public Dijkstra(int[][] matrix, int startNodeIndex)
        {
            NodesCount = matrix.Length;
            Matrix = matrix;
            StartNodeIndex = startNodeIndex;
            
            Nodes = new Node[matrix.Length];
            for (int i = 0; i < NodesCount; i += 1)
            {
                Nodes[i] = new Node(i);
            }

            for (int i = 0; i < NodesCount; i += 1)
            {
                for (int j = 0; j < NodesCount; j += 1)
                {
                    if (Matrix[i][j] != int.MaxValue)
                    {
                        Nodes[i].AdjacentNodesIndexes.Add(j);   
                    }
                    Nodes[i].Distances.Add(Matrix[i][j]);
                }
            }
            
            Paths = new PathsTable(Nodes, NodesCount, StartNodeIndex);
            int currentNodeIndex = StartNodeIndex;

            for (int i = 0; i < NodesCount - 1; i += 1)
            {
                currentNodeIndex = Paths.AddRow(currentNodeIndex);
            }
        }

        public List<int> GetPathToNode(int nodeIndex)
        {
            List<int> path = new List<int>();
            path.Add(nodeIndex);
            
            int rowIndexOfFinding = Paths.Sequence.FindIndex(index => index == nodeIndex);
            int currentDistance = GetDistanceToNode(nodeIndex);

            while (rowIndexOfFinding > 0)
            {
                if (currentDistance != Paths.Table[rowIndexOfFinding][nodeIndex])
                {
                    path.Add(Paths.Sequence.ElementAt(rowIndexOfFinding));
                    nodeIndex = path.ElementAt(path.Count - 1);
                    currentDistance = Paths.Table[rowIndexOfFinding][nodeIndex];
                }
                rowIndexOfFinding -= 1;
            }
            
            path.Add(StartNodeIndex);
            path.Reverse();
            
            return path;
        }

        public int GetDistanceToNode(int nodeIndex)
        {
            int rowIndexOfFinding = Paths.Sequence.FindIndex(index => index == nodeIndex);
            return Paths.Table[rowIndexOfFinding][nodeIndex];
        }

        public (int, int) GetLongestDistanceNode()
        {
            List<int> distancesToOtherNodes = Nodes
                .Where(node => node.GetIndex() != StartNodeIndex)
                .Select(node => GetDistanceToNode(node.GetIndex()))
                .Where(distance => distance != int.MaxValue && distance > -2e9)
                .ToList();
            int maxDistance = int.MaxValue;
            if (distancesToOtherNodes.Count > 0)
            {
                maxDistance = distancesToOtherNodes.Max();
            }
            return (distancesToOtherNodes.IndexOf(maxDistance), maxDistance);
        }

        public int GetNodesCount()
        {
            return NodesCount;
        }
    }
}