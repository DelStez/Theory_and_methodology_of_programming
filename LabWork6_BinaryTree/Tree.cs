using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork6_BinaryTree
{
    public class Tree
    {
        private Node root;
        private int deepth;



        public Tree()
        {
            root = null;
            deepth = 0;
        }

        public Node Root { get => root; set => root = value; }
        public int Deepth
        {
            get => deepth;

            set
            {
                if (Deepth < value)
                {
                    this.deepth = value;
                }
            }
        }

        private Node SearchNode(int keyValue)
        {
            Node currentNode = this.Root;

            while (currentNode != null && currentNode.KeyValue != keyValue)
            {
                int key = currentNode.KeyValue;
                if (keyValue > key)
                {
                    currentNode = currentNode.RightNode;
                }
                else
                {
                    currentNode = currentNode.LeftNode;
                }
            }

            return currentNode;
        }

        private Node CreateNode(int keyValue)
        {
            Node currentNode = this.root;
            Node oldNode = null;

            while (currentNode != null)
            {
                oldNode = currentNode;
                if (keyValue < currentNode.KeyValue)
                {
                    currentNode = currentNode.LeftNode;
                }
                else
                {
                    currentNode = currentNode.RightNode;
                }
            }
            return AddNode(keyValue, oldNode);
        }

        private Node AddNode(int keyValue, Node oldNode)
        {
            Node newNode = new Node(oldNode, keyValue);
            if (oldNode == null)
            {
                Root = newNode;
            }
            else if (keyValue > oldNode.KeyValue)
            {
                oldNode.RightNode = newNode;
            }
            else
            {
                oldNode.LeftNode = newNode;
            }
            Deepth = newNode.Deepth;
            return newNode;
        }

        private bool Exists(int keyValue, out Node foundNode)
        {
            foundNode = SearchNode(keyValue);
            return foundNode != null;
        }

        public bool Exists(int keyValue)
        {
            return Exists(keyValue, out Node FoundNode);
        }

        public Node Add(int keyValue)
        {
            Node newNode;
            if (Exists(keyValue, out newNode) == false)
            {
                newNode = CreateNode(keyValue);
            }
            return newNode;
        }

    }
}
