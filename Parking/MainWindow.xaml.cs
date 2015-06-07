﻿#region

using System;
using System.IO.Ports;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

#endregion

namespace Parking
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly EntradaSalida _es = new EntradaSalida();
        private readonly Calculo calculo = new Calculo();
        private readonly DispatcherTimer timer = new DispatcherTimer();
        private DB _db = new DB();
        private int count;
        private SerialPort serialPort;
        private int autos;
        public MainWindow()
        {
            InitializeComponent();
        }


        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            autos += _es.timer_Tick(serialPort);
            Entradas.Content = "Autos: " + autos;
        }

        private void Right_MouseUp(object sender, MouseButtonEventArgs e)
        {
            calculo.Validar_Cajon('R', Cajon);
        }

        private void Left_MouseUp(object sender, MouseButtonEventArgs e)
        {
            calculo.Validar_Cajon('L', Cajon);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                autos=_db.ObtenerAutos();
            }
            catch (Exception)
            {
                autos = 0;
            }
            serialPort = _es.Load(timer);
            calculo.Load(Cajon);
            timer.Tick += dispatcherTimer_Tick;
            timer.Interval = new TimeSpan(0, 0, 1);
            ObjCajon.tipo = "normal";
        }

        private void Mapa_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var cajon = Crear_Cajon(e.GetPosition(Mapa));
            Mapa.Children.Add(cajon);
            count++;
        }

        public Canvas Crear_Cajon(Point point)
        {
            const string PathImage = "pack://application:,,,/image/";
            var image = new Image {Stretch = Stretch.UniformToFill, Name = "C" + count};
            var canvas = new Canvas();
            switch (Calculo.CajonOrientacion)
            {
                case 'U':
                    image.Source = new BitmapImage(new Uri(PathImage + ObjCajon.tipo + "/du.png"));
                    image.Width = 50;
                    image.Height = 80;
                    Canvas.SetTop(image, point.Y);
                    Canvas.SetLeft(image, point.X - 25);
                    break;
                case 'D':
                    image.Source = new BitmapImage(new Uri(PathImage + ObjCajon.tipo + "/dd.png"));
                    image.Width = 50;
                    image.Height = 80;
                    Canvas.SetTop(image, point.Y - 75);
                    Canvas.SetLeft(image, point.X - 25);
                    break;
                case 'R':
                    image.Source = new BitmapImage(new Uri(PathImage + ObjCajon.tipo + "/dr.png"));
                    image.Width = 80;
                    image.Height = 50;
                    Canvas.SetTop(image, point.Y - 25);
                    Canvas.SetLeft(image, point.X - 75);
                    break;
                case 'L':
                    image.Source = new BitmapImage(new Uri(PathImage + ObjCajon.tipo + "/dl.png"));
                    image.Width = 80;
                    image.Height = 50;
                    Canvas.SetTop(image, point.Y - 25);
                    Canvas.SetLeft(image, point.X - 5);
                    break;
            }
            canvas.Children.Add(image);
            return canvas;
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

        private void Clean_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Mapa.Children.Clear();
        }
    }
}