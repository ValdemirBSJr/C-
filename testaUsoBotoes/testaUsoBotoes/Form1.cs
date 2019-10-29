using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace testaUsoBotoes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27) //Tecla Esc na tabela ASCII

            {
                string texto = "TEXTO";
                MessageBox.Show("TECLA ESC PRESSIONADA! VALOR DE VARIÁVEL MANTIDA: "+ texto);
            }
        }
    }
}
