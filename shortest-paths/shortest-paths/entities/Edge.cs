using System;

namespace shortest_paths
{
    public class Edge
    {
        private Node StartNode;
        private Node EndNode;
        private int Weight;
        private bool MustBeVisited;
        private bool IsInPath;
        
        public Edge(Node startNode, Node endNode, int weight)
        {
            StartNode = startNode;
            EndNode = endNode;
            Weight = Weight;
            MustBeVisited = true;
            IsInPath = false;
        }
    
        public Node GetAnotherNode(Node node)
        {
            return StartNode == node ? EndNode : StartNode;
        }

        public override string ToString()
        {
            return String.Format("({0}, {1}) ",
                StartNode.GetIndex(), EndNode.GetIndex());
        }
    }
}