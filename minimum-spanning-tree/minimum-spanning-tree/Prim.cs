using System.Collections.Generic;
using System.Linq;

namespace minimum_spanning_tree
{
    public class Prim : MinimumSpanningTree
    {
        public Prim(int[,] weightMatrix) : base(weightMatrix) {}

        public List<Edge> GetMinimumSpanningTree()
        {
            List<Edge> minimumSpanningTreeEdges = new List<Edge>();

            Edge minimumWeightEdge = GetMinimumByWeightEdge(Edges);
            Node currentNode = minimumWeightEdge.GetStartNode();

            while (Nodes.Any(node => !node.IsVisited))
            {
                currentNode.IsVisited = true;
                List<Edge> possibleEdges = GetPossibleEdges();
                if (possibleEdges.Count >= 0)
                {
                    Edge nextEdge = GetMinimumByWeightEdge(possibleEdges);
                    nextEdge.ToVisit = false;
                    minimumSpanningTreeEdges.Add(nextEdge);

                    currentNode = nextEdge.GetStartNode().IsVisited ? nextEdge.GetEndNode() : nextEdge.GetStartNode();
                }
            }

            foreach (var node in Nodes)
            {
                node.IsVisited = false;
            }

            foreach (var edge in Edges)
            {
                edge.ToVisit = true;
            }

            return minimumSpanningTreeEdges;
        }

        private List<Edge> GetPossibleEdges()
        {
            List<Edge> possibleEdges = new List<Edge>();
            List<Node> visitedNodes = Nodes.Where(node => node.IsVisited).ToList();

            foreach (var visitedNode in visitedNodes)
            {
                possibleEdges.AddRange(visitedNode
                    .IncidentEdges
                    .Where(edge => !edge.GetStartNode().IsFormCycle(edge.GetAnotherNode(visitedNode), Edges))
                );
            }

            return possibleEdges;
        }
    }
}