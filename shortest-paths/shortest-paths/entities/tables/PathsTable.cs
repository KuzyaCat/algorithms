using System;
using System.Collections.Generic;
using System.Linq;

namespace shortest_paths
{
    public class PathsTable
    {
        private Node[] Nodes;
        private int NodesCount;
        private bool[] Visits; // check
        
        public List<int[]> Table
        {
            get;
            set;
        }

        public List<int> Sequence
        {
            get;
            set;
        }

        public PathsTable(Node[] nodes, int nodesCount, int startNodeIndex)
        {
            Nodes = nodes;
            NodesCount = nodesCount;
            Table = new List<int[]>();
            
            Visits = new bool[nodesCount];
            Array.Fill(Visits, false);
            
            int[] tableRow = new int[nodesCount];
            Array.Fill(tableRow, int.MaxValue);
            Table.Add(tableRow);
            Table.ElementAt(0)[startNodeIndex] = 0;
            
            Sequence = new List<int>();
            Sequence.Add(startNodeIndex);
        }

        public int AddRow(int currentNodeIndex)
        {
            Node currentNode = Nodes[currentNodeIndex];
            int[] currentNodeAdjacentNodeIndexes = currentNode.GetAdjacentNodesIndexes().ToArray();
            
            int[] latestRow = new int[NodesCount];
            Array.Copy(
                Table.ElementAt(Table.Count - 1),
                0,
                latestRow,
                0,
                NodesCount
                );

            int currentDistance = latestRow[currentNodeIndex];
            Visits[currentNodeIndex] = true;
            
            for (int i = 0; i < currentNodeAdjacentNodeIndexes.Length; i += 1)
            {
                int adjacentNodeIndex = currentNodeAdjacentNodeIndexes[i];
                
                if (!Visits[adjacentNodeIndex])
                {
                    int distanceToAdjacentNode = currentDistance + currentNode.Distances.ElementAt(adjacentNodeIndex);
                    if (distanceToAdjacentNode < latestRow[adjacentNodeIndex])
                    {
                        latestRow[adjacentNodeIndex] = distanceToAdjacentNode;
                    }
                }
            }

            Table.Add(latestRow);
            int nextNodeIndex = GetNodeIndexOfMinDistanceTo(latestRow);
            Sequence.Add(nextNodeIndex);
            
            return nextNodeIndex;
        }

        private int GetNodeIndexOfMinDistanceTo(int[] row)
        {
            int[] indexes = Enumerable.Range(0, row.Length).ToArray();
            List<int> possibleNodeIndexesList = new List<int>();

            foreach(var index in indexes)
            {
                if (!Visits[index])
                    possibleNodeIndexesList.Add(index);
            }

            int[] possibleNodeIndexes = possibleNodeIndexesList.ToArray();
            int nodeIndexOfMinDistanceTo = possibleNodeIndexes[0];

            foreach (var index in possibleNodeIndexes)
            {
                if (row[index] < row[nodeIndexOfMinDistanceTo])
                    nodeIndexOfMinDistanceTo = index;
            }

            return nodeIndexOfMinDistanceTo;
        }
    }
}