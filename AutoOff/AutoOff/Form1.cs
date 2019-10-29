using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace AutoOff
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Timer relogio = new Timer();

        private void Comecar_Click(object sender, EventArgs e)
        {
            btnParar.Enabled = true;
            Comecar.Enabled = false;
            if ((txtHora.Text == String.Empty && txtMinuto.Text == String.Empty && txtSegundo.Text == String.Empty) || (txtHora.Text == "0" && txtMinuto.Text == "0" && txtSegundo.Text == "0")) //Aqui faço teste para ele não começar com valor zero
            {
                MessageBox.Show("Você deve configurar o temporizador antes de começar! Valores de tempo nulo não serão aceitos.", "FAVOR CONFIGURAR O TIMER", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtHora.Text = "1";
            }
            else
            {

                try
                {

                    //aqui temos o código do contador regressivo

                    int hora, minuto, segundo, tempo;

                    hora = int.Parse(txtHora.Text); //aqui pegamos o objeto que é item do list box e convertemos para string e depois inteiro
                    minuto = int.Parse(txtMinuto.Text);
                    segundo = int.Parse(txtSegundo.Text);

                    //int.Parse(comboBox1.SelectedItem.ToString()); serve para listbox tbm mas nao funciona. Pode mudar para SelectedValue, mas só pega quando delimito valor padrão



                    tempo = segundo + (minuto * 60) + (hora * 3600);

                     relogio = new Timer();
                    relogio.Interval = 1000; // 1000 ms = 1s
                    //int tempo = 10; // 10 segundos

                    relogio.Tick += delegate
                    {
                        tempo -= 1; //aqui decrementa o tempo em segundos. cada loop diminui um segundo, mas é variavel inteira



                        TimeSpan tempoConvertido = TimeSpan.FromSeconds(tempo); //aqui crio um timespan que vai pegar o inteiro e converter em segundos
                        string tempoString = tempoConvertido.ToString("hh':'mm':'ss"); //aqui se converte a timespan em string para que seja exibida na label


                        //lblcontador.Text = tempo.ToString(); //aqui podemos jogar o string direto para a label
                        lblcontador.Text = tempoString;


                        if (tempo == 0)
                        {
                            relogio.Stop();
                            // MessageBox.Show("Você tem 1 minutos para fechar tudo!");
                            //abaixo desliga o sistema

                            Process.Start("Shutdown", "/s /t 20"); //desliga o sistema em 20 segundos **tem que colocar using system diagnostics lá em cima
                        }
                    };
                    relogio.Start();

                }

                catch
                {
                    MessageBox.Show("Erro ao inicializar o aplicativo. O formato de hora pode estar inválido. Horas, minutos e segundos devem ser imputados no formato \"inteiro\"", "ERRO AO IMPUTAR DADOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    txtHora.Text = "1";
                    txtMinuto.Text = "0";
                    txtSegundo.Text = "0";
                }
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
           // DateTime horaAcrescida = DateTime.Now.AddHours(1); //aqui pegamos a hora do sistema e acrescemos mais uma hora
            //txtHora.Text = DateTime.Now.ToString(horaAcrescida);
            //txtHora.Text = DateTime.Now.AddHours(1).ToString("HH"); //**FUNCIONA**aqui pegamos a hora atual e acrescentamos uma hora

            txtHora.Text = "1";

            txtMinuto.Text = DateTime.Now.ToString("mm");
            txtSegundo.Text = DateTime.Now.ToString("ss");
           
            /* ### AQUI USARÍAMOS LISTBOX MAS É BUGADO NÃO CONSEGUI PASSAR O VALOR DE JEITO NENHUM FUI PRA O TEXT BOX QUE FUNCIONA

            string[] horas = { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23","24"};
            lstHora.DataSource = horas; //aqui criamos um array e jogamos ele todo no listbox
            lstHora.SelectedItem = "01";

           

            
            int[] minutos = new int[61];

            for (int x = 0; x < 61; x++) //aqui criamos um form pra preencher o listbox dos minutos
            {
                minutos[x] = x;

            }



            lstMinuto.DataSource = minutos;


            int[]segundos = new int[61];

            for (int x = 0; x < 61; x++) //aqui criamos um form pra preencher o listbox dos segundos
            {
                segundos[x] = x;

            }

            lstSegundo.DataSource = segundos;
             ###### FIM ##########*/ 

        }

        private void horaMais_Click(object sender, EventArgs e)
        { //aqui ei incremento o valor de hora quando clico na imagem
            double valorHora = Convert.ToDouble(txtHora.Text);

            valorHora += 1;

            txtHora.Text = Convert.ToString(Math.Ceiling(valorHora)); //aFunção Math arredonda o numero caso o bonitão invente de por numero quebrado
           
            
        }

        private void horaMenos_Click(object sender, EventArgs e)
        { //aqui eu decremento o valor de hora quando clico na imagem

            double valorHora = Convert.ToDouble(txtHora.Text);

            
            valorHora -= 1;

            

            txtHora.Text = Convert.ToString(Math.Ceiling(valorHora));

        }

        private void minutoMais_Click(object sender, EventArgs e)
        {
            double valorMinuto = Convert.ToDouble(txtMinuto.Text);
            


            valorMinuto += 1;

            txtMinuto.Text = Convert.ToString(Math.Ceiling(valorMinuto));
        }

        private void minutoMenos_Click(object sender, EventArgs e)
        {
            double valorMinuto = Convert.ToDouble(txtMinuto.Text);

            valorMinuto -= 1;

            txtMinuto.Text = Convert.ToString(Math.Ceiling(valorMinuto));
        }

        private void segundoMais_Click(object sender, EventArgs e)
        {
            double valorSegundo = Convert.ToDouble(txtSegundo.Text);

            valorSegundo += 1;

            txtSegundo.Text = Convert.ToString(Math.Ceiling(valorSegundo));
        }

        private void segundoMenos_Click(object sender, EventArgs e)
        {
            double valorSegundo = Convert.ToDouble(txtSegundo.Text);

            valorSegundo -= 1;

            txtSegundo.Text = Convert.ToString(Math.Ceiling(valorSegundo));
        }

        private void txtHora_TextChanged(object sender, EventArgs e)
        {//eventos que ocorrem quando o texto mudar

            double valorMax;

            if (txtHora.Text == String.Empty) //aqui verifico se o campo está vazio. Se sim, ele atribui um valor 1 para ele, senão, ele atribui o valor que tem no campo
            {
                valorMax = 1;
            }
            else
            {
                valorMax = double.Parse(txtHora.Text); //aqui faço o teste para que não se digite um valor maior que 24 e com mais de 2 caracteres
            }


            if ((txtHora.TextLength > 2) || (valorMax >23) || (valorMax < 0))
            {
                txtHora.Text = "1";
            }

        }

        private void txtMinuto_TextChanged(object sender, EventArgs e)
        {
            double valorMax;

            if (txtMinuto.Text == String.Empty) //aqui verifico se o campo está vazio. Se sim, ele atribui um valor 1 para ele, senão, ele atribui o valor que tem no campo
            {
                valorMax = 1;
            }
            else
            {
                valorMax = double.Parse(txtMinuto.Text); //aqui faço o teste para que não se digite um valor maior que 24 e com mais de 2 caracteres
            }


            if ((txtMinuto.TextLength > 2) || (valorMax > 59) || (valorMax < 0)) //aqui testo para que o campo nao tenha mais de 2 algarismos e o seu valor não exceda 60
            {
                txtMinuto.Text = "0";
            }
        }

        private void txtSegundo_TextChanged(object sender, EventArgs e)
        {
            double valorMax;

            if (txtSegundo.Text == String.Empty) //aqui verifico se o campo está vazio. Se sim, ele atribui um valor 1 para ele, senão, ele atribui o valor que tem no campo
            {
                valorMax = 1;
            }
            else
            {
                valorMax = double.Parse(txtSegundo.Text); //aqui faço o teste para que não se digite um valor maior que 24 e com mais de 2 caracteres
            }


            if ((txtMinuto.TextLength > 2) || (valorMax > 59) || (valorMax < 0)) //aqui testo para que o campo nao tenha mais de 2 algarismos e o seu valor não exceda 60
            {
                txtSegundo.Text = "0";
            }
        }

        private void btnParar_Click(object sender, EventArgs e)
        {
            relogio.Stop(); //aqui paro o contador
            Comecar.Enabled = true;
            btnParar.Enabled = false;
        }

        
    }
}
