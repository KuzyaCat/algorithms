using System;
using System.Collections.Generic;
using System.Linq;

namespace hashing
{
    public class Hashing
    {
        private LinkedList<int>[] hashTable;
        private int currentSize;
        private int tableSize;
        private const int PRIME_NUMBER = 7;
        private double KNUTH_CONST = (Math.Sqrt(5) + 1) / 2;
        private double MY_KNUTH_CONST = (
            2 +
            Math.Pow(116 + 12 * Math.Sqrt(93), 1.0 / 3) +
            Math.Pow(116 - 12 * Math.Sqrt(93), 1.0 / 3)
            ) / 6; // 1,47

        public Hashing(int size)
        {
            tableSize = size;
            hashTable = new LinkedList<int>[tableSize];
            currentSize = 0;
            for (int i = 0; i < tableSize; i += 1)
            {
                hashTable[i] = new LinkedList<int>();
            }
        }

        private bool IsFull()
        {
            return currentSize >= tableSize;
        }
        
        private int MultiplicationHash(int key, bool useOwnConst = false)
        {
            double MULTIPLY_CONSTANT = useOwnConst ? MY_KNUTH_CONST : KNUTH_CONST;
            return (int) Math.Floor(tableSize * (key * MULTIPLY_CONSTANT - Math.Floor(key * MULTIPLY_CONSTANT)));
        }

        private int SecondHash(int key)
        {
            return (PRIME_NUMBER - (key % PRIME_NUMBER)); 
        }

        private void DoubleHashing(int index, int key)
        {
            if (IsFull())
            {
                hashTable[index].AddLast(key);
                currentSize += 1;
                return;
            }
            
            int secondIndex = SecondHash(key);

            if (hashTable[index].Count != 0) { 
                int i = 1; 
                while (true) { 
                    int newIndex = (index + i * secondIndex) % tableSize; 
  
                    if (hashTable[newIndex].Count == 0) {
                        hashTable[newIndex].AddLast(key); 
                        break; 
                    } 
                    i += 1;
                } 
            }
            else
            {
                hashTable[index].AddLast(key);   
            }
            currentSize += 1; 
        }

        private void LinearProbling(int index, int key)
        {
            if (IsFull())
            {
                hashTable[index].AddLast(key);
                currentSize += 1;
                return;
            }
            
            if (hashTable[index].Count != 0) {
                for (int i = index + 1; i < index + tableSize; i += 1)
                {
                    if (hashTable[i % tableSize].Count == 0) { 
                        hashTable[i % tableSize].AddLast(key); 
                        break; 
                    }
                }
            }
            else
            {
                hashTable[index].AddLast(key);   
            }
            
            currentSize += 1; 
        }

        private void Chaining(int index, int key)
        {
            hashTable[index].AddLast(key);
        }
        
        public void Insert(int key, bool UseOwnConst = false)
        {
            int index = MultiplicationHash(key, UseOwnConst);
            DoubleHashing(index, key);
            // LinearProbling(index, key);
            // Chaining(index, key);
        }
        
        public void DisplayHash() 
        {
            for (int i = 0; i < tableSize; i++) {
                if (hashTable[i].Count != 0)
                {
                    Console.Write(i);
                    for (int j = 0; j < hashTable[i].Count; j += 1)
                    {
                        Console.Write(" ---> " + hashTable[i].ElementAt(j));
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine(i);
                }
            } 
        }
    }
}