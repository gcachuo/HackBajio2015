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
            calculo.Validar_Cajon('R', Cajon);
        }

        private void Left_MouseUp(object sender, MouseButtonEventArgs e)
        {
            calculo.Validar_Cajon('L',Cajon);
        }
       
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
          calculo.Load(Cajon);
        }

        private void Mapa_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Canvas cajon = Crear_Cajon(e.GetPosition(Mapa));
            Mapa.Children.Add(cajon);
            Left.Visibility = Visibility.Hidden;
            Right.Visibility = Visibility.Hidden;
        }
        public static Canvas Crear_Cajon(Point point)
        {
            
            string PathImage = "pack://application:,,,/image/";
            var image = new Image();
            image.Stretch = Stretch.UniformToFill;
            
            Canvas canvas = new Canvas();
            switch (Calculo.CajonOrientacion)
            {
                case 'U':
                    image.Source = new BitmapImage(new Uri(PathImage + ObjCajon.tipo+"/du.png"));
                    image.Width = 50;
                    image.Height = 80;
                    Canvas.SetTop(image, point.Y);
                    Canvas.SetLeft(image, point.X - 25);
                    break;
                case 'D':
                    image.Source = new BitmapImage(new Uri(PathImage +ObjCajon.tipo+ "/dd.png"));
                    image.Width = 50;
                    image.Height = 80;
                    Canvas.SetTop(image, point.Y -75);
                    Canvas.SetLeft(image, point.X -25);
                    break;
                case 'R':
                    image.Source = new BitmapImage(new Uri(PathImage +ObjCajon.tipo+ "/dr.png"));
                    image.Width = 80;
                    image.Height = 50;
                    Canvas.SetTop(image, point.Y-25 );
                    Canvas.SetLeft(image, point.X-75);
                    break;
                case 'L':
                    image.Source = new BitmapImage(new Uri(PathImage + ObjCajon.tipo+"/dl.png"));
                    image.Width = 80;
                    image.Height = 50;
                    Canvas.SetTop(image, point.Y - 25);
                    Canvas.SetLeft(image, point.X -5);
                    break;

            }
            canvas.Children.Add(image);
            return canvas;
        }


        private void add_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var cw = new CajonWindow();
            cw.Show();
            Left.Visibility = Visibility.Visible;
            Right.Visibility = Visibility.Visible;
        }

    }
}
