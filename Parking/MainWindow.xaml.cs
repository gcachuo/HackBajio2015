using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Parking
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly Calculo calculo = new Calculo();
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void Right_MouseUp(object sender, MouseButtonEventArgs e)
        {
            calculo.Validar_Cajon('R', txtCajon, Cajon);
        }

        private void Left_MouseUp(object sender, MouseButtonEventArgs e)
        {
            calculo.Validar_Cajon('L',txtCajon,Cajon);
        }
       
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
          calculo.Load(Cajon);
        }
    }
}
