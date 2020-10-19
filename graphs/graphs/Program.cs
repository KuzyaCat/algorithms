using System;

namespace graphs
{
    class Program
    {
        private static IGraph[] GetInputData()
        {
            Console.WriteLine("Enter the number of Nodes");
            try
            {
                int length = int.Parse(Console.ReadLine());
                int[,] graphMatrix = new int[length, length];
                char[] nodesDenotation = new char[length];               

                Console.WriteLine("Enter the nodes denotations");
                for (int i = 0; i < length; i++)
                {                    
                    nodesDenotation[i] = char.Parse(Console.ReadLine());
                }

                Console.WriteLine("Enter the adjacency matrix of the graph");
                for (int i = 0; i < length; i++)
                {
                   Console.WriteLine(i + 1 + " row:");
                    for (int j = 0; j < length; j++)
                    {
                        graphMatrix[i, j] = int.Parse(Console.ReadLine());                        
                    }
                    Console.WriteLine();
                }
                
                return new IGraph[]
                {
                    new EulerGraph(nodesDenotation, graphMatrix, length),
                    new BipartiteGraph(nodesDenotation, graphMatrix)
                };
            }
            catch
            {
                Console.WriteLine("Invalid number");
                return null;
            }
        }
        
        private static IGraph[] GetHardcodedData()
        {
            char[] nodesDenotation = {'a', 'b', 'c', 'd', 'e', 'f', 'g'};
            int[,] trueEulerGraphMatrix = 
            {
                {0, 1, 0, 0, 0, 0, 1},
                {1, 0, 1, 1, 0, 0, 1},
                {0, 1, 0, 1, 1, 1, 0},
                {0, 1, 1, 0, 0, 1, 1},
                {0, 0, 1, 0, 0, 1, 0},
                {0, 0, 1, 1, 1, 0, 1},
                {1, 1, 0, 1, 0, 1, 0}
            };
            int[,] notEulerGraphMatrix = 
            {
                {0, 1, 0, 1, 0, 0, 1},
                {1, 0, 1, 1, 0, 0, 1},
                {0, 1, 0, 1, 1, 1, 0},
                {0, 1, 1, 0, 0, 1, 1},
                {0, 0, 1, 0, 0, 1, 0},
                {0, 0, 1, 1, 1, 0, 1},
                {1, 1, 0, 1, 0, 1, 0}
            };
            int[,] trueBipartiteGraph =
            {
                {0, 1, 0, 0, 1, 0, 0},
                {1, 0, 1, 1, 0, 0, 0},
                {0, 1, 0, 0, 1, 1, 0},
                {0, 1, 0, 0, 1, 0, 0},
                {1, 0, 1, 1, 0, 0, 1},
                {0, 0, 1, 0, 0, 0, 1},
                {0, 0, 0, 0, 1, 1, 0}
            };
            int[,] notBipartiteGraph =
            {
                {0, 1, 0, 0, 1, 0, 0},
                {1, 0, 1, 1, 1, 0, 0},
                {0, 1, 0, 0, 1, 1, 0},
                {0, 1, 0, 0, 1, 0, 0},
                {1, 1, 1, 1, 1, 1, 1},
                {0, 0, 1, 0, 1, 0, 1},
                {0, 0, 0, 0, 1, 1, 0}
            };
            
            return new IGraph[]
            {
                new EulerGraph(nodesDenotation, trueEulerGraphMatrix, 7),
                new BipartiteGraph(nodesDenotation, trueBipartiteGraph)
            };
        }
        
        
        
        static void Main(string[] args)
        {
            EulerGraph graph = (EulerGraph)GetHardcodedData()[0];
            BipartiteGraph bipartiteGraph = (BipartiteGraph) GetHardcodedData()[1];
            graph.GetEulerCycle();
            // bipartiteGraph.BipartiteGraphPartsSearch();
        }
    }
}