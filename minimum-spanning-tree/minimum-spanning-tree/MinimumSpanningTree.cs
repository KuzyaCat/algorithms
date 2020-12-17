using System.Collections.Generic;

namespace minimum_spanning_tree
{
    public class MinimumSpanningTree
    {
        private int NodesCount = 0;
        private List<Node> Nodes = new List<Node>();
        protected List<Edge> Edges
        {
            get;
            set;
        }
        
        protected MinimumSpanningTree(int[,] weightMatrix)
        {
            NodesCount = weightMatrix.Length;

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
        
        
        protected int GetNodesCount()
        {
            return NodesCount;
        }
    }
}