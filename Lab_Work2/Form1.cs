using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Lab_Work2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<double> numb = new List<double>();
        int swapping = 0; int comprassion = 0;
        private void Cleaning()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            numb.Clear();
            label1.Text = "Время:   ";
            label2.Text = "Кол-во перестановок:";
            label3.Text = "Кол-во сравнений:";
            label6.Text = "Время:   ";
            label5.Text = "Кол-во перестановок:";
            label4.Text = "Кол-во сравнений:";

        }
        private void QuickSort<T>(T[] data, int left, int right) where T : IComparable<T>
        {
            int i, j;
            T pivot, temp;
            i = left;
            j = right;
            pivot = data[(left + right) / 2];

            do
            {
                while ((data[i].CompareTo(pivot) < 0) && (i < right)) i++;
                while ((pivot.CompareTo(data[j]) < 0) && (j > left)) j--;
                if (i <= j)
                {
                    comprassion++;
                    swapping++;
                    temp = data[i];
                    data[i] = data[j];
                    data[j] = temp;
                    i++;
                    j--;
                }
            } while (i <= j);

            if (left < j){comprassion++; QuickSort(data, left, j);}
            if (i < right){comprassion++; QuickSort(data, i, right);}
        }
        public void CountingVoid(List<double> n2)
        {
            swapping = 0; comprassion = 0;
            var start = DateTime.Now;
            int[] sorted = СoutingSort(n2);
            var spendtime = DateTime.Now - start;
            List<string> tempr = new List<string>();
            for (int i = 0; i < sorted.Length; i++) tempr.Add(Convert.ToString(sorted[i]));
            string g = String.Join("\r\n", tempr);
            textBox3.Text = g;
            label6.Text = "Время:   " + spendtime.TotalMilliseconds +" мс";
            label5.Text = "Кол-во перестановок:" + swapping;
            label4.Text = "Кол-во сравнений:" + comprassion;
        }
        private int[] СoutingSort(List<double> array)
        {
            int[] sortedArray = new int[array.Count];
            int minVal = (int)array[0];
            int maxVal = (int)array[0];
            for (int i = 0; i < array.Count; i++)
            {
                if (array[i] < minVal) { minVal = (int)array[i]; comprassion++; }
                else if (array[i] > maxVal) { maxVal = (int)array[i]; comprassion++; }
            }
            int[] counts = new int[(maxVal - minVal) + 1];
            for (int i = 0; i < array.Count; i++) counts[(int)(array[i] - minVal)]++;
            counts[0]--;
            for (int i = 1; i < counts.Length; i++) counts[i] = counts[i] + counts[i - 1];
            for (int i = array.Count - 1; i >= 0; i--){ sortedArray[counts[(int)(array[i] - minVal)]--] = (int)array[i]; swapping++; }
            return sortedArray;
        }
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            button2.Enabled = true ? textBox1.Text.Length != 0: button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Cleaning();
                button1.Enabled = false;
                string q = File.ReadAllText(openFileDialog1.FileName);
                textBox1.Text = q.Replace(" ", "\r\n");
                string[] texfile = q.Split(new string[] { "\n", " ", "\0" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string Line in texfile)
                {
                    double[] temp = Line.Split(new char[] { '\n', ' ', '\r' }).Select(double.Parse).ToArray();
                    for (int i = 0; i < temp.Length; i++)
                    {
                        numb.Add(temp[i]);
                    }
                }
                button1.Enabled = true;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox3.Clear();
            label1.Text = "Время:   ";
            label2.Text = "Кол-во перестановок:";
            label3.Text = "Кол-во сравнений:";
            label6.Text = "Время:   ";
            label5.Text = "Кол-во перестановок:";
            label4.Text = "Кол-во сравнений:";
            button2.Enabled = false;
            bool doubleDect = false;
            for (int j = 0; j < numb.Count; j++)
            {
                doubleDect = (Math.Abs(numb[j] % 1) <= (double.Epsilon * 100)) ? false : true;
                if (doubleDect) break;
            }
            double[] n = numb.ToArray();

            var Start = DateTime.Now;
            QuickSort(n, 0, numb.Count - 1);
            var spendtime = DateTime.Now - Start;
            List<string>  tempr = new List<string>();
            for (int i = 0; i < n.Length; i++) tempr.Add(Convert.ToString(n[i]));
            string g = String.Join("\r\n", tempr);
            textBox2.Text = g;
            label1.Text = "Время:   " + spendtime.TotalMilliseconds + " мс";
            label2.Text = "Кол-во перестановок:" + swapping;
            label3.Text = "Кол-во сравнений:" + comprassion;
            if (doubleDect)
            {
                string message = "В Файле обнаруруженны вещественные числа. Сортировка с подчётом используется только для" +
                    "натуральных чисел. Для работы сортировки следует удалить вещественные. В противном, сортировка не запустится. Удалить вещественные числа?";
                string capricon = "Внимание!";
                if (MessageBox.Show(message, capricon, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    List<double> n2 = new List<double>();
                    for (int i = 0; i < numb.Count; i++)
                    {
                        if (Math.Abs(numb[i] % 1) <= Double.Epsilon * 100)
                        {
                            n2.Add(numb[i]);
                        }
                    }
                    CountingVoid(n2);

                }

            }
            else CountingVoid(numb);
            button2.Enabled = true;
        }
    }
}
