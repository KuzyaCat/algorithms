using System;
using System.Collections.Generic;

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
                    new ConnectedGraph(nodesDenotation, graphMatrix) 
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
            char[] nodesDenotation = {'1', '2', '3', '4', '5', '6', '7'};
            return new IGraph[]
            {
                new EulerGraph(nodesDenotation, GraphSamples.TrueEulerGraphMatrix, nodesDenotation.Length),
                new BipartiteGraph(nodesDenotation, GraphSamples.BipartiteGraphContiguityLists),
                new ConnectedGraph(nodesDenotation, GraphSamples.ThreeComponentsGraph), 
            };
        }
        
        
        
        static void Main(string[] args)
        {
            EulerGraph eulerGraph = (EulerGraph)GetHardcodedData()[0];
            BipartiteGraph bipartiteGraph = (BipartiteGraph) GetHardcodedData()[1];
            
            eulerGraph.GetEulerCycle();
            bipartiteGraph.FindBipartiteParts();
            
            ConnectedGraph connectedGraph = (ConnectedGraph)GetHardcodedData()[2];
            List<List<char>> components = connectedGraph.GetComponents();
            connectedGraph.PrintComponents(components);
        }
    }
}