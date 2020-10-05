namespace sorting.sorts
{
    public class HybridQuickSort : Sort
    {
        private static int Separation(ref int[] values, int leftIndex, int rightIndex)
        {
            int separationIndex = leftIndex;
            int leadingElement = values[rightIndex];
            
            for (int i = leftIndex; i < rightIndex; i += 1)
            {
                if (values[i] <= leadingElement)
                {
                    Swap(ref values[separationIndex], ref values[i]);
                    separationIndex += 1;
                }
            }
            Swap(ref values[rightIndex], ref values[separationIndex] );

            return separationIndex;
        }

        private static void Sort(ref int[] values, int leftIndex, int rightIndex, int k = 5)
        {
            if (leftIndex < rightIndex)
            {
                int separationIndex = Separation(ref values, leftIndex, rightIndex);
                
                if (separationIndex - leftIndex < k)
                {
                    InsertionSort.Sort(ref values, leftIndex, rightIndex);
                }
                else
                {
                    Sort(ref values, leftIndex, separationIndex - 1, k);
                }
                
                if (rightIndex - separationIndex < k)
                {
                    InsertionSort.Sort(ref values, leftIndex, rightIndex);
                }
                else
                {
                    Sort(ref values, separationIndex + 1, rightIndex, k);
                }
            }
        }

        public static void Sort(ref int[] values, int k = 4)
        {
            Sort(ref values, 0, values.Length - 1, k);
        }
    }
}
