using System;
using System.Collections;

namespace graphs
{
    public class EulerGraph : IGraph
    {
        private Stack PathStack = new Stack();
        private ArrayList EulerCycle = new ArrayList();
        private char[] NodesDenotation;
        private int[,] GraphMatrix;
        private readonly int NodesCount = 0;

        public EulerGraph(char[] nodes, int[,] nodesMatrix, int nodesCount)
        {
            NodesDenotation = nodes;
            GraphMatrix = nodesMatrix;
            NodesCount = nodesCount;
        }
        
        private int GetDegree(int i)
        {
            int j, deg = 0;
            for (j = 0; j < NodesCount; j += 1)
            {
                if (GraphMatrix[i, j] == 1)
                {
                    deg++;
                }
            }
            return deg;
        }
        
        private bool AllVisited(int index)
        {            
            for (int i = 0; i < NodesCount; i += 1)
            {
                if (GraphMatrix[index, i] == 1)
                    return false;
            }
            return true;
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

        private bool IsEuler()
        {
            for (int i = 0; i < NodesCount; i += 1)
            {
                if (GetDegree(i) % 2 != 0)
                {
                    return false;
                }
            }
            return true;
        }

        private void FindEuler()
        {
            int index = 0;
            PathStack.Push(NodesDenotation[0]);
            while(PathStack.Count!=0)
            {
                index = GetIndex((char)PathStack.Peek());                
                if (AllVisited(index))
                {
                    EulerCycle.Add(PathStack.Pop());
                }
                else
                {
                    for (int j = 0; j < NodesCount; j++)
                    {
                        if (GraphMatrix[index, j] == 1)
                        {
                            GraphMatrix[index, j] = 0;
                            GraphMatrix[j, index] = 0;
                            PathStack.Push(NodesDenotation[j]);
                            break;
                        }
                    }
                }
            }
        }

        public void GetEulerCycle()
        {
            if (!IsEuler())
            {
                Console.WriteLine("The graph is not Euler");
                return;
            }

            FindEuler();
            Console.WriteLine("The graph is Euler");
            PrintEulerCircuit();
        }
        
        private void PrintEulerCircuit()
        {
            for (int i = 0; i < EulerCycle.Count;i++ )
            {
                Console.Write(EulerCycle[i] + " ");
            }
            Console.WriteLine();
        }
    }
}