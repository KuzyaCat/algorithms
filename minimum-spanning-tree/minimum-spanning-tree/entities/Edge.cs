using System;

namespace minimum_spanning_tree
{
    public class Edge
    {
        private Node StartNode;
        private Node EndNode;
        private int Weight;

        public bool ToVisit
        {
            get;
            set;
        }

        public bool IsInCycle
        {
            get;
            set;
        }

        public Edge(Node startNode, Node endNode, int weight)
        {
            StartNode = startNode;
            EndNode = endNode;
            Weight = weight;
            ToVisit = true;
            IsInCycle = false;
        }

        public Node GetAnotherNode(Node node)
        {
            return StartNode == node ? EndNode : StartNode;
        }

        public Node GetStartNode()
        {
            return StartNode;
        }

        public Node GetEndNode()
        {
            return EndNode;
        }

        public int GetWeight()
        {
            return Weight;
        }

        public override string ToString()
        {
            return String.Format("({0}, {1}) ",
                StartNode.GetIndex(), EndNode.GetIndex());
        }
    }
}