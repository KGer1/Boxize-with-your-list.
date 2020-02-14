using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace boxize
{
    public partial class Form1 : Form
    {
        public List<string> adat = new List<string>();
        public Random rnd = new Random();
        bool volt = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (volt == false)
            {
                for (int i = 0; i < 10; i++)
                {
                    adat.Add(Convert.ToString(rnd.Next(99)));
                }
                volt = true;
            }
            else { MessageBox.Show("Already updated."); }

            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(adat.ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            object myValue;
            string message = "Add a new item:", title = "Adding", defvalue="";
            myValue = Interaction.InputBox(message, title, defvalue);
        
            adat.Add(Convert.ToString(myValue));
            comboBox1.Items.Add(myValue);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (adat.Count==0)
            {
                MessageBox.Show("There are no items in your list to be deleted.");
            }
            else
            {
                comboBox1.Items.Clear();
                adat.Clear();
                volt = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int num = comboBox1.Items.Count;
            int selectedindex = comboBox1.SelectedIndex;

            try
            {
                if (num < 1) { MessageBox.Show("List is empty."); }
                else { comboBox1.Items.RemoveAt(selectedindex); comboBox1.Text = ""; }
                adat.RemoveAt(selectedindex);
            }
            catch (Exception)
            {
                MessageBox.Show("Select an item.");
            }
        }
    }
}
