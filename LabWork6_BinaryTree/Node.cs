using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork6_BinaryTree
{
    public class Node
    {
        private Node parrent;
        int X;
        int Y;
        private Node leftNode;
        private Node rightNode;
        private int key;
        private readonly int deepth;

        public Node(Node parrent, int keyValue)
        {
            this.parrent = parrent;
            this.key = keyValue;

            this.LeftNode = null;
            this.RightNode = null;

            if (this.Parrent == null)
            {
                this.deepth = 0;
            }
            else
            {
                this.deepth = this.Parrent.Deepth + 1;
            }
        }

        public Node Parrent => parrent;
        public int KeyValue => key;
        public int Deepth => deepth;
        public Node LeftNode { get => leftNode; set => leftNode = value; }
        public Node RightNode { get => rightNode; set => rightNode = value; }

        public bool IsRoot()
        {
            return this.Parrent == null;
        }

    }
}

   
