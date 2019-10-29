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
                this.Hide();//oculta o carregando
                Form1.ActiveForm.Hide();//oculta o formde login

               // carregando.ActiveForm.Close();

                timer1.Stop(); //para o timepicker

                AlugaBuggy_3P_EM_GRUPO.Aluga formulario = new AlugaBuggy_3P_EM_GRUPO.Aluga(); //pra nunca dar erro ao carregar  form tem que carregar com o namespace (mecanismo de controle da visibilidade de nomes dentro de um programa) e ele não dará erro de referencia ao acesso. Serve pra tudo

                formulario.Show();
                

            }

           

        }
    }
}
