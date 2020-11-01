using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form4 : Form
    {
        public Product Product { get; set; }
        public Form4(Product product)
        {
            InitializeComponent();
            this.Product = product;

            textBox1.Text = product.Name;
            numericUpDown2.Value = product.Price;
            numericUpDown3.Value = product.Count;
            comboBox1.Text = product.Country;

            checkBox1.Checked = false;
            button1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Enter valid name!");
                return;
            }
            Product.Name = textBox1.Text;
            Product.Price = numericUpDown2.Value;
            Product.Count = numericUpDown3.Value;
            Product.Country = comboBox1.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            button1.Enabled = checkBox1.Checked;
        }
    }
}
