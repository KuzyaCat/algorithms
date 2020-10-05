namespace searches
{
    public class InterpolationalSearch
    {
        private static int _comparisonsCount = 0;

        private static int[] Search(int[] values, int valueToFind, int leftIndex, int rightIndex)
        {
            while (values[leftIndex] <= valueToFind && values[rightIndex] >= valueToFind)
            {
                _comparisonsCount += 1;
                int middleIndex = leftIndex + ((valueToFind - values[leftIndex]) * (rightIndex - leftIndex)) /
                    (values[rightIndex] - values[leftIndex]);

                _comparisonsCount += 1;
                if (values[middleIndex] == valueToFind)
                {
                    return new []{middleIndex, _comparisonsCount};
                }

                _comparisonsCount += 1;
                if (values[middleIndex] < valueToFind)
                {
                    leftIndex = middleIndex + 1;
                }
                else
                {
                    rightIndex = middleIndex - 1;
                }
            }
            
            if (values[leftIndex] == valueToFind)
            {
                _comparisonsCount += 1;
                return new[] {leftIndex, _comparisonsCount};
            }
            if (values[rightIndex] == valueToFind)
            {
                _comparisonsCount += 2;
                return new[] {rightIndex, _comparisonsCount};
            }
            _comparisonsCount += 2;
            return new[] {-1, _comparisonsCount};
        }

        public static int[] Search(int[] values, int valueToFind)
        {
            return values.Length != 0
                ? Search(values, valueToFind, 0, values.Length - 1)
                : new[] {-1, _comparisonsCount};
        }
    }
}
