using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using InsertionSort = sorting.sorts.InsertionSort;
using HybridQuickSort = sorting.sorts.HybridQuickSort;
using HybridMergeSort = sorting.sorts.HybridMergeSort;

namespace sorting
{
    class SortCreator
    {
        private const int MinK = 4;
        private const int MaxK = 24;
        private const int ArraysCount = 100;
        
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

        private static int[] GetInputData()
        {
            Console.WriteLine("Enter max value:");
            int maxRangeValue = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("Enter values length:");
            int valuesLength = Convert.ToInt32(Console.ReadLine());

            return new[] {maxRangeValue, valuesLength};
        }

        private static void PrintValues(int[] values)
        {
            Console.WriteLine("Sorted array:");
            values.ToList().ForEach(i => Console.Write(i.ToString() + ' '));
        }

        private static void Insertion()
        {
            int[] inputData = GetInputData();
            int[] values = GenerateRandomValues(inputData[0], inputData[1]);
            InsertionSort.Sort(ref values, 0, values.Length - 1);
            PrintValues(values);
        }

        private static void Quick()
        {
            int[] inputData = GetInputData();
            int[] values = GenerateRandomValues(inputData[0], inputData[1]);
            HybridQuickSort.Sort(ref values);
            PrintValues(values);
        }
        
        private static void Merge()
        {
            int[] inputData = GetInputData();
            int[] values = GenerateRandomValues(inputData[0], inputData[1]);
            HybridMergeSort.Sort(ref values);
            PrintValues(values);
        }
        
        private static void TestQuickCycle()
        {
            int[] inputData = GetInputData();

            List<long> times = new List<long>();
            for (int k = MinK; k < MaxK; k += 1)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                for (int i = 0; i < ArraysCount; i += 1)
                {
                    int[] values = GenerateRandomValues(inputData[0], inputData[1]);
                    HybridQuickSort.Sort(ref values, k);
                }
                stopwatch.Stop();
                Console.WriteLine("k = " + k + ' ' + stopwatch.ElapsedMilliseconds);
                times.Add(stopwatch.ElapsedMilliseconds);
            }
            
            Console.WriteLine("Optimal k = " + (times.IndexOf(times.Min(el => el)) + 4));
        }
        
        private static void TestMergeCycle()
        {
            int[] inputData = GetInputData();
            
            List<long> times = new List<long>();
            for (int k = MinK; k < MaxK; k += 1)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                for (int i = 0; i < ArraysCount; i += 1)
                {
                    int[] values = GenerateRandomValues(inputData[0], inputData[1]);
                    HybridMergeSort.Sort(ref values, k);
                }
                stopwatch.Stop();
                Console.WriteLine("k = " + k + ' ' + stopwatch.ElapsedMilliseconds);
                times.Add(stopwatch.ElapsedMilliseconds);
            }
            
            Console.WriteLine("Optimal k = " + (times.IndexOf(times.Min(el => el)) + 4));
        }
        
        private static void TestQuick()
        {
            int[] inputData = GetInputData();
            Stopwatch stopwatch = new Stopwatch();
            
            stopwatch.Start();
            for (int i = 0; i < ArraysCount; i += 1)
            {
                int[] values = GenerateRandomValues(inputData[0], inputData[1]);
                HybridQuickSort.Sort(ref values);
            }
            stopwatch.Stop();
            
            Console.WriteLine("Time: " + stopwatch.ElapsedMilliseconds);
        }
        
        private static void TestMerge()
        {
            int[] inputData = GetInputData();
            Stopwatch stopwatch = new Stopwatch();
            
            stopwatch.Start();
            for (int i = 0; i < ArraysCount; i += 1)
            {
                int[] values = GenerateRandomValues(inputData[0], inputData[1]);
                HybridMergeSort.Sort(ref values);
            }
            stopwatch.Stop();
            
            Console.WriteLine("Time: " + stopwatch.ElapsedMilliseconds);
        }
        
        static void Main(string[] args)
        {
            // Insertion();
            // Quick(); 
            // Merge();
            // TestQuick();
            // TestQuickCycle();
            // TestMerge();
            TestMergeCycle();
        }
    }
}

// HybridQuickSort: optimal k = 4 (x7), 5 (x1)
// k = 4 3668280
// k = 5 3676970
// k = 6 9523240
// k = 7 4427620
// k = 8 8029080
// k = 9 5649860
// k = 10 9908800
// k = 11 6394530
// k = 12 8014690
// k = 13 10141050
// k = 14 14314400
// Optimal k = 4

// HybridMergeSort: optimal k = 12 (x5), 9 (x2), 8 (x1)
// k = 4 2423680
// k = 5 2284980
// k = 6 2282950
// k = 7 2289790
// k = 8 2267840
// k = 9 2287440
// k = 10 2340630
// k = 11 2279030
// k = 12 2261040
// k = 13 2306750
// k = 14 2298150
// k = 15 2277630
// k = 16 2388060
// k = 17 2332290
// k = 18 2291380
// k = 19 2496070
// k = 20 2297910
// k = 21 2279180
// k = 22 2338330
// k = 23 2326380
// Optimal k = 12




