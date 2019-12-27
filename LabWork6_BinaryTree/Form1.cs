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

        public List<int> NodeList = new List<int>();
        Tree g;
        public static double l = 50.0; 
        public static List<string> UsesVertex = new List<string>();
        public Form1()
        {
            InitializeComponent();
            g = new Tree(workSpace.Width, workSpace.Height);
            workSpace.Image = g.GetMap();
        }

        private void drawEdgeButton_Click(object sender, EventArgs e)
        {
            int Level = 1;
            int x = workSpace.Width /2;
            int y =  0;
            Node root = null;
            //Tree bst = new Tree(workSpace.Width, workSpace.Height);
            NodeList = textBox1.Text.ToString().Split().Select(int.Parse).ToList();
            for (int i = 0; i < NodeList.Count; i++)
            {
                root = g.insert(root, NodeList[i], x, y); 
            }
            workSpace.Image = g.GetMap();
        }

    
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0) drawEdgeButton.Enabled = false;
            else drawEdgeButton.Enabled = true;
        }
    }
}
