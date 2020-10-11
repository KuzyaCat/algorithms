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
        private const int PRIME_NUMBER = 13;
        private double KNUTH_CONST = (Math.Sqrt(5) + 1) / 2;

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
            return currentSize == tableSize;
        }
        
        private int MultiplicationHash(int key)
        {
            return (int)Math.Floor(tableSize * (key * KNUTH_CONST - Math.Floor(key * KNUTH_CONST)));
        }

        private int SecondHash(int key)
        {
            return (PRIME_NUMBER - (key % PRIME_NUMBER)); 
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

        private void DoubleHashing(int index, int key)
        {
            if (IsFull())
            {
                hashTable[index].AddLast(key);
                return;
            }
            
            if (hashTable[index].Count != 0) { 
                int secondIndex = SecondHash(key); 
                int i = 1; 
                while (true) { 
                    int newIndex = (index + i * secondIndex) % tableSize; 
  
                    if (hashTable[newIndex].Count == 0) { 
                        hashTable[newIndex].AddLast(key); 
                        break; 
                    } 
                    i++; 
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
        
        public void Insert(int key)
        {
            int index = MultiplicationHash(key);
            DoubleHashing(index, key);
            // LinearProbling(index, key);
            // Chaining(index, key);
        }
    }
}