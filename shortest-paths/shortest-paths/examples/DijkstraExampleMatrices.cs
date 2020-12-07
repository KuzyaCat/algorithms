namespace shortest_paths.examples
{
    public class DijkstraExampleMatrices
    {
        public static int[][] GRAPH_MATRIX =
        {
            new [] {int.MaxValue, 6, int.MaxValue, 1, int.MaxValue, 7, int.MaxValue},
            new [] {int.MaxValue, int.MaxValue, 2, 1, int.MaxValue, 3, int.MaxValue},
            new [] {int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, 2},
            new [] {int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, 5, 1, int.MaxValue},
            new [] {int.MaxValue, int.MaxValue, 1, int.MaxValue, int.MaxValue, int.MaxValue, 3},
            new [] {int.MaxValue, int.MaxValue, 6, int.MaxValue, 1, int.MaxValue, 4},
            new [] {int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue}
        };
    }
}