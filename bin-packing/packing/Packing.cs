using System;
using System.Collections.Generic;

namespace BinPacking.packing
{
    public class Packing
    {
        public static List<List<int>> NextFit(int[] weights, int capacity)
        {
            List<List<int>> bins = new List<List<int>>();
            bins.Add(new List<int>());
            int binRemaining = capacity;
 
            for (int i = 0; i < weights.Length; i += 1)
            {
                if (weights[i] > binRemaining)
                {
                    bins.Add(new List<int>());
                    bins[bins.Count - 1].Add(weights[i]);
                    binRemaining = capacity - weights[i];
                }
                else
                {
                    binRemaining -= weights[i];
                    bins[bins.Count - 1].Add(weights[i]);
                }

            }
            return bins;
        }
        
        public static List<List<int>> FirstFit(int[] weights, int capacity)
        {
            List<List<int>> bins = new List<List<int>>();
            bins.Add(new List<int>());

            int[] binsRemaining = new int[weights.Length];
            Array.Fill(binsRemaining, capacity);

            for (int i = 0; i < weights.Length; i += 1)
            {
                int j;
                for (j = 0; j < bins.Count; j += 1)
                {
                    if (binsRemaining[j] >= weights[i])
                    {
                        binsRemaining[j] -= weights[i];
                        bins[j].Add(weights[i]);
                        break;
                    }
                }

                if (j == bins.Count)
                {
                    bins.Add(new List<int>());
                    binsRemaining[bins.Count - 1] = capacity - weights[i];
                    bins[bins.Count - 1].Add(weights[i]);
                }
            }

            return bins;
        }
        
        public static List<List<int>> BestFit(int[] weights, int capacity)
        {
            List<List<int>> bins = new List<List<int>>();
            bins.Add(new List<int>());

            int[] binsRemaining = new int[weights.Length];
            Array.Fill(binsRemaining, capacity);

            for (int i = 0; i < weights.Length; i += 1)
            {
                int j;
                int min = capacity + 1;
                int minIndex = 0;
 
                for (j = 0; j < bins.Count; j += 1) {
                    if (binsRemaining[j] >= weights[i] && binsRemaining[j] - weights[i] < min) {
                        minIndex = j;
                        min = binsRemaining[j] - weights[i];
                    }
                }
                
                if (min == capacity + 1) {
                    bins.Add(new List<int>());
                    bins[bins.Count - 1].Add(weights[i]);
                    binsRemaining[bins.Count - 1] = capacity - weights[i];
                }
                else
                {
                    binsRemaining[minIndex] -= weights[i];
                    bins[minIndex].Add(weights[i]);
                }
            }

            return bins;
        }

        public static List<List<int>> FirstFitDecreasing(int[] weights, int capacity)
        {
            Array.Sort(weights);
            Array.Reverse(weights);
            
            return FirstFit(weights, capacity);
        }
    }
}