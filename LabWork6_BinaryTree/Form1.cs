using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabWork6_BinaryTree
{
    public partial class Form1 : Form

    {
        public string key;
        public List<int> NodeList = new List<int>();
        
        public static double l = 50.0; 
        public static List<string> UsesVertex = new List<string>();
        public Form1()
        {
            InitializeComponent();
            
        }
        private int[] ParseInput()
        {
            string[] input = textBox1.Text.Split(' ');
            int[] res = null;
            if (input.Length > 0)
            {
                res = new int[input.Length];
                for (int i = 0; i < input.Length; i++)
                {
                    if (int.TryParse(input[i], out res[i]) == false)
                    {
                        res = null;
                        break;
                    }
                }
            }
            return res;
        }
        public void Draw(int[] input)
        {
            Tree tree;
            tree = Factory.CreateOrganizedTree(input);
            TreeDraw td = new TreeDraw(2.0);
            workSpace.Image = td.DrawTree(tree);
        }
        private void drawEdgeButton_Click(object sender, EventArgs e)
        {
   
            NodeList = textBox1.Text.ToString().Split().Select(int.Parse).ToList();
            int[] input = ParseInput();
            Draw(input);
          
        }

    
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0) drawEdgeButton.Enabled = false;
            else drawEdgeButton.Enabled = true;
        }

        private void getData_Click(object sender, EventArgs e)
        {
            workSpace.Image = null;
            NodeList.Clear();
            textBox1.Clear();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int keyDelete = Convert.ToInt32(textBox4.Text);
            if (NodeList.Contains(keyDelete))
            {
                NodeList.Remove(keyDelete);
                
                textBox1.Text = string.Join(" ", NodeList.ToArray());
                if (NodeList.Count !=0 ) 
                {
                    
                    int[] input = ParseInput();
                    Draw(input);
                }
                else workSpace.Image = null;
            }
        }
        public Node Find(int key)
        {
            return Find(key, Tree.root);
        }
        public Node Find(int key, Node parent)
        {
            if (parent != null)
            {
                if (key == parent.KeyValue)
                {
                    return parent;
                }
                if (key < parent.KeyValue)
                {
                    return Find(key, parent.LeftNode);
                }
                else
                {
                    return Find(key, parent.RightNode);
                }
            }
            return null;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            label10.Text = "";
            label11.Text = "";
            label4.Text = "";
            label6.Text = "";
            Node node = Find(Convert.ToInt32(textBox2.Text));
            if (node != null)
            {
                workSpace.Image = DrawKey(node, node.Parrent);
                //label11.Text = node.Parrent.KeyValue.ToString();
                label10.Text = "";
                label11.Text += PredSuccessor(node) + " ";
                label10.Text += Successor(node) + " ";
                label4.Text = Max(Tree.root).ToString();
                label6.Text = Min(Tree.root).ToString();
            }


        }
        public int Successor(Node node)
        {
            Node x = node;
            if (node.RightNode != null)
                return Min(node.RightNode);
            Node y = node.Parrent;
            while (y != null && x == node.RightNode)
            {
                x = y;
                y = node.Parrent;
            }
            return y.KeyValue;
        }
        public int PredSuccessor(Node node)
        {
            Node x = node;
            if (node.LeftNode != null)
                return Max(node.LeftNode);
            Node y = node.Parrent;
            while (y != null && x == node.LeftNode)
            {
                x = y;
                y = y.Parrent;
            }
            if(y == null)
            {
                return -1;
            }
            return y.KeyValue;

        }
        public int Max(Node node)
        {
            int max = node.KeyValue;
            while (node.RightNode != null)
            {
                max = node.RightNode.KeyValue;
                node = node.RightNode;
            }
            return max;
        }
        public int Min(Node node)
        {
            int min = node.KeyValue;
            while (node.LeftNode != null)
            {
                min = node.LeftNode.KeyValue;
                node = node.LeftNode;
            }
            return min;
        }
        public Bitmap DrawKey(Node key, Node parrent)
        {
            Tree tree;
            int[] input = ParseInput();
            tree = Factory.CreateOrganizedTree(input);
            TreeDraw td = new TreeDraw(2.0);
            var im = td.DrawTree(tree);
            im = td.KeyNode(im, key, Tree.root, tree);
            return im;
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
    }
}
