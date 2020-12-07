using System;

namespace shortest_paths
{
    public class OptimalLocation
    {
        public static int GetOptimalNodeCenterIndex(int[][] matrix)
        {
            int optimalNodeIndex = 0;
            Dijkstra dijkstraGraph = new Dijkstra(matrix, optimalNodeIndex);
            int minOfLongestDistances = dijkstraGraph.GetLongestDistanceNode().Item2;
            
            Console.WriteLine("Min of longest distances of the node 0: " + minOfLongestDistances);

            for (int i = 1; i < dijkstraGraph.GetNodesCount(); i += 1)
            {
                Dijkstra graph = new Dijkstra(matrix, i);
                int longestDistanceNodeIndex = graph.GetLongestDistanceNode().Item2;
                Console.WriteLine("Min of longest distances of the node " + i + ": " + longestDistanceNodeIndex);
                if (minOfLongestDistances > longestDistanceNodeIndex)
                {
                    minOfLongestDistances = longestDistanceNodeIndex;
                    optimalNodeIndex = i;
                } 
            }

            return optimalNodeIndex;
        }
    }
}