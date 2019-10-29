using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mouse_ocultar_mostrar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void botao_MouseEnter(object sender, EventArgs e)
        {
            Cursor.Hide(); //aqui quando o mouse passa pelo botao ele some
        }

        private void botao_MouseLeave(object sender, EventArgs e)
        {
            Cursor.Show(); //quando deixa o botao ele aparece
        }
    }
}
