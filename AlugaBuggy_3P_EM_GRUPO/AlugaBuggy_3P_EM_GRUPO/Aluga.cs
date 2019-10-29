using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AlugaBuggy_3P_EM_GRUPO
{
    public partial class Aluga : Form
    {
        public Aluga()
        {
            InitializeComponent();
        }

        private void Aluga_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Restart(); //reinicia a aplicação

            //fecha form actual
           // this.Close();



        }
    }
}
