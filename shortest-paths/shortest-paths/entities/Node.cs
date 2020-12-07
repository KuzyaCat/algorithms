using System.Collections.Generic;

namespace shortest_paths
{
    public class Node
    {
        private int Index;

        public List<int> AdjacentNodesIndexes
        {
            get;
            set;
        }

        public List<int> Distances
        {
            get;
            set;
        }

        public Node(int index)
        {
            Index = index;
            AdjacentNodesIndexes = new List<int>();
            Distances = new List<int>();
        }

        public int GetIndex()
        {
            return Index;
        }

        public List<int>  GetAdjacentNodesIndexes()
        {
            return AdjacentNodesIndexes;
        }
    }
}