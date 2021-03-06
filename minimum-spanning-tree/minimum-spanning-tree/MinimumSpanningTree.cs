using System;
using System.Collections.Generic;
using System.Linq;

namespace minimum_spanning_tree
{
    public class MinimumSpanningTree
    {
        private int NodesCount = 0;

        protected List<Node> Nodes
        {
            get;
            set;
        }
        protected List<Edge> Edges
        {
            get;
            set;
        }
        
        protected MinimumSpanningTree(int[,] weightMatrix)
        {
            NodesCount = Convert.ToInt32(Math.Sqrt(weightMatrix.Length));
            Edges = new List<Edge>();
            Nodes = new List<Node>();

            for (int i = 0; i < NodesCount; i += 1)
            {
                Nodes.Add(new Node(i));
            }
            
            for (int i = 0; i < NodesCount - 1; i += 1)
            {
                for (int j = i + 1; j < NodesCount; j += 1)
                {
                    Edge edge = new Edge(Nodes[i], Nodes[j], weightMatrix[i, j]);
                    
                    Nodes[i].IncidentEdges.Add(edge);
                    Nodes[j].IncidentEdges.Add(edge);
                    Edges.Add(edge);
                }
            }
        }
        
        protected Edge GetMinimumByWeightEdge(List<Edge> edges)
        {
            List<int> edgesWeights = edges.Select(edge => edge.GetWeight()).ToList();
            int minimumWeightEdge = edgesWeights.Min();
            int minimumWeightEdgeIndex = edgesWeights.IndexOf(minimumWeightEdge);
            
            return edges.ElementAt(minimumWeightEdgeIndex);
        }
        
        
        protected int GetNodesCount()
        {
            return NodesCount;
        }
    }
}