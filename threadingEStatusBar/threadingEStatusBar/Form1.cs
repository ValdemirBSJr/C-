using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading; //Classe pra usar o recurso  thread

//NEsta caso, realizamos uma tarefa que irá ter fim com tempo determinado
//Sabemos quantos passos serao executados. USaremos o backgroundworker1
//Mudamos as propriedades  WorkerReportsProgress e WorkSupportCancellation para true

    //para o método de tempo indeterminado a propriedade workersupportcancellation deve ficar como true workerreportprogress false

    //caso queira desfazer as ações, usar o evento runworkercompleted

namespace threadingEStatusBar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRodarProcesso_Click(object sender, EventArgs e)
        {
            //desabilita os botoes enquanto a trafea e executada
            //esse botoao rodar processo serve para processo com tempo determinado
            btnIndeterminado.Enabled = false;
            btnRodarProcesso.Enabled = false;

            //define o estilo padrao do progressbar
            progressBar1.Style = ProgressBarStyle.Blocks;
            progressBar1.Value = 0;

            //executa o processo de forma assincrona.
            backgroundWorker1.RunWorkerAsync();

            btnCancelar.Enabled = true;
        }

        //abaixo crio metodo que simula operação de tempo longo

        private void TarefaLonga (int p)
        {

            for (int i = 0; i <= 10; i ++)
            {
                //Faz o thread dormir por 'p' milisegundos a cada passagem de loop
                Thread.Sleep(p);

                //o metodo beginInvoke é o que possibilita vc invokar uma tread diferente
                //muito importante pois executa simultaneamente as threads
                label2.BeginInvoke(
                    new Action(() =>
                    {
                        label2.Text = "Tarefa: " + i.ToString() + " concluída.";
                    }
                    ));
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //Aqui executaremos uma tarefa que realizar 100 passos
            for (int i = 0; i < 100; i ++)
            {
                //a cada loop, para 1 milissegundo com a função
                TarefaLonga(20);

                //abaixo, incrementamos tambem o report progress do bgworker
                this.backgroundWorker1.ReportProgress(i);

                //Verifica se houve um pedido de cancelamento das tarefas
                if (backgroundWorker1.CancellationPending)
                {
                    //se sim, para a tarefa da thread
                    e.Cancel = true;

                    //zera o percentual de progresso
                    backgroundWorker1.ReportProgress(0);

                    return;
                }
            }

            //qundo terminar tudo finaliza o progresso
            backgroundWorker1.ReportProgress(100);
            
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //incrementa o valor da progressbar com o valor atual do progresso da tarefa
            progressBar1.Value = e.ProgressPercentage;

            //informa a porcentagem na forma de texto
            label1.Text = e.ProgressPercentage.ToString() + "%.";
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                //se a operação for cancelada, informa ao usuário
                label2.Text = "Operação cancelada pelo Usuário";
            }
            else if (e.Error !=null)
            {
                //informa ao usuario caso haja erro
                label2.Text = "Um erro ocorreu durante o processo! Erro: "+ e.Error.ToString();
            }
            else
            {
                //informa que tarefa foi concluida com sucesso
                label2.Text = "Tarefa concluída com sucesso!";
            }

            //habilita os botoes
            btnRodarProcesso.Enabled = true;
            btnIndeterminado.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //cancelamento da tarefa com fim determinado 'backgroundworker1'

            if (backgroundWorker1.IsBusy) //se ele estiver em funcionamento
            {
                //notifica a tread que o cancelamento foi solicitado
                //cancela a tarefa doWork dela
                backgroundWorker1.CancelAsync();
            }

            if(bgWorkerIndeterminado.IsBusy)
            {
                //notifica a thread que o cancelamento foi solicitado
                //cancela a tarefa doWork
                bgWorkerIndeterminado.CancelAsync();
            }

            //desabilita o botao cancelar
            btnCancelar.Enabled = false;
            label1.Text = "Cancelando...";
        }

        private void bgWorkerIndeterminado_DoWork(object sender, DoWorkEventArgs e)
        {
            //executa a tarefa
            TarefaLonga(100);
            
            //Abaixo verifico se houve uma requisicao para cancelar a operacao

            if(bgWorkerIndeterminado.CancellationPending)
            {
                //se sim, define  a propriedade cancel para true
                //para que o evento workerComplete saiba que a tarefa foi cancelada
                e.Cancel = true;
                return;
            }

            //executa a tarefa pela segunda vez
            //fiz isso para exemplificar que uma vez começada uma tarefa
            //ela nao pode ser cancelada. caso seja solicitado, ela deixa de fazer as demais, nao aquela que ja comecou
            TarefaLonga(500);

            if (bgWorkerIndeterminado.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
        }

        private void bgWorkerIndeterminado_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //caso seja cancelado...

            if (e.Cancelled)
            {
                //reconfigura  a progressbar para o padrao
                progressBar1.MarqueeAnimationSpeed = 0;
                progressBar1.Style = ProgressBarStyle.Blocks;
                progressBar1.Value = 0;

                //caso a operacao seja cancelada, informa ao usuario
                label2.Text = "Operação cancelada pelo usuário!";

                //habilita o botao cancelar
                btnCancelar.Enabled = true;

                //limpa a label
                label1.Text = String.Empty;
            }
            else if (e.Error != null)
            {
                //informa ao usuario do acontecimento que houve erro
                label2.Text = "Aconteceu um erro durante a execucão do processo! Erro: " + e.Error.ToString();

                //reconfigura  a progressbar para o padrao
                progressBar1.MarqueeAnimationSpeed = 0;
                progressBar1.Style = ProgressBarStyle.Blocks;
                progressBar1.Value = 0;
            }
            else
            {
                //informa que a tarefa foi concluida com sucesso
                label2.Text = "Tarefa concluída com sucesso!";

                //carrega todo o progressvar
                progressBar1.MarqueeAnimationSpeed = 0;
                progressBar1.Style = ProgressBarStyle.Blocks;
                progressBar1.Value = 100;
                label1.Text = progressBar1.Value.ToString() + "%";
            }

            //habilita os botoes
            btnRodarProcesso.Enabled = true;
            btnIndeterminado.Enabled = true;
        }

        private void btnIndeterminado_Click(object sender, EventArgs e)
        {
            //desabiita os botoes
            btnIndeterminado.Enabled = false;
            btnRodarProcesso.Enabled = false;

            bgWorkerIndeterminado.RunWorkerAsync();

            //define a progressbar para indeterminado
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.MarqueeAnimationSpeed = 5;

            //informa
            label1.Text = "Processando...";
            btnCancelar.Enabled = true;
        }
    }
}
