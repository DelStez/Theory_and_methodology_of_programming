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

        public static List<int> UsesVertex = new List<int>();
        public Form1()
        {
            InitializeComponent();
        }

        private void drawEdgeButton_Click(object sender, EventArgs e)
        {
            int numberVertex = Convert.ToInt32(textBox1.Text);
            int y = 0;
            while (y < numberVertex) {dataGridView1.Rows.Add(); y++;}

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int temValues = Convert.ToInt32(dataGridView1.CurrentCell.Value.ToString());
            if (UsesVertex.Contains(temValues)) dataGridView1.CurrentCell.Value = "null";
            else 
            {
                UsesVertex.Add(temValues);
            }
        }
    }
}
