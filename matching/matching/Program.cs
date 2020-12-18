using System;
using matching.constants;
using matching.utils;

namespace matching
{
    class Program
    {
        static void Main(string[] args)
        {
            Matching matching = new Matching(GraphExamples.MATCHING_WITH_ONE_OCCUPIED);
            Print.PrintMatching(matching.GetMatches());
            Print.PrintEmployeeAssignments(matching.AssignEmployees());
        }
    }
}