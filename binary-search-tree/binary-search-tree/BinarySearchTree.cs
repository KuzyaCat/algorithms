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
        
        public void Insert(int data)
        {
            if (_length == 0)
            {
                _root.data = data;
                return;
            }
            
            Node currentNode = _root;
            _length += 1;

            while (true)
            {
                if (data <= currentNode.data)
                {
                    if (currentNode.Left != null)
                    {
                        currentNode.LeftCount += 1;
                        currentNode = currentNode.Left;
                    }
                    else
                    {
                        Node newNode = new Node(data);
                        currentNode.LeftCount += 1;
                        currentNode.Left = newNode;
                        newNode.Parent = currentNode;
                        break;
                    }
                }
                else
                {
                    if (currentNode.Right != null)
                    {
                        currentNode.RightCount += 1;
                        currentNode = currentNode.Right;
                    }
                    else
                    {
                        Node newNode = new Node(data);
                        currentNode.RightCount += 1;
                        currentNode.Right = newNode;
                        newNode.Parent = currentNode;
                        break;
                    }
                }
            }
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
        
        private int HeightFromNodeToNode(Node startingNode, Node endingNode)
        {
            Node node = startingNode;
            int height = 0;
            while (node.data != endingNode.data)
            {
                height++;
                if (endingNode.data <= node.data)
                {
                    node = node.Left;
                }
                else
                {
                    node = node.Right;
                }
            }

            return height;
        }

        public override string ToString()
        {
            if (_root == null)
            {
                return "Empty tree";
            }

            return "Length: " + _length.ToString() + '\n' + _root.ToString();
        }
        
        private int GetHeight(Node node)
        {
            if (node != null)
            {
                int leftSubtreeHeight = GetHeight(node.Left);
                int rightSubtreeHeight = GetHeight(node.Right);

                if (leftSubtreeHeight > rightSubtreeHeight)
                {
                    return (leftSubtreeHeight + 1);
                }

                return (rightSubtreeHeight + 1);
            }
            
            return 0;
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

        private void RotateLeft(Node mainNode)
        {
            Node rightNode = mainNode.Right;
            Node parent = mainNode.Parent;
            if (rightNode != null)
            {
                Node leftChildOfRightNode = rightNode.Left;
                int leftCount = mainNode.LeftCount;
                int leftCountOfRight = rightNode.LeftCount;
                if (parent != null)
                {
                    if (mainNode.data > parent.data)
                    {
                        parent.Right = rightNode;
                    }
                    else
                    {
                        parent.Left = rightNode;
                    }
                }

                mainNode.Parent = rightNode;
                mainNode.Right = leftChildOfRightNode;
                mainNode.RightCount = leftCountOfRight;
                
                rightNode.Parent = parent;
                rightNode.Left = mainNode;
                rightNode.LeftCount = leftCount + leftCountOfRight + 1;

                if (leftChildOfRightNode != null)
                {
                    leftChildOfRightNode.Parent = mainNode;
                }

                if (parent == null)
                {
                    _root = rightNode;
                }
            }
        }

        private void RotateRight(Node mainNode)
        {
            Node leftNode = mainNode.Left;
            Node parent = mainNode.Parent;
            if (leftNode != null)
            {
                Node rightChildOfLeftNode = leftNode.Right;
                int rightCount = mainNode.RightCount;
                int rightCountOfLeftNode = leftNode.RightCount;
                if (parent != null)
                {
                    if (mainNode.data > parent.data)
                    {
                        parent.Right = leftNode;
                    }
                    else
                    {
                        parent.Left = leftNode;
                    }
                }

                mainNode.Parent = leftNode;
                mainNode.Left = rightChildOfLeftNode;
                mainNode.LeftCount = rightCountOfLeftNode;
                
                leftNode.Parent = parent;
                leftNode.Right = mainNode;
                leftNode.RightCount = rightCount + rightCountOfLeftNode + 1;

                if (rightChildOfLeftNode != null)
                {
                    rightChildOfLeftNode.Parent = mainNode;
                }

                if (parent == null)
                {
                    _root = leftNode;
                }
            }
        }

        public void Balance()
        {
            Balance(_root);   
        }
        
        private void Balance(Node node)
        {
            double middleK = Math.Ceiling((node.LeftCount + node.RightCount + 1) * 0.5);
            Node middleNode = KthSmallest(node, (int) middleK);
            int heightFromNodeToMiddleNode = HeightFromNodeToNode(node, middleNode);
            
            for (int i = 0; i < heightFromNodeToMiddleNode; i++)
            {
                if (middleNode.data <= middleNode.Parent.data)
                {

                    RotateRight(middleNode.Parent);
                }
                else
                {
                    RotateLeft(middleNode.Parent);
                }
            }
            if (middleNode.Left != null && middleNode.Right != null)
            {
                Balance(middleNode.Left);
                Balance(middleNode.Right);
            }
        }
    }
}