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

namespace WpfAprendendo
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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var uriSource = new Uri(@"C:\Users\Valdemir\Desktop\DSCF1094.jpg");

            image.Source = new BitmapImage(uriSource);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Window1 form = new Window1();
            form.Show();
        }

        
    }
}
