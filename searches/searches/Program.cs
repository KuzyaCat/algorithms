using System;
using System.Linq;
using searches.sorts;

namespace searches
{
    class Program
    {
        private static int[] GetInputData()
        {
            Console.WriteLine("Enter max value:");
            int maxRangeValue = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("Enter values length:");
            int valuesLength = Convert.ToInt32(Console.ReadLine());

            return new[] {maxRangeValue, valuesLength};
        }

        private static int GetValueToFind()
        {
            Console.WriteLine("Enter the value to find:");
            return Convert.ToInt32(Console.ReadLine());
        }
        
        private static int[] GenerateRandomValues(int maxRangeValue, int valuesLength)
        {
            int[] randomValues = new int[valuesLength]; 

            Random randomNumber = new Random();
            for (int i = 0; i < randomValues.Length; i++)
            {
                randomValues[i] = randomNumber.Next(0, maxRangeValue);
            }

            return randomValues;
        }
        
        private static void PrintValues(int[] values)
        {
            Console.WriteLine("Sorted array:");
            values.ToList().ForEach(i => Console.Write(i.ToString() + ' '));
            Console.WriteLine();
        }

        private static void PrintResult(int index, int comparisonsCount)
        {
            Console.WriteLine("The index of the searched value: " + index);
            Console.WriteLine("Total count of comparisons: " + comparisonsCount);
        }

        private static void TestBinarySearch()
        {
            int[] inputData = GetInputData();
            int[] values = GenerateRandomValues(inputData[0], inputData[1]);
            HybridMergeSort.Sort(ref values);
            PrintValues(values);

            int[] binarySearchResult = BinarySearch.Search(values, GetValueToFind());
            PrintResult(binarySearchResult[0], binarySearchResult[1]);
        }
        
        private static void TestInterpolationalSearch()
        {
            int[] inputData = GetInputData();
            int[] values = GenerateRandomValues(inputData[0], inputData[1]);
            HybridMergeSort.Sort(ref values);
            PrintValues(values);

            int[] interpolationalSearchResults = InterpolationalSearch.Search(values, GetValueToFind());
            PrintResult(interpolationalSearchResults[0], interpolationalSearchResults[1]);
        }
        
        static void Main(string[] args)
        {
            TestBinarySearch();
            // TestInterpolationalSearch();
        }
    }
}