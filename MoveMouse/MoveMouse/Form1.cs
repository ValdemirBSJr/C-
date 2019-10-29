using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading; //as duas classes que precisamos
using System.IO;
using System.Runtime.InteropServices;

namespace MoveMouse
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //variaveis globais
        string hora, minuto, segundo;
        int tempo;

        //#######################   MUIDO QUE DESABILITA O DESCANSO DE TELA
        [DllImport("kernel32.dll")]
        static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);

        [FlagsAttribute]
        enum EXECUTION_STATE : uint
        {
            ES_AWAYMODE_REQUIRED = 0x00000040,
            ES_CONTINUOUS = 0x80000000,
            ES_DISPLAY_REQUIRED = 0x00000002,
            ES_SYSTEM_REQUIRED = 0x00000001
        }


        public static void DesativaProtetor() //metodo que desativa o descanso de tela
        {
            SetThreadExecutionState(EXECUTION_STATE.ES_DISPLAY_REQUIRED | EXECUTION_STATE.ES_CONTINUOUS);
        }

        public static void AtivaProtetor() //metodo que ativa o descanso de tela
        {
            SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS);
        }


        //#####################################
        

        private void btnMover_Click(object sender, EventArgs e)
        {
            try
                {
            if ((txtMinutos.Text == String.Empty) || (Convert.ToInt16(txtMinutos.Text) < 1) || (Convert.ToInt16(txtMinutos.Text) > 9))
                {

                    timer1.Interval = 2000 * 60;
                    timer1.Start();
                    txtMinutos.Text = "2";
                    txtMinutos.Enabled = false;

                    //Aqui pegamos os valores pra montar o contador
                    hora = DateTime.Now.ToString("hh");
                    minuto = DateTime.Now.ToString("mm");
                    segundo = DateTime.Now.ToString("ss");

                //Aqui habilita o gif e a label
                    imgWork.Visible = true;
                    lblMenWork.Visible = true;

                    DesativaProtetor(); //Chamada para desativar descanso de tela

                    contador.Start();
                }

            else
            {

                timer1.Interval = Convert.ToInt16(txtMinutos.Text) * (1000 * 60);
                timer1.Start();
                txtMinutos.Enabled = false;

                //Aqui pegamos os valores pra montar o contador
                hora = DateTime.Now.ToString("hh");
                minuto = DateTime.Now.ToString("mm");
                segundo = DateTime.Now.ToString("ss");

                DesativaProtetor(); //Chamada para desativar descanso de tela

                //Aqui habilita o gif e a label
                imgWork.Visible = true;
                lblMenWork.Visible = true;
                
                contador.Start();
            }

            }
                catch (Exception ex)
                {
                    MessageBox.Show("Olá, o número que você imputou não é válido! Apenas aceitamos números inteiros de 1 a 9. Erro: " + ex.Message, "Erro ao imputar tempo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMinutos.Text = "2";
                }
            

          

        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
              //Recebendo os valores de X e Y da tela...
            int X = Form.MousePosition.X - 25;      
            int Y = Form.MousePosition.Y - 30 ;    
            // Imprimindo os valores em um Label em tempo real...
            label2.Text =  Convert.ToString(X) + " horizontal";
            label2.Refresh();

            label4.Text = Convert.ToString(Y) + " vertical";
            label4.Refresh();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            try
            {
               // GravaArquivo.EscreveTxt(); 
            }

            catch (Exception ex)
            {
                MessageBox.Show("Erro na escrita ao documento! Favor entrar em contato com o desenvolvedor. Código do erro: " + ex.Message, "ERRO AO GRAVAR NO ARQUIVO.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
        }

        private void btnParar_Click(object sender, EventArgs e)
        {
            txtMinutos.Enabled = true;
            timer1.Stop(); //Encerra
            contador.Stop();
            lblCronometro.Text = "--:--:--";

            AtivaProtetor(); //metodo para ativar o descanso de tela

            //Aqui desabilita o gif e a label
            imgWork.Visible = false;
            lblMenWork.Visible = false;

            MessageBox.Show("Finalizado!", "Finalizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtMinutos_MouseEnter(object sender, EventArgs e)
        {
             
            // Define o texto da ToolTip 
            toolTip1.SetToolTip(this.txtMinutos, "Digite número inteiro entre 1 e 9");
        }

        private void label6_MouseEnter(object sender, EventArgs e)
        {
            // Define o texto da ToolTip 
            toolTip1.SetToolTip(this.label6, "Digite número inteiro entre 1 e 9");
        }

        private void Form1_Load(object sender, EventArgs e)
        {//aqui instanciamos o objeto que vai receber a mensagem 'n' desabilita os botões para que não dê erro pois não é possíve gerar nem abrir o arquivo txt
            Mensagem mensa = new Mensagem();
            //Aqui chamamos o método grava txt
          //  GravaArquivo.GravaTxt(mensa);
            //MessageBox.Show(mensa.Mensa);
            
            if (mensa.Mensa == "n")
            {
                btnMover.Enabled = false;
            }
            else
            {
                btnMover.Enabled = true;
            }
                
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //if (File.Exists(System.Windows.Forms.Application.StartupPath + @"\EmpataBloqueio.txt"))
            //{
            //    //Ao fechar o form. Apaga o arquivo Empata bloqueio
            //    File.Delete(System.Windows.Forms.Application.StartupPath + @"\EmpataBloqueio.txt");
            //}
            //else
            //{
            //    MessageBox.Show("Não foi possível apagar o arquivo de log e controle de bloqueio! Favor apagar manualmente! O arquivo está no drive \"D\". Nome: EmpataBloqueio.txt.", "ERRO AO APAGAR ARQUIVO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            AtivaProtetor(); //metodo para ativar o descanso de tela

            //Aqui desabilita o gif e a label
            imgWork.Visible = false;
            lblMenWork.Visible = false;
        }

        private void relogio_Tick(object sender, EventArgs e)
        {
            lblRelogio.Text = DateTime.Now.ToLongTimeString();
        }

        private void contador_Tick(object sender, EventArgs e)
        {
            tempo += 1; //aqui decrementa o tempo em segundos. cada loop diminui um segundo, mas é variavel inteira



            TimeSpan tempoConvertido = TimeSpan.FromSeconds(tempo); //aqui crio um timespan que vai pegar o inteiro e converter em segundos
            string tempoString = tempoConvertido.ToString("hh':'mm':'ss"); //aqui se converte a timespan em string para que seja exibida na label


            //lblcontador.Text = tempo.ToString(); //aqui podemos jogar o string direto para a label
            lblCronometro.Text = tempoString;
        }

        private void label5_MouseEnter(object sender, EventArgs e)
        {
            toolTip2.SetToolTip(this.label5, "Criado por Valdemir para DTC-JPA. Contato: valdemir.junior2@net.com.br");
        }



        
    }
}
