using System;
using shortest_paths.examples;

namespace shortest_paths
{
    class Program
    {
        public static void TestFloyd()
        {
            Floyd floyd = new Floyd(FloydExampleMatrices.GRAPH_MATRIX.Length, FloydExampleMatrices.GRAPH_MATRIX);

            int optimalCenterNode = floyd.GetOptimalCenterNode();

            Console.WriteLine("nodeIndexOfShortestPathTo: " + optimalCenterNode);
            Console.WriteLine("distanceToFarthestNode of optimal center node: " + floyd.GetDistanceToFarthestNode(optimalCenterNode));
            Console.WriteLine("distanceToFarthestNode 0: " + floyd.GetDistanceToFarthestNode(0));
            Console.WriteLine("distanceToFarthestNode 1: " + floyd.GetDistanceToFarthestNode(1));
            Console.WriteLine("distanceToFarthestNode 2: " + floyd.GetDistanceToFarthestNode(2));
            Console.WriteLine("distanceToFarthestNode 3: " + floyd.GetDistanceToFarthestNode(3));
            Console.WriteLine("distanceToFarthestNode 4: " + floyd.GetDistanceToFarthestNode(4));
            Console.WriteLine("Path from matrix[1] to matrix[2] (length " + floyd.GetDistanceBetweenNodes(1, 2) + "):");
            PathPrinter.PrintPath(floyd.GetPathBetweenNodes(1, 2));
            Console.WriteLine();
            Console.WriteLine("Path from matrix[4] to matrix[2] (length " + floyd.GetDistanceBetweenNodes(4, 2) + "):");
            PathPrinter.PrintPath(floyd.GetPathBetweenNodes(4, 2));
            Console.WriteLine();
            Console.WriteLine("Path from matrix[0] to matrix[3] (length " + floyd.GetDistanceBetweenNodes(0, 3) + "):");
            PathPrinter.PrintPath(floyd.GetPathBetweenNodes(0, 3));
        }
        
        public static void TestDijkstra()
        {
            Dijkstra dijkstra = new Dijkstra(DijkstraExampleMatrices.GRAPH_MATRIX, 0);
            
            int optimalCenterNode = OptimalLocation.GetOptimalNodeCenterIndex(DijkstraExampleMatrices.GRAPH_MATRIX);
            Console.WriteLine("\nOptimal node index: " + optimalCenterNode + '\n');
            
            Console.WriteLine("Path from matrix[0] to matrix[4] (length " + dijkstra.GetDistanceToNode(4) + "):");
            PathPrinter.PrintPath(dijkstra.GetPathToNode(4));
            Console.WriteLine();
            Console.WriteLine("Path from matrix[0] to matrix[2] (length " + dijkstra.GetDistanceToNode(2) + "):");
            PathPrinter.PrintPath(dijkstra.GetPathToNode(2));
            Console.WriteLine();
            Console.WriteLine("Path from matrix[0] to matrix[6] (length " + dijkstra.GetDistanceToNode(6) + "):");
            PathPrinter.PrintPath(dijkstra.GetPathToNode(6));
        }
        
        static void Main(string[] args)
        {
            // TestFloyd();
            TestDijkstra();
        }
    }
}