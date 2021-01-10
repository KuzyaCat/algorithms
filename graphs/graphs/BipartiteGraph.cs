using System;
using System.Collections;
using System.Collections.Generic;

namespace graphs
{
    public class BipartiteGraph : IGraph
    {
        private char[] NodesDenotation;
        private List<int>[] ContiguityLists;
        private int[] Colors; // 0 - without color, 1 - color one, 2 - color two
        private bool _isNotBipartite = false;

        public BipartiteGraph(char[] nodes, List<int>[] contiguityLists)
        {
            NodesDenotation = nodes;
            Colors = new int[NodesDenotation.Length];
            Array.Fill(Colors, 0);
            ContiguityLists = contiguityLists;
        }
        
        public int GetIndex(char node)
        {
            int index = 0;
            while (node != NodesDenotation[index])
            {
                index += 1;
            }
            return index;
        }
        
        private int InvertColor(int color) {
            return color == 1 ? 2 : 1;
        }
        
        
        public void FindBipartiteParts()
        {
            if (ContiguityLists.Length == 0 || ContiguityLists.Length == 1 || !DepthSearch(0, 1))
            {
                Console.WriteLine("The graph is not bipartite");
                return;
            }

            PrintGraphParts();
        }
        
        private bool DepthSearch(int node, int currentColor)
        {
            Colors[node] = currentColor;
            foreach (int neighbor in ContiguityLists[node])
            {
                if (Colors[neighbor] == 0)
                {
                    int nextColor = InvertColor(currentColor);
                    DepthSearch(neighbor, nextColor);
                }
                else if (Colors[neighbor] == currentColor)
                {
                    return false;
                }
            }
            return true;
        }
        
        private void PrintGraphParts()
        {
            ArrayList firstPartNodes = new ArrayList();
            ArrayList secondPartNodes = new ArrayList();
            
            for (int i = 0; i < NodesDenotation.Length; i += 1)
            {
                if (Colors[i] == 1)
                {
                    firstPartNodes.Add(NodesDenotation[i]);
                }
                else
                {
                    secondPartNodes.Add(NodesDenotation[i]);
                }
            }

            Console.Write("The first part: ");
            for (int i = 0; i < firstPartNodes.Count; i += 1)
            {
                Console.Write(firstPartNodes[i] + " ");
            }
            Console.WriteLine();
            
            Console.Write("The second part: ");
            for (int i = 0; i < secondPartNodes.Count; i += 1)
            {
                Console.Write(secondPartNodes[i] + " ");
            }
            Console.WriteLine();
        }
    }
}