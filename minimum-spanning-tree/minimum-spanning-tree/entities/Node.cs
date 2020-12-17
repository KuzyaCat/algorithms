using System.Collections.Generic;
using System.Linq;

namespace minimum_spanning_tree
{
    public class Node
    {
        private int Index;

        public bool IsVisited
        {
            get;
            set;
        }

        public List<Edge> IncidentEdges
        {
            get;
            set;
        }

        public Node(int index)
        {
            Index = index;
            IncidentEdges = new List<Edge>();
            IsVisited = false;
        }

        public int GetIndex()
        {
            return Index;
        }
        
        public bool IsFormCycle(Node incidentNode, List<Edge> edges)
        {
            bool isFormCycle = IsFormCycle(incidentNode);

            foreach (var edge in edges)
            {
                edge.IsInCycle = false;
            }

            return isFormCycle;
        }

        private bool IsFormCycle(Node incidentNode)
        {
            if (Index == incidentNode.GetIndex())
            {
                return true;
            }

            List<Edge> possibleEdgesList = incidentNode
                .IncidentEdges
                .Where(edge => !edge.ToVisit && !edge.IsInCycle)
                .ToList();

            if (possibleEdgesList.Count == 0)
            {
                return false;
            }

            foreach (var edge in possibleEdgesList)
            {
                edge.IsInCycle = true;
            }

            List<Node> secondNodesOfPossibleEdges = possibleEdgesList
                .Select(edge => edge.GetAnotherNode(incidentNode))
                .ToList();

            return secondNodesOfPossibleEdges.Any(node => IsFormCycle(node));
        }
    }
}