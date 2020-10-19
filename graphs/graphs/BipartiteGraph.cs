using System;
using System.Collections;

namespace graphs
{
    public class BipartiteGraph : IGraph
    {
        private char[] NodesDenotation;
        private int[,] GraphMatrix;
        private int[] Colors; // 0 - without color, 1 - color one, 2 - color two

        public BipartiteGraph(char[] nodes, int [,] graphMatrix)
        {
            NodesDenotation = nodes;
            Colors = new int[NodesDenotation.Length];
            Array.Fill(Colors, 0);
            GraphMatrix = graphMatrix;
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
        
        private bool BipartiteGraphPartsSearch(int index, int currentNodeColor) {
            Colors[index] = currentNodeColor;

            for (int i = 0; i < NodesDenotation.Length; i += 1)
            {
                if (Colors[i] == 0 && GraphMatrix[index, i] == 1)
                {
                    BipartiteGraphPartsSearch(i, InvertColor(currentNodeColor));
                } else if (GraphMatrix[index, i] == 1 && Colors[i] == currentNodeColor)
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

        public void BipartiteGraphPartsSearch()
        {
            bool isBipartiteGraph = BipartiteGraphPartsSearch(0, 1);

            if (isBipartiteGraph)
            {
                Console.WriteLine("The graph is bipartite");
                PrintGraphParts();
            }
            else
            {
                Console.WriteLine("The graph is not bipartite");
            }
        }
    }
}