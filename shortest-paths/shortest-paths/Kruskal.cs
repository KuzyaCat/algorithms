using System.Collections.Generic;

namespace shortest_paths
{
    public class Kruskal
    {
        private int NodesCount;
        private int[][] Matrix;
        private List<List<int>> Paths;
        
        public Kruskal(int nodesCount, int[][] matrix)
        {
            NodesCount = nodesCount;
            Matrix = matrix;
        }

        private void GetPathsMatrix(int nodesCount, int[][] matrix)
        {
            List<List<int>> paths = GetInitialPathMatrix(nodesCount);
            int[] indexes = GetIndexes(nodesCount);
        }

        private List<List<int>> GetInitialPathMatrix(int nodesCount)
        {
            List<List<int>> paths = new List<List<int>>();
            for (int i = 0; i < nodesCount; i += 1)
            {
                List<int> path = new List<int>();
                for (int j = 0; j < nodesCount; j += 1)
                {
                    path.Add(j);
                }
                paths.Add(path);
            }

            return paths;
        }

        private int[] GetIndexes(int nodesCount)
        {
            int[] indexes = new int[nodesCount];
            for (int i = 0; i < nodesCount; i += 1)
            {
                indexes[i] = i;
            }

            return indexes;
        }
    }
}