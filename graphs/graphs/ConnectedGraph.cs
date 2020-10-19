using System;
using System.Collections;

namespace graphs
{
    public class ConnectedGraph : IGraph
    {
        private char[] NodesDenotation;
        private int[,] GraphMatrix;
        private bool[] UsedGraphsIndexes;
        private ArrayList[] Components;
        
        public ConnectedGraph(char[] nodes, int[,] nodesMatrix, int nodesCount)
        {
            NodesDenotation = nodes;
            GraphMatrix = nodesMatrix;
            Array.Fill(UsedGraphsIndexes, false);
            for (int i = 0; i < NodesDenotation.Length; i += 1)
            {
                Components[i] = new ArrayList();
            }
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

        void Dfs(int index)
        {
            UsedGraphsIndexes[index] = true;
        }
    }
}