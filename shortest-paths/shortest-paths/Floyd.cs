using System.Collections.Generic;
using System.Linq;

namespace shortest_paths
{
    public class Floyd
    {
        private int NodesCount;
        private int[][] Matrix;
        private int[][] Paths;
        
        public Floyd(int nodesCount, int[][] matrix)
        {
            NodesCount = nodesCount;
            Matrix = GetPathsMatrix(nodesCount, matrix).Item1;
            Paths = GetPathsMatrix(nodesCount, matrix).Item2;
        }

        private (int[][], int[][]) GetPathsMatrix(int nodesCount, int[][] matrix)
        {
            int[][] paths = GetInitialPathMatrix(nodesCount);
            int[] indexes = GetIndexes(nodesCount);
            int[][] floydMatrix = matrix;

            for (int i = 0; i < nodesCount; i += 1)
            {
                int[] indexesWithoutCurrent = indexes.Where(index => index != i).ToArray();

                for (int rowIndex = indexesWithoutCurrent[0]; rowIndex < indexesWithoutCurrent.Length; rowIndex += 1)
                {
                    for (int columnIndex = indexesWithoutCurrent[0];
                        columnIndex < indexesWithoutCurrent.LongLength;
                        columnIndex += 1)
                    {
                        int newWeight = matrix[rowIndex][i] + matrix[i][columnIndex];

                        if (newWeight < matrix[rowIndex][columnIndex])
                        {
                            floydMatrix[rowIndex][columnIndex] = newWeight;
                            paths[rowIndex][columnIndex] = paths[rowIndex][i];
                        }
                    }
                }
            }

            return (floydMatrix, paths);
    }

        private int[][] GetInitialPathMatrix(int nodesCount)
        {
            int[][] paths = new int[nodesCount][];
            for (int i = 0; i < nodesCount; i += 1)
            {
                paths[i] = GetIndexes(nodesCount);
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