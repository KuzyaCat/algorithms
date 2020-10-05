namespace sorting.sorts
{
    public class InsertionSort : Sort // O(19n^2)
    {
        public static void Sort(ref int[] values, int startIndex, int endIndex) // let endIndex - startIndex + 1 = values.Length
        {
            for (int i = startIndex + 1; i <= endIndex; i += 1) // 5 * values.Length - 2 elementary operations
            {
                int leadingElement = values[i]; // 2 * (values.Length - 1) elementary operations
                int j = i; // 1 * (values.Length - 1) elementary operations
                while (j > startIndex && values[j - 1] > leadingElement) // 4 * (i + 1) * (values.Length - 1) elementary operations
                {
                    Swap(ref values[j - 1], ref values[j]); // 7 * i * (values.Length - 1) elementary operations
                    j -= 1; // 2 * i * (values.Length - 1) elementary operations
                }
            }
        }
    }
}
