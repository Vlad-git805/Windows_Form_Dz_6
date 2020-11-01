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
    public partial class Form3 : Form
    {

        public Product Product { get; set; }
        public Form3(Product product)
        {
            InitializeComponent();
            this.Product = product;

            textBox1.Text = "Name: " + product.Name + "; Price: " + product.Price + "; Quantity in stock: " + product.Count + "; Country of manufacture: " + product.Country;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
