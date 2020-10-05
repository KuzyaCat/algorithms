namespace sorting.sorts
{
    public class HybridMergeSort : Sort
    {
        private static void Sort(ref int[] values, ref int[] sortedValues, int leftIndex, int rightIndex, int k = 12)
        {
            if (leftIndex < rightIndex)
            {
                int middleIndex = (leftIndex + rightIndex) / 2;
                if (middleIndex - leftIndex + 1 < k)
                {
                    InsertionSort.Sort(ref values, leftIndex, middleIndex);
                }
                else
                {
                    Sort(ref values, ref sortedValues, leftIndex, middleIndex);
                }

                if (rightIndex - middleIndex < k)
                {
                    InsertionSort.Sort(ref values, middleIndex + 1, rightIndex);
                }
                else
                {
                    Sort(ref values, ref sortedValues, middleIndex + 1, rightIndex);
                }

                int i = leftIndex;
                int j = middleIndex + 1;
                int sortedValuesIndex = leftIndex;
                while (i <= middleIndex || j <= rightIndex)
                {
                    if (j > rightIndex || (i <= middleIndex && values[i] < values[j]))
                    {
                        sortedValues[sortedValuesIndex] = values[i];
                        i += 1;
                    }
                    else
                    {
                        sortedValues[sortedValuesIndex] = values[j];
                        j += 1;
                    }

                    sortedValuesIndex += 1;
                }

                for (int l = leftIndex; l <= rightIndex; l += 1)
                {
                    values[l] = sortedValues[l];
                }
            }
        }

        public static void Sort(ref int[] values, int k = 12)
        {
            int[] sortedValues = new int[values.Length];
            Sort(ref values, ref sortedValues, 0, values.Length - 1, k);
        }
    }
}