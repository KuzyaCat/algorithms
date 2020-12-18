using System;
using System.Collections.Generic;

namespace minimum_spanning_tree.utils
{
    public class PrintEdges
    {
        public static void PrintEdgesList(List<Edge> edges)
        {
            foreach (var edge in edges)
            {
                Console.Write("(" + edge.GetStartNode().GetIndex() + "-" + edge.GetEndNode().GetIndex() + ") ");
            }
            Console.WriteLine();
        }
    }
}