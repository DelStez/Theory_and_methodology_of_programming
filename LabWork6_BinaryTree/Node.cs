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
        //public int x, y;
        //public int value;
        //public Node left;
        //public Node right;


        //public Node(int x, int y)
        //{
        //    this.x = x;
        //    this.y = y;

        //}

    }

    //class Tree
    //{
    //    Bitmap map;
    //    Pen MainBlackPen;
    //    Pen AddonRedPen;
    //    Pen PathDarkBlue;
    //    Graphics graphsM;
    //    Font VertexName;
    //    Brush br;
    //    PointF point;
    //    public int R = 10;
    //    public Tree(int Widht, int Height)
    //    {
    //        map = new Bitmap(Widht, Height);
    //        MainBlackPen = new Pen(Color.Black, 2);
    //        AddonRedPen = new Pen(Color.Red, 2);
    //        PathDarkBlue = new Pen(Color.DarkBlue, 5);
    //        graphsM = Graphics.FromImage(map);
    //        VertexName = new Font("Arial", 11);
    //        br = Brushes.Black;
    //    }
    //    public Bitmap GetMap()
    //    {
    //        return map;
    //    }
    //    public Node insert(Node root, int v, int x, int y)
    //    {

    //        if (root == null)
    //        {
    //            root = new Node(x, y);
    //            root.value = v;
    //            graphsM.FillEllipse(Brushes.LightGray, x, y, 2 * R, 2 * R);
    //            graphsM.DrawEllipse(MainBlackPen, x, y, 2 * R, 2 * R);
    //            graphsM.DrawString(v.ToString(), VertexName, br, x, y);

    //        }
    //        else if (v < root.value)
    //        {
               
    //            root.left = insert(root.left, v, x+20 , y + 20);
    //            graphsM.FillEllipse(Brushes.LightGray, x, y, 2 * R, 2 * R);
    //            graphsM.DrawEllipse(MainBlackPen, x, y, 2 * R, 2 * R);
    //            graphsM.DrawString(v.ToString(), VertexName, br, x+20, y+20);
    //        }
    //        else
    //        {
    //            root.right = insert(root.right, v, x-20, y+20);
    //            graphsM.FillEllipse(Brushes.LightGray, x-20, y+20, 2 * R, 2 * R);
    //            graphsM.DrawEllipse(MainBlackPen, x-20, y+20, 2 * R, 2 * R);
    //            graphsM.DrawString(v.ToString(), VertexName, br, x-20, y+20);
    //        }

    //        return root;
    //    }

    //    public void traverse(Node root)
    //    {
    //        if (root == null)
    //        {
    //            return;
    //        }

    //        traverse(root.left);
    //        traverse(root.right);
    //    }
    //}
}
