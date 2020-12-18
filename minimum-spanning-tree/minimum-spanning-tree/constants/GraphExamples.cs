namespace minimum_spanning_tree.constants
{
    public class GraphExamples
    {
        public static int[,] GRAPH_WEIGHT_MATRIX_SMALL =
        {
            {0, 1, 3, 2},
            {1, 0, 5, 3},
            {3, 5, 0, 7},
            {2, 3, 7, 0}
        };

        public static int[,] GRAPH_WEIGHT_MATRIX_BIG =
        {
            {0, 9, 9, int.MaxValue, int.MaxValue, 8, int.MaxValue, int.MaxValue, int.MaxValue, 18},
            {9, 0, 3, int.MaxValue, 6, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue},
            {9, 3, 0, 2, 4, 9, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue},
            {int.MaxValue, int.MaxValue, 2, 0, 2, 8, 9, int.MaxValue, int.MaxValue, int.MaxValue},
            {int.MaxValue, 6, 4, 2, 0, int.MaxValue, 9, int.MaxValue, int.MaxValue, int.MaxValue},
            {8, int.MaxValue, 9, 8, int.MaxValue, 0, 7, int.MaxValue, 9, 10},
            {int.MaxValue, int.MaxValue, int.MaxValue, 9, 9, 7, 0, 4, 5, int.MaxValue},
            {int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, 4, 0, 1, 4},
            {int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, 9, 5, 1, 0, 3},
            {18, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, 10, int.MaxValue, 4, 3, 0}
        };
    }
}