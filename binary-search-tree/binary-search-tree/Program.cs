using System;
using System.Linq;

namespace binary_search_tree
{
    class Program
    {
        private static int[] GetInputData()
        {
            Console.WriteLine("Enter max value of element:");
            int maxRangeValue = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("Enter values length:");
            int valuesLength = Convert.ToInt32(Console.ReadLine());

            return new[] {maxRangeValue, valuesLength};
        }
        
        private static int[] GenerateRandomValues(int maxRangeValue, int valuesLength)
        {
            int[] randomValues = new int[valuesLength]; 

            Random randomNumber = new Random();
            for (int i = 0; i < randomValues.Length; i++)
            {
                int randomValue = 0;
                while (randomValues.Contains(randomValue))
                { 
                    randomValue = randomNumber.Next(-1, maxRangeValue);
                }
                randomValues[i] = randomValue;
            }

            return randomValues;
        }
        
        static void Main(string[] args)
        {
            // int[] keys = { 20, 8, 22, 4, 12, 10, 14, 23, 21 };
            int[] inputData = GetInputData();
            int[] keys = GenerateRandomValues(inputData[0], inputData[1]);
            
            BinarySearchTree bst = new BinarySearchTree(keys[0]);

            for (int i = 1; i < keys.Length; i += 1)
            {
                bst.Insert(keys[i]);
            }

            Console.WriteLine(bst);
            int ksm = 4;
            Console.WriteLine("===================");
            Console.WriteLine("Kth smallest (" + ksm + "):");
            Console.WriteLine(bst.KthSmallest(ksm));
            Console.WriteLine("LCR: " + bst.LCR());
            Console.WriteLine("RCL: " + bst.RCL());
            
            Console.WriteLine("===================");
            Console.WriteLine("Balanced BST:");
            bst.Balance();
            Console.WriteLine(bst);
        }
    }
}