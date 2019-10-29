using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace testeBARRASTATUS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int contadorBarra = 0;
        string [] arquivos_copiados = new string [100];

        private void timer1_Tick(object sender, EventArgs e)
        {//nesse timertick ele conta por segundo

            if (contadorBarra < 100) //aqui poe a condição do contador ir incrementando a barra enquanto ele for menor que cem
            {
                carregando.Visible = true; //visualizar o gif

                barra.Value += 1; //aqui incrementa a barra
                contadorBarra++; //aqui incrementa o contador
                if (contadorBarra == 30) //aqui eu texto se o arquivo ou a operação foi realizada. Podemos testar arquivos com fileexists
                {
                    arquivos_copiados[0] = "Primeiro arquivo"; //ao dar positivo o teste, ele muda a label
                    lblStatus.Text = arquivos_copiados[0];
                }

                if (contadorBarra == 60)
                {
                    arquivos_copiados[1] = "Segundo arquivo";
                    lblStatus.Text = arquivos_copiados[1];
                }

                if (contadorBarra == 80)
                {
                    arquivos_copiados[2] = "Terceiro arquivo"; //ao dar positivo o teste, ele muda a label
                    lblStatus.Text = arquivos_copiados[2];
                }


            }
            else //aqui finalizamos
            {
                carregando.Visible = false;

                timer1.Stop();

                arquivos_copiados[3] = "Todos os arquivos copiados";
                lblStatus.Text = arquivos_copiados[3];
                MessageBox.Show("Finalizado");
            }

        }

        private void btnComecar_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
