using System.Collections.Generic;

namespace shortest_paths
{
    public class Node
    {
        private int Index;
        private List<int> IncidentNodes;
        private bool IsVisited;

        public Node(int index)
        {
            Index = index;
            IncidentNodes = new List<int>();
            IsVisited = false;
        }

        public int GetIndex()
        {
            return Index;
        }
    }
}