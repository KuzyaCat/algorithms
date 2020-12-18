using System;
using System.Collections.Generic;

namespace matching.utils
{
    public class Print
    {
        public static void PrintMatching(int[] matches)
        {
            Console.Write("Tasks    :");
            for (int i = 0; i < matches.Length; i += 1)
            {
                Console.Write(" " + i);
            }
            Console.WriteLine();
            
            Console.Write("Employees:");
            foreach (var match in matches)
            {
                if (match == -1)
                {
                    Console.Write(" no");
                }
                else
                {
                    Console.Write(" " + match);
                }
            }
            Console.WriteLine();
        }

        public static void PrintEmployeeAssignments(List<(int, int)> assignments)
        {
            foreach (var assignment in assignments)
            {
                Console.WriteLine("Employee " + assignment.Item2 + " is assigned to task " + assignment.Item1);
            }
        }
    }
}