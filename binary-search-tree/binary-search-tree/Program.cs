using System;

namespace binary_search_tree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree bst = new BinarySearchTree();
            
            int[] keys = { 20, 8, 22, 4, 12, 10, 14 }; 
  
            foreach (int key in keys)
            {
                bst.Insert(key);
            }

            Console.WriteLine(bst);
            Console.WriteLine(bst.KthSmallest(4));
            Console.WriteLine("LCR: " + bst.LCR());
            Console.WriteLine("RCL: " + bst.RCL());
        }
    }
}