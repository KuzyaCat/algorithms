using System;

namespace searches
{
    public class BinarySearch

    {
        private static int _comparisonsCount = 0;
        
        private static int[] Search(int[] values, int valueToFind, int leftIndex, int rightIndex)
        {
            _comparisonsCount += 1;
            if (leftIndex > rightIndex)
            {
                return new[] {-1, _comparisonsCount};
            }

            int middleIndex = (leftIndex + rightIndex) / 2;
            int middleValue = values[middleIndex];

            _comparisonsCount += 1;
            if (middleValue == valueToFind)
            {
                return new[] {middleIndex, _comparisonsCount};
            }
            else
            {
                _comparisonsCount += 1;
                return middleValue > valueToFind
                    ? Search(values, valueToFind, leftIndex, middleIndex - 1)
                    : Search(values, valueToFind, middleIndex + 1, rightIndex);
            }
        }

        public static int[] Search(int[] values, int searchingValue)
        {
            return values.Length != 0
                ? Search(values, searchingValue, 0, values.Length - 1)
                : new[] {-1, _comparisonsCount};
        }
    }
}