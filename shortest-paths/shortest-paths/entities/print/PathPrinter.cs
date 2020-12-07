using System;
using System.Collections.Generic;
using System.Linq;

namespace shortest_paths
{
    public class PathPrinter
    {
        public static void PrintPath(List<int[]> path)
        {
            Console.Write(path.ElementAt(0)[0] + " --> ");
            for (int i = 0; i < path.Count - 1; i += 1)
            {
                Console.Write(path.ElementAt(i)[1] + " --> ");
            }
            Console.Write(path.ElementAt(path.Count - 1)[1]);
        }
        
        public static void PrintPath(List<int> path)
        {
            Console.Write(path.ElementAt(0) + " --> ");
            for (int i = 1; i < path.Count - 1; i += 1)
            {
                Console.Write(path.ElementAt(i) + " --> ");
            }
            Console.Write(path.ElementAt(path.Count - 1));
        }
    }
}