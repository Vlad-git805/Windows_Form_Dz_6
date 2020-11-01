using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public List<Product> prod = new List<Product>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            Form2 form = new Form2(product);

            if (form.ShowDialog() == DialogResult.OK)
            {
                listBox1.Items.Add(product);
                prod.Add(product);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            prod.RemoveAt(listBox1.SelectedIndex);
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3(prod[listBox1.SelectedIndex]);
            form.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 form = new Form4(prod[listBox1.SelectedIndex]);
            if (form.ShowDialog() == DialogResult.OK)
            {
                foreach (var item in prod)
                {
                    listBox1.Items.Remove(item);
                }
                foreach (var item in prod)
                {
                    listBox1.Items.Add(item);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog(); 

            // create file if not exists
            save.CreatePrompt = true;
            save.DefaultExt = ".txt";
            // overwrite file that already exists
            save.OverwritePrompt = true;

            if (save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(save.FileName);
                foreach (var item in prod)
                {
                    writer.Write(item.Name + Environment.NewLine);
                    writer.Write(item.Price + Environment.NewLine);
                    writer.Write(item.Count + Environment.NewLine);
                    writer.Write(item.Country + Environment.NewLine);
                }
                writer.Close(); // close reader
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            open.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            open.Filter = "All Files(*.*)|*.*|Text Files(*.txt)|*.txt||";
            open.FilterIndex = 2;
            open.CheckFileExists = true;

            if (open.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader reader = new StreamReader(open.OpenFile()))
                {
                    while (!reader.EndOfStream)
                    {
                        Product prodd = new Product();
                        prodd.Name = reader.ReadLine();
                        prodd.Price = decimal.Parse(reader.ReadLine());
                        prodd.Count = decimal.Parse(reader.ReadLine());
                        prodd.Country = reader.ReadLine();
                        prod.Add(prodd);
                        listBox1.Items.Add(prodd);
                    }
                }
            }
        }
    }
}
