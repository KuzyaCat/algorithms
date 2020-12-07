using System;
using System.Linq;

namespace hashing
{
    class Program
    {
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
        
        private static int[] GetInputData()
        {
            Console.WriteLine("Enter table size:");
            int tableSize = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("Enter max value of element:");
            int maxRangeValue = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("Enter values length:");
            int valuesLength = Convert.ToInt32(Console.ReadLine());

            return new[] {tableSize, maxRangeValue, valuesLength};
        }

        private static void Hashing()
        {
            int[] inputData = GetInputData();
            int[] values = GenerateRandomValues(inputData[1], inputData[2]);

            Hashing hashTable1 = new Hashing(inputData[0]);
            Hashing hashTable2 = new Hashing(inputData[0]);

            for (int i = 0; i < values.Length; i += 1)
            {
                hashTable1.Insert(values[i]);
            }
            hashTable1.DisplayHash();
            
            Console.WriteLine("========================");
            Console.WriteLine("My Knuth const:");
            
            for (int i = 0; i < values.Length; i += 1)
            {
                hashTable2.Insert(values[i], true);
            }
            hashTable2.DisplayHash();
        }

        static void Main(string[] args)
        {
            Hashing();
        }
    }
}