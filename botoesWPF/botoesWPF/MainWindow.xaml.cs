using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace botoesWPF
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

        private void btnFechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            //Nosso form está como style none para não mostrar a barra habitual do windows
            //Este metodo permite arrastar e soltar o formulario
            MouseDown += delegate { DragMove(); };
        }

        private void btnTeste_Click(object sender, RoutedEventArgs e)
        {
             if (MessageBox.Show("Olha que botão bonito!!! =D", "BOTÃO CUSTOMIZADO!", MessageBoxButton.YesNo, MessageBoxImage.Hand) == MessageBoxResult.Yes)
            {
                MessageBox.Show("Que bom que gostou!!!", "TAMBÉM ACHO!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
             else
            {
                MessageBox.Show("Que pena que não gostou. Mas achamos bonito...", "Que pena...", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
        }
    }
}
