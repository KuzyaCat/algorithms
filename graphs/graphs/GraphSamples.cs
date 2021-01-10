using System.Collections.Generic;

namespace graphs
{
    public class GraphSamples
    {
        public static int[,] TrueEulerGraphMatrix = 
        {
            {0, 1, 0, 0, 0, 0, 1},
            {1, 0, 1, 1, 0, 0, 1},
            {0, 1, 0, 1, 1, 1, 0},
            {0, 1, 1, 0, 0, 1, 1},
            {0, 0, 1, 0, 0, 1, 0},
            {0, 0, 1, 1, 1, 0, 1},
            {1, 1, 0, 1, 0, 1, 0}
        };
        
        public static int[,] NotEulerGraphMatrix = 
        {
            {0, 1, 0, 1, 0, 0, 1},
            {1, 0, 1, 1, 0, 0, 1},
            {0, 1, 0, 1, 1, 1, 0},
            {0, 1, 1, 0, 0, 1, 1},
            {0, 0, 1, 0, 0, 1, 0},
            {0, 0, 1, 1, 1, 0, 1},
            {1, 1, 0, 1, 0, 1, 0}
        };
        
        public static int[,] TrueBipartiteGraph =
        {
            {0, 1, 0, 0, 1, 0, 0},
            {1, 0, 1, 1, 0, 0, 0},
            {0, 1, 0, 0, 1, 1, 0},
            {0, 1, 0, 0, 1, 0, 0},
            {1, 0, 1, 1, 0, 0, 1},
            {0, 0, 1, 0, 0, 0, 1},
            {0, 0, 0, 0, 1, 1, 0}
        };
        
        public static List<int>[] BipartiteGraphContiguityLists =
        {
            new List<int> {1, 4},
            new List<int> {0, 2, 3},
            new List<int> {1, 4, 5},
            new List<int> {1, 4},
            new List<int> {0, 2, 3, 6},
            new List<int> {2, 6},
            new List<int> {4, 5}
        };
        
        public static List<int>[] NotBipartiteGraphContiguityLists =
        {
            new List<int> {1, 4},
            new List<int> {0, 2, 3},
            new List<int> {1, 4, 5},
            new List<int> {1, 4},
            new List<int> {0, 2, 3, 5, 6},
            new List<int> {0, 2, 4, 6},
            new List<int> {4, 5},
        };

        public static int[,] ThreeComponentsGraph =
        {
            {0, 1, 0, 0, 0, 0, 0},
            {1, 0, 1, 0, 0, 0, 0},
            {0, 1, 0, 1, 0, 0, 0},
            {0, 0, 1, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 1},
            {0, 0, 0, 0, 0, 1, 0}
        };
        
        public static int[,] OneComponentGraph =
        {
            {0, 1, 0, 0, 0, 0, 1},
            {1, 0, 1, 1, 0, 0, 1},
            {0, 1, 0, 1, 1, 1, 0},
            {0, 1, 1, 0, 0, 1, 1},
            {0, 0, 1, 0, 0, 1, 0},
            {0, 0, 1, 1, 1, 0, 1},
            {1, 1, 0, 1, 0, 1, 0}
        };
    }
}