using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading; //as duas classes que precisamos
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;

namespace ImpedeBloqueio_2._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //variaveis globais
        string hora, minuto, segundo;
        int tempo;
        DateTime data = new DateTime();

        System.Windows.Threading.DispatcherTimer contador = new System.Windows.Threading.DispatcherTimer();

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
        //############### MUIDO DE MOVER O FORM

        private void Grid_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            //Nosso form está como style none para não mostrar a barra habitual do windows
            //Este metodo permite arrastar e soltar o formulario
            this.MouseDown += delegate { DragMove(); };

        }
        //##########################


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Aqui pegamos o caminho relativo do gif rodando no media center
            mediaElement1.Source = new Uri(System.AppDomain.CurrentDomain.BaseDirectory + @"img/house.gif");
            
            //Aqui seto o usuário logado. Notar que não usamos o atributo text e sim
            //o atributo content para o valor.
            //C# ficou mais verboso com o wpf, mas tem eventos para touch!
            lblUser.Content = Environment.UserName;
            lblTempExecucao.Content = "--:--:--";

            //agora se usa o elemento dispatcher timet para relogio
            //abaixo tem que ter um metodo private void que chama ele
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();

           

        }

//##############    ###############TIMERS
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            // Aqui vai o código para toda vez que
            //passar um segundo no dispatcher time

            data = DateTime.Now;

            lblHora.Content = "Atual: " + data.ToShortDateString() + " - " + data.ToLongTimeString();
        }

        private void contador_Tick(object sender, EventArgs e)
        {
            //aqui é o contador de atividade

            tempo += 1; //aqui decrementa o tempo em segundos. cada loop diminui um segundo, mas é variavel inteira



            TimeSpan tempoConvertido = TimeSpan.FromSeconds(tempo); //aqui crio um timespan que vai pegar o inteiro e converter em segundos
            string tempoString = tempoConvertido.ToString("hh':'mm':'ss"); //aqui se converte a timespan em string para que seja exibida na label

            lblTempExecucao.Content = tempoString;


        }

//################ TIMERS


        private void btnComecar_Click(object sender, RoutedEventArgs e)
        {
            //torna os componentes visíveis
            mediaElement1.Visibility = Visibility.Visible;
            DesativaProtetor(); //chamado para desativar descanso de tela
            lblMensagem.Visibility = Visibility.Visible;

            

            //Aqui começa o contador
            //contador de tempo de execução
            //System.Windows.Threading.DispatcherTimer contador = new System.Windows.Threading.DispatcherTimer();
            contador.Tick += new EventHandler(contador_Tick);
            contador.Interval = new TimeSpan(0, 0, 1);
            contador.Start();

           
        }

        private void gifHousePlay(object sender, RoutedEventArgs e)
        {
            /*para o media elemente executar o gif, colocamos as tags: 
             * MediaEnded="gifHousePlay"  LoadedBehavior="Play"  UnloadedBehavior="Manual"
             * que irão executar o gif e criar o metodo gifHouseplay pra executar. Essas tags vao dentro do elemento xml
             */

            //aqui abaixo mostro a exibição continua do gif no mediaElement
            mediaElement1.Position = new TimeSpan(0, 0, 1);
            mediaElement1.Play();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            mediaElement1.Visibility = Visibility.Hidden;
            AtivaProtetor();

            tempo = 0; //zera o contador
            contador.Stop();
            //apaga o label
            lblTempExecucao.Content = "--:--:--";
        }

        private void button1_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Close();
        }

        private void button1_MouseEnter(object sender, MouseEventArgs e)
        {
            //btnFechar.Background = Brushes.Red;

             var bc = new BrushConverter();
             btnFechar.Background = (Brush)bc.ConvertFrom("#FFDDDDDD");
        }

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void btnFechar_MouseLeave(object sender, MouseEventArgs e)
        {
           

            btnFechar.Background = Brushes.Red;
        }

        private void button1_Click_1(object sender, System.Windows.RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        

    }
}
