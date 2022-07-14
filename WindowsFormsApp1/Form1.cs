using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var team = textBox1.Text.Split('\n');
            label1.Text = team.Length.ToString();

            dataGridView1.RowCount = team.Length;
            foreach (var tmp in team.Select((value, index) => (value, index)))
            {
                dataGridView1.Rows[tmp.index].HeaderCell.Value = tmp.value;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            var team = textBox2.Text.Split('\n');
            label2.Text = team.Length.ToString();

            dataGridView1.ColumnCount = team.Length;
            foreach (var tmp in team.Select((value, index) => (value, index)))
            {
                dataGridView1.Columns[tmp.index].Name = tmp.value;
            }     
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (var tmp in textBox2.Text.Split('\n').Select((value, index) => (value, index)))
                {
                    row.Cells[tmp.index].Value = "";
                }
            }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var rand = new Random();
                int r = rand.Next(0, dataGridView1.ColumnCount);
                Thread.Sleep(100);
                Console.WriteLine(r);
                row.Cells[r].Value = "O";
            }
        }
    }
}
