using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Login_PREPARA_PORTIFOLIO_3P
{
    public partial class carregando : Form
    {
        public carregando()
        {
            InitializeComponent();
        }

        int contador = 0;

        private void carregando_Load(object sender, EventArgs e)
        {
            timer1.Start();
            carregando.ActiveForm.Location = Cursor.Position; //aqui carregamos o form onde está o mouse
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            contador++;

            if (contador == 4)
            {

                mensagemFinal.Text = Status.Mensagem;
                mensagemFinal.Visible = true;
                pictureBox1.Visible = false;
            }

            
            if (contador > 7)
            {
                carregando.ActiveForm.Close();

            }

           

        }
    }
}
