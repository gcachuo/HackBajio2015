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

namespace Parking
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
        private static char cajonOrientacion;
        private void Right_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Validar_Cajon('R');
        }

        private void Left_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Validar_Cajon('L');
        }
        ///METODO 
        ///que recibe la orientacion del cajon para obtener la imagen
        ///
        private void Validar_Cajon (char orientacion)
        {
            var image = new Image()
            {
                Stretch = Stretch.UniformToFill,
                Width = 40,
                Height = 40,
            };

            if (txtCajon.Text == ""){
                MessageBox.Show("Por favor, especifique el nombre del cajón");
                cajonOrientacion = 'U';
                image.Source = new BitmapImage(new Uri(System.AppDomain.CurrentDomain.BaseDirectory + "up.png"));
            }
            else{
                switch (cajonOrientacion)
                {
                        //UP
                    case 'U':
                        if (orientacion == 'R')
                        {
                            cajonOrientacion = 'R';
                            image.Source = new BitmapImage(new Uri(System.AppDomain.CurrentDomain.BaseDirectory + "right.png"));
                        }
                        else
                        {
                            cajonOrientacion = 'L';
                            image.Source = new BitmapImage(new Uri(System.AppDomain.CurrentDomain.BaseDirectory+ "left.png"));
                        }
                        
                        break;
                        //DOWN
                    case 'D':
                        if (orientacion == 'R')
                        {
                            cajonOrientacion = 'L';
                            image.Source = new BitmapImage(new Uri(System.AppDomain.CurrentDomain.BaseDirectory + "left.png"));
                        }
                        else
                        {
                            cajonOrientacion = 'R';
                            image.Source = new BitmapImage(new Uri(System.AppDomain.CurrentDomain.BaseDirectory + "right.png"));
                        }
                        break;
                        //RIGHT
                    case 'R':
                        if (orientacion == 'R')
                        {
                            cajonOrientacion = 'D';
                            image.Source = new BitmapImage(new Uri(System.AppDomain.CurrentDomain.BaseDirectory + "down.png"));
                        }
                        else
                        {
                            cajonOrientacion = 'U';
                            image.Source = new BitmapImage(new Uri(System.AppDomain.CurrentDomain.BaseDirectory + "up.png"));
                        }
                        break;
                        //LEFT
                    case 'L':
                        if (orientacion == 'R')
                        {
                            cajonOrientacion = 'U';
                            image.Source = new BitmapImage(new Uri(System.AppDomain.CurrentDomain.BaseDirectory + "up.png"));
                        }
                        else
                        {
                            cajonOrientacion = 'D';
                            image.Source = new BitmapImage(new Uri(System.AppDomain.CurrentDomain.BaseDirectory + "down.png"));
                        }
                        break;
                    default:
                        cajonOrientacion = 'U';
                        image.Source = new BitmapImage(new Uri(System.AppDomain.CurrentDomain.BaseDirectory + "up.png"));
                        break;
                }
            }
            Cajon.Children.Clear();
            Cajon.Children.Add(image);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // UP
            cajonOrientacion = 'U';
            var image = new Image()
            {
                Stretch = Stretch.UniformToFill,
                Width = 40,
                Height = 40,
                Source = new BitmapImage(new Uri(System.AppDomain.CurrentDomain.BaseDirectory + "up.png"))
            };
            Cajon.Children.Add(image);
        }
    }
}
