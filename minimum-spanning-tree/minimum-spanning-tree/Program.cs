using System;
using minimum_spanning_tree.constants;
using minimum_spanning_tree.utils;

namespace minimum_spanning_tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Kruskal kruskal = new Kruskal(GraphExamples.GRAPH_WEIGHT_MATRIX_SMALL);
            Console.WriteLine("kruskal:");
            Console.WriteLine("kruskal.GetMinimumSpanningTree() " + kruskal.GetMinimumSpanningTree().Count);
            PrintEdges.PrintEdgesList(kruskal.GetMinimumSpanningTree());
            
            // Prim prim = new Prim(GraphExamples.GRAPH_WEIGHT_MATRIX_SMALL);
            // Console.WriteLine("Prim:");
            // PrintEdges.PrintEdgesList(kruskal.GetMinimumSpanningTree());
        }
    }
}