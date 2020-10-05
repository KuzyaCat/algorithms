namespace searches.sorts
{
    public class InsertionSort : Sort
    {
        public static void Sort(ref int[] values, int startIndex, int endIndex)
        {
            for (int i = startIndex + 1; i <= endIndex; i += 1)
            {
                int leadingElement = values[i];
                int j = i;
                while (j > startIndex && values[j - 1] > leadingElement)
                {
                    Swap(ref values[j - 1], ref values[j]);
                    j -= 1;
                }
            }
        }
    }
}