using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

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
        DispatcherTimer timer = new DispatcherTimer();
       



        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
           // MessageBox.Show("hola");
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
          ObjCajon.tipo = "normal";
          timer.Tick += new EventHandler(dispatcherTimer_Tick);
          timer.Interval = new TimeSpan(0, 0, 5);
          timer.Start();
        }

        private void Mapa_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Canvas cajon = Crear_Cajon(e.GetPosition(Mapa));
            Mapa.Children.Add(cajon);
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

        private void vip_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ObjCajon.tipo = "vip";
        }

        private void discapacitados_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ObjCajon.tipo = "discapacitado";
        }

        private void normal_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ObjCajon.tipo = "normal";
        }

    }
}
