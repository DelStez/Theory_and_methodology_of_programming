using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Lab_1
{
    public partial class Form1 : Form
    {
        double[] numb;
        int count;
        public Form1()
        {
            InitializeComponent();
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            button2.Enabled = true ? textBox2.Text.Length != 0 && listBox1.Items.Count > 0 : button2.Enabled = false;
        }

        private void TextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char numbersSearch = e.KeyChar;
            if (!Char.IsDigit(numbersSearch) && numbersSearch != 8
                && numbersSearch != 44 && numbersSearch != 45) e.Handled = true;

        }
        private void listBoxSelect(int first, int endNumber)
        {
            listBox1.SelectionMode = SelectionMode.MultiSimple;
            for (int i = first + 1; i < endNumber; i++) listBox1.SetSelected(i, true);
        }

        private void SearchBinary(double key, double[] numb, int leftBoard, int rightBoard)
        {
            while (leftBoard <= rightBoard)
            {
                int midlle = (rightBoard + leftBoard) / 2;
                if (key < numb[midlle]) rightBoard = midlle - 1;
                else if (key > numb[midlle]) leftBoard = midlle + 1;
                if (key == numb[midlle])
                {
                    count++;
                    int l = 1;
                    while (midlle != 0 && key == numb[midlle - l])
                    {
                        count++;
                        l++;
                    }
                    int r = 1;
                    while (midlle != numb.Length - 1 && key == numb[midlle + r])
                    {
                        count++;
                        r++;
                    }
                    listBoxSelect(midlle - l, midlle + r);
                    break;
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var key = Convert.ToDouble(textBox2.Text);
            int rightBoard = numb.Length - 1;
            int leftBoard = 0;
            count = 0;
            listBox1.ClearSelected();
            SearchBinary(key, numb, leftBoard, rightBoard);
            if (count != 0) label1.Text = "Всего найдено:" + Convert.ToString(count);
            else label1.Text = "По запросу " + Convert.ToString(key) + " ничего не найдено.";
        }

        private void WriteTextInListBox(string textFile)
        {
            try
            {
                numb = textFile.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).
                    Select(double.Parse).ToArray();
            }
            catch (System.FormatException)
            {
                MessageBox.Show("В файле есть посторонние символы. Чтение файла не доступно.");
                return;
            }
            Array.Sort(numb);
            for (int i = 0; i < numb.Length; i++)
            {
                listBox1.Items.Add(numb[i].ToString() + "\r\n");
            }

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string lineOfFile, str = " ";
                string textFile = "";
                listBox1.Items.Clear();
                textBox2.Clear();
                label1.Text = " ";
                var sr = new StreamReader(openFileDialog1.FileName);
                if (sr.Peek() > -1)
                {
                    while ((lineOfFile = sr.ReadLine()) != null)
                    {
                        textFile += str + lineOfFile;

                    }
                    WriteTextInListBox(textFile);
                }
                else MessageBox.Show("Файл пуст!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
