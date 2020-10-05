using System;
using System.Linq;

namespace binary_search_tree
{
    public class Node
    {
        public int data;
        public Node Left { get; set; }
        public Node Right { get; set; }
        public int LeftCount = 0;
        public int Height = 0;
 
        public Node(int data)
        {
            this.data = data;
        }

        public override string ToString()
        {
            string leftString = Left != null ? Left.ToString() : "null";
            string rightString = Right != null ? Right.ToString() : "null";
            string dataString = data != null ? data.ToString() : "null";
            string leftCountString = LeftCount.ToString();
            string heightString = LeftCount.ToString();

            leftString = String.Join("\n", leftString.Split('\n').Select(a => "\t" + a));
            rightString = String.Join("\n", rightString.Split('\n').Select(a => "\t" + a));

            return String.Format("\nData: {0}\n"
                                 + "Left count: {1}\n"
                                 + "Height: {2}\n"
                                 + "Left: {3}\n"
                                 + "Right: {4}",
                dataString, leftCountString, heightString, leftString, rightString);
        }
    }
}