using System;
using System.Collections.Generic;
using System.Linq;
using BinPacking.packing;

namespace BinPacking
{
    class Program
    {
        static void Main(string[] args)
        {
            int []weights = { 2, 5, 4, 7, 1, 3, 8 };
            int capacity = 10;

            PrintPackingResult(Packing.NextFit(weights, capacity), "Next fit", weights);
            PrintPackingResult(Packing.FirstFit(weights, capacity), "First fit", weights);
            PrintPackingResult(Packing.BestFit(weights, capacity), "Best fit", weights);
            PrintPackingResult(Packing.FirstFitDecreasing(weights, capacity), "First fit decreasing", weights);
        }

        private static void PrintPackingResult(List<List<int>> bins, string algorithmName, int[] weights)
        {
            weights.ToList().ForEach(x => Console.Write(x.ToString() + " "));
            Console.WriteLine();
            Console.WriteLine(algorithmName + ":");
            Console.WriteLine(bins.Count + " bins");
            foreach (var bin in bins)
            {
                Console.Write("[ ");
                foreach (var weight in bin)
                {
                    Console.Write(weight + " "); 
                }
                Console.Write("] ");
            }
            Console.WriteLine();
            Console.WriteLine("==============");
        }
    }
}