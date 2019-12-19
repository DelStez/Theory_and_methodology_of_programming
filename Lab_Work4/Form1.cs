using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_Work4
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private int[] GetPrefix(string s, int[] lp)
        {
            lp[0] = 0;
            int i = 1;
            int len = 0;
            while (i < s.Length)
            {
                if (s[i] == s[len])
                {
                    len++;
                    lp[i] = len;
                    i++;
                }
                else
                {
                    if (len != 0) len = lp[len - 1];
                    else { lp[i] = len; i++; }
                }
            }

            return lp;
        }
        private void Easy(string mainSearch, string mainString)
        {
            int count = 0;
            int countN = 0;
            for (int i = 0; i <= (mainString.Length - mainSearch.Length); i++)
            {
                //countN++;
                int j;
                for (j = 0; j < mainSearch.Length; j++)
                {
                    countN++;
                    if (mainString[i + j] != mainSearch[j]) {  break; }
                }
                if (j == mainSearch.Length)
                {
                    richTextBox1.SelectionStart = i;
                    richTextBox1.SelectionLength = mainSearch.Length;
                    richTextBox1.SelectionColor = Color.Red;
                    count++; //countN++;
                }
            }
            
            label4.Text = count.ToString();
            label3.Text = countN.ToString();
        }
        private void KMP(string mainSearch, string mainString)
        {

            int count = 0;
            int countN = 0;
            int j = 0;
            int[] lp = new int[mainSearch.Length];
            int[] pf = GetPrefix(mainSearch, lp);
            int i = 0;
            while(i<mainString.Length)
            {
                countN++;
                if (mainSearch[j] == mainString[i]) 
                {
                    
                    j++;
                    i++;
                }
                if (j == mainSearch.Length)
                {
                    //countN++;
                    j = lp[j - 1];
                    count++;
                }
                else if (i < mainString.Length && mainSearch[j] != mainString[i])
                {
                    //countN++;
                    if (j != 0) {j = lp[j - 1];}
                else i++;
                }
                
            }
            string t = "";
            for (int k = 0; k < pf.Length; k++) 
            {
                t += pf[k].ToString() + " ";
            } 
            label5.Text = count.ToString();
            label6.Text = countN.ToString();
            label13.Text = t;
        }
        private void SearchButton_Click(object sender, EventArgs e)
        {
            string mainString = richTextBox1.Text;
            string substring = SearchSubString.Text;
            Easy(substring, mainString);
            KMP(substring, mainString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.ForeColor = Color.Black;

            if (SearchSubString.Text.Length > 0 && richTextBox1.Text.Length > 0) SearchButton.Enabled = true;
            else SearchButton.Enabled = false;
            if (SearchSubString.Text.Length > 0 || richTextBox1.Text.Length > 0) { button1.Enabled = true; }
            else { button1.Enabled = false; }
        }

        private void SearchSubString_TextChanged(object sender, EventArgs e)
        {
            if(SearchSubString.Text.Length > 0 && richTextBox1.Text.Length > 0) SearchButton.Enabled = true;
            else SearchButton.Enabled = false;
            if (SearchSubString.Text.Length > 0 || richTextBox1.Text.Length > 0) {button1.Enabled = true; }
            else { button1.Enabled = false; }

        }
    }
}
