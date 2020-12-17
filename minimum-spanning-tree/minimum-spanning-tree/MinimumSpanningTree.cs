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
            NodesCount = weightMatrix.Length;
            Edges = new List<Edge>();
            Nodes = new List<Node>();

            for (int i = 0; i < weightMatrix.Length; i += 1)
            {
                Nodes.Add(new Node(i));
            }

            for (int i = 0; i < weightMatrix.Length - 1; i += 1)
            {
                for (int j = i + 1; j < weightMatrix.Length; j += 1)
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
            
            return Edges.ElementAt(minimumWeightEdgeIndex);
        }
        
        
        protected int GetNodesCount()
        {
            return NodesCount;
        }
    }
}