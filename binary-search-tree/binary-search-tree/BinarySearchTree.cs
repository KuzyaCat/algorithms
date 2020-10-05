using System;

namespace binary_search_tree
{

    public class BinarySearchTree
    {
        private Node _root;
        private int _length;

        public BinarySearchTree()
        {
            _root = null;
            _length = 0;
        }

        public BinarySearchTree(int data)
        {
            _root = new Node(data);
            _length = 1;
        }

        public Node GetRoot()
        {
            return _root;
        }

        public int GetLength()
        {
            return _length;
        }

        public Node Insert(int data)
        {
            _length += 1;
            
            if (_root == null)
            {
                _root = new Node(data);
                return _root;
            }
            
            return Insert(_root, data);
        }

        private Node Insert(Node node, int data)
        {
            if (node == null)
            {
                return new Node(data);
            }
            if (data < node.data)
            {
                node.Left = Insert(node.Left, data);
                node.LeftCount += 1;
            }
            else if (data > node.data)
            {
                node.Right = Insert(node.Right, data);
            }
            
            node.Height = 1 + Math.Max(
                GetNodeHeight(node.Left),
                GetNodeHeight(node.Right)
            );

            return node;
        }

        public Node KthSmallest(int k)
        {
            if (_root == null)
            {
                return null;
            }

            return KthSmallest(_root, k);
        }

        private Node KthSmallest(Node node, int k)
        {
            int count = node.LeftCount + 1;
            if (count == k)
            {
                return node;
            }

            if (count > k)
            {
                return KthSmallest(node.Left, k);
            }
            return KthSmallest(node.Right, k - count);
        }

        public override string ToString()
        {
            if (_root == null)
            {
                return "Empty tree";
            }

            return "Length: " + _length.ToString() + '\n' + _root.ToString();
        }

        public string LCR()
        {
            string log = "";
            
            if (_root == null)
            {
                return "The tree is empty";
            }
            
            LCR(_root, ref log);

            return log;
        }

        private void LCR(Node node, ref string log)
        {
            if (node != null)
            {

                if (node.Left != null)
                {
                    
                    LCR(node.Left, ref log);
                }
                
                log += node.data.ToString() + ' ';

                if (node.Right != null)
                {
                    LCR(node.Right, ref log);
                }
            }
        }
        
        public string RCL()
        {
            string log = "";
            
            if (_root == null)
            {
                return "The tree is empty";
            }
            
            RCL(_root, ref log);

            return log;
        }

        private void RCL(Node node, ref string log)
        {
            if (node != null)
            {
                if (node.Right != null)
                {
                    RCL(node.Right, ref log);
                }
                
                log += node.data.ToString() + ' ';

                if (node.Left != null)
                {
                    
                    RCL(node.Left, ref log);
                }
            }
        }

        private int GetNodeHeight(Node node)
        {
            if (node == null)
            {
                return -1;
            }
            return node.Height;
        }
        
        private int GetBalance(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            return GetNodeHeight(node.Left) - GetNodeHeight(node.Right);
        }
        
        private Node RotateRight(Node node)
        {
            Node leftTemp = node.Left;

            node.Left = leftTemp.Right;
            leftTemp.Right = node;

            node.Height = 1 + Math.Max(
                GetNodeHeight(node.Left),
                GetNodeHeight(node.Right)
            );
            leftTemp.Height = 1 + Math.Max(
                GetNodeHeight(leftTemp.Left),
                GetNodeHeight(leftTemp.Right)
            );

            return leftTemp;
        }

        private Node RotateLeft(Node node)
        {
            Node rightTemp = node.Right;

            node.Right = rightTemp.Left;
            rightTemp.Left = node;

            node.Height = 1 + Math.Max(
                GetNodeHeight(node.Left),
                GetNodeHeight(node.Right)
            );
            rightTemp.Height = 1 + Math.Max(
                GetNodeHeight(rightTemp.Left),
                GetNodeHeight(rightTemp.Right)
            );

            return rightTemp;
        }

        private Node RotateLeftRight(Node node)
        {
            node.Left = RotateLeft(node.Left);

            return RotateRight(node);
        }

        private Node RotateRightLeft(Node node)
        {
            node.Right = RotateRight(node.Right);

            return RotateLeft(node);
        }
    }
}