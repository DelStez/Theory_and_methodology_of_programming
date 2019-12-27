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
            workSpace.Image = td.DrawTree(tree, NodeList);
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
                textBox1.Text = textBox1.Text.Replace(keyDelete.ToString(), "").Replace("  "," ");
                if (NodeList.Count !=0 ) 
                {
                    if (textBox1.Text[textBox1.Text.Length - 1] == ' ') textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
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
                    return Find(key, parent.LeftNode);
                }
            }
            return null;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Node node = Find(Convert.ToInt32(textBox2.Text));
        }


    }
}
