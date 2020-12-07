using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace graphs
{
    public class ConnectedGraph : IGraph
    {
        private char[] NodesDenotation;
        private int[,] GraphMatrix;

        public ConnectedGraph(char[] nodes, int[,] nodesMatrix)
        {
            NodesDenotation = nodes;
            GraphMatrix = nodesMatrix;
        }

        private void FindComponent(char startNode, ref List<char> component, ref List<char> nodesList)
        {
            int startNodeIndex = nodesList.IndexOf(startNode);
            component.Add(startNode);
            nodesList.RemoveAt(startNodeIndex);
            
            for (int i = 0; i < NodesDenotation.Length; i += 1)
            {
                if (GraphMatrix[GetIndex(startNode), i] == 1 && !component.Contains(NodesDenotation[i]))
                {
                    FindComponent(NodesDenotation[i], ref component, ref nodesList);
                }
            }
        }

        public List<List<char>> GetComponents()
        {
            List<List<char>> components = new List<List<char>>();
            List<char> nodesDenotationCopy = GetNodeDenotationCopyList();
                
            while (nodesDenotationCopy.Count > 0)
            {
                List<char> component = new List<char>();
                FindComponent(nodesDenotationCopy[0], ref component, ref nodesDenotationCopy);
                components.Add(component);
            }

            return components;
        }

        public void PrintComponents(List<List<char>> components)
        {
            Console.WriteLine("Components:");
            for (int i = 0; i < components.Count; i += 1)
            {
                Console.Write("component " + (i + 1) + ": ");
                for (int j = 0; j < components[i].Count; j += 1)
                {
                    Console.Write(components[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        private List<char> GetNodeDenotationCopyList()
        {
            List<char> nodesList = new List<char>();
            for (int i = 0; i < NodesDenotation.Length; i += 1)
            {
                nodesList.Add(NodesDenotation[i]);
            }

            return nodesList;
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
    }
}