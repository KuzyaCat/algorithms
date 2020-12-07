using System;
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
            (int[][], int[][]) PathsMatrix = GetPathsMatrix(nodesCount, matrix);
            Matrix = PathsMatrix.Item1;
            Paths = PathsMatrix.Item2;
        }

        private (int[][], int[][]) GetPathsMatrix(int nodesCount, int[][] matrix)
        {
            int[][] paths = GetInitialPathMatrix(nodesCount);
            int[] indexes = GetIndexes(nodesCount);
            int[][] floydMatrix = matrix;

            for (int i = 0; i < nodesCount; i += 1)
            {
                int[] indexesWithoutCurrent = indexes.Where(index => index != i).ToArray();

                for (int j = 0; j < indexesWithoutCurrent.Length; j += 1)
                {
                    int rowIndex = indexesWithoutCurrent[j];
                        
                    for (int k = 0; k < indexesWithoutCurrent.Length; k += 1)
                    {
                        int columnIndex = indexesWithoutCurrent[k];
                            
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

        private void AddNodeToPath(ref List<int[]> path, int[] edge, int index)
        {
            int nodeToAdd = Paths[edge[0]][edge[1]];
            
            path.RemoveAt(index);
            path.Insert(index, new []{edge[0], nodeToAdd});
            path.Insert(index + 1, new []{nodeToAdd, edge[1]});
        }

        private List<int[]> RefreshPath(ref List<int[]> path)
        {
            bool toUpdate = false;

            for (int i = 0; i < path.Count; i += 1)
            {
                int[] edge = path.ElementAt(i);

                if (!(Paths[edge[0]][edge[1]] == edge[1]))
                {
                    AddNodeToPath(ref path, edge, i);
                    toUpdate = true;
                }
            }

            if (toUpdate)
            {
                return RefreshPath(ref path);
            }

            return path;
        }

        public List<int[]> GetPathBetweenNodes(int startNodeIndex, int endNodeIndex)
        {
            List<int[]> initialPath = new List<int[]>();
            initialPath.Add(new int[] {startNodeIndex, endNodeIndex});
            List<int[]> path = RefreshPath(ref initialPath);

            return path;
        }

        public int GetDistanceBetweenNodes(int startNode, int endNode)
        {
            return Matrix[startNode][endNode];
        }

        public int GetDistanceToFarthestNode(int nodeIndex)
        {
            int[] anotherNodesIndexes = GetIndexes(NodesCount).Where(index => index != nodeIndex).ToArray();
            List<int> distancesToAnotherNodes = new List<int>();
            for (int i = 0; i < anotherNodesIndexes.Length; i += 1)
            {
                distancesToAnotherNodes.Add(GetDistanceBetweenNodes(nodeIndex, anotherNodesIndexes[i]));
            }

            return distancesToAnotherNodes.Max();
        }

        public int GetOptimalCenterNode()
        {
            List<int> farthestDistances = new List<int>();
            for (int i = 0; i < NodesCount; i += 1)
            {
                farthestDistances.Add(GetDistanceToFarthestNode(i));
            }

            return farthestDistances.IndexOf(farthestDistances.Min());
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