namespace shortest_paths.examples
{
    public class FloydExampleMatrices
    {
        public static int[][] GRAPH_MATRIX =
        {
            new [] {int.MaxValue, 9, 4, 7, 1},
            new [] {4, int.MaxValue, 8, -2, 1},
            new [] {1, -3, int.MaxValue, -5, 4},
            new [] {3, 2, int.MaxValue, int.MaxValue, 6},
            new [] {4, 7, 9, 0, int.MaxValue}
        };

    }
}