using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace minicursomarcio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(textBox1.Text) || Convert.ToDecimal(textBox1.Text) < 540M) //Esse M maiusculo indica que ele será decimal
            {
                MessageBox.Show("Valor do salario precisa ser maior do que o mínimo", "INFORMAÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (Convert.ToDecimal(textBox1.Text) > 27000M)
            {
                MessageBox.Show("Valor do salario não pode ser maior do que o teto nacional.");
            }

            if (Convert.ToDecimal(textBox1.Text) > 1000 && checkBox1.Checked)
            {
                decimal salario = Convert.ToDecimal(textBox1.Text) - 100;

                textBox2.Text = Convert.ToString(salario);


            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime data = new DateTime();
            data = DateTime.Now;

            toolStripStatusLabel1.Text = data.ToLongDateString();

            toolStripStatusLabel2.Text = data.ToLongTimeString();
            
        }

      
    }
}
