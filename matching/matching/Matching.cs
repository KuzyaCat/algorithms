using System;
using System.Collections.Generic;

namespace matching
{
    public class Matching
    {
        private int Count = 0;
        private int[][] Adjacencies;
        private bool[] VisitedNodes;
        private bool[] OccupatedNodes;
        private int[] Matches;

        public Matching(int[][] adjacencies)
        {
            Adjacencies = adjacencies;
            Count = adjacencies.Length;
            
            VisitedNodes = new bool[Count];
            Array.Fill(VisitedNodes, false);
            
            OccupatedNodes = new bool[Count];
            Array.Fill(OccupatedNodes, false);
            
            Matches = new int[Count];
            Array.Fill(Matches, -1);

            for (int i = 0; i < Count; i += 1)
            {
                HaveIncreasingPath(i);
            }
        }

        public List<(int, int)> AssignEmployees()
        {
            int unassignedCounter = 0;
            List<(int, int)> assignedEmployees = new List<(int, int)>();

            for (int i = 0; i < Count; i += 1)
            {
                if (Matches[i] == -1)
                {
                    int unassignedEmployeeIndex = 0;
                    for (int j = unassignedCounter; j < Count; j += 1)
                    {
                        if (OccupatedNodes[j] == false)
                        {
                            unassignedEmployeeIndex = j;
                            break;
                        }
                    }

                    OccupatedNodes[unassignedEmployeeIndex] = true;
                    assignedEmployees.Add((i, unassignedEmployeeIndex));
                    unassignedEmployeeIndex += 1;
                }
            }

            return assignedEmployees;
        }

        public int[] GetMatches()
        {
            return Matches;
        }

        private bool HaveIncreasingPath(int startNode)
        {
            if (VisitedNodes[startNode])
            {
                return false;
            }

            VisitedNodes[startNode] = true;

            foreach (var node in Adjacencies[startNode])
            {
                if (Matches[node] == -1 || HaveIncreasingPath(Matches[node]))
                {
                    Matches[node] = startNode;
                    OccupatedNodes[node] = true;

                    return true;
                }
            }

            return false;
        }
    }
}