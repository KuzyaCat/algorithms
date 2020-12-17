using System.Collections.Generic;
using System.Linq;

namespace minimum_spanning_tree
{
    public class Kruskal : MinimumSpanningTree
    {
        public Kruskal(int[,] weightMatrix) : base(weightMatrix) {}

        public List<Edge> GetMinimumSpanningTree()
        {
            List<Edge> minimumSpanningTreeEdges = new List<Edge>();

            while (true)
            {
                List<Edge> possibleEdges = GetPossibleEdges();

                if (possibleEdges.Count > 0)
                {
                    Edge nextEdge = GetMinimumByWeightEdge();
                    nextEdge.ToVisit = false;
                    minimumSpanningTreeEdges.Add(nextEdge);
                }
                else
                {
                    break;
                }

                foreach (var edge in Edges)
                {
                    edge.ToVisit = true;
                }
            }

            return minimumSpanningTreeEdges;
        }

        private List<Edge> GetPossibleEdges()
        {
            List<Edge> unvisitedEdges = Edges.Where(edge => edge.ToVisit).ToList();

            return unvisitedEdges
                .Where(edge => edge.GetStartNode().IsFormCycle(edge.GetEndNode(), Edges))
                .ToList();
        }

        private Edge GetMinimumByWeightEdge()
        {
            List<int> edgesWeights = Edges.Select(edge => edge.GetWeight()).ToList();
            int minimumWeightEdge = edgesWeights.Min();
            int minimumWeightEdgeIndex = edgesWeights.IndexOf(minimumWeightEdge);
            
            return Edges.ElementAt(minimumWeightEdgeIndex);
        }
    }
}