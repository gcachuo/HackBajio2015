#region

using ParkingCore;
using System;
using System.Collections.ObjectModel;
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
        private int autosbase;
     
        public MainWindow()
        {
            InitializeComponent();
            
        }


        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            var autos = autosbase+_es.timer_Tick(serialPort);
            Entradas.Content = "Autos: " + autos;
            Cajon1.Content = "Cajon 1: "+cajones(DB.cajon1);
            Cajon2.Content = "Cajon 2: " + cajones(DB.cajon2);
            Cajon3.Content = "Cajon 3: " + cajones(DB.cajon3);
            Mapa.Children.Clear();
            if (DB.cajon1 == "S")
            {
                ObjCajon.tipo = "normal";
                Mapa.Children.Add(Crear_Cajon(new Point(579, 143)));
            }
            else
            {
                ObjCajon.tipo = "ocupado";
                Mapa.Children.Add(Crear_Cajon(new Point(579, 143)));
            }
            if (DB.cajon2 == "S")
            {
                ObjCajon.tipo = "normal";
                Mapa.Children.Add(Crear_Cajon(new Point(629, 143)));
            }
            else
            {
                ObjCajon.tipo = "ocupado";
                Mapa.Children.Add(Crear_Cajon(new Point(629, 143)));
            }
            if (DB.cajon3 == "S")
            {
                ObjCajon.tipo = "normal";
                Mapa.Children.Add(Crear_Cajon(new Point(679, 143)));
            }
            else
            {
                ObjCajon.tipo = "ocupado";
                Mapa.Children.Add(Crear_Cajon(new Point(679, 143)));
            }
        }
        public string cajones(string cajon)
        {
            {
                if (cajon == "S")
                {
                    cajon = "Disponible";
                }
                if (cajon == "N")
                {
                    cajon = "Ocupado";
                    
                }
               
                return cajon;
            }
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
                autosbase=_db.ObtenerAutos();
            }
            catch (Exception)
            {
                autosbase = 0;
            }
            serialPort = _es.Load(timer);
            calculo.Load(Cajon);
            timer.Tick += dispatcherTimer_Tick;
            timer.Interval = new TimeSpan(0, 0, 1);
            ObjCajon.tipo = "normal";

            Mapa.Children.Add(Crear_Cajon(new Point(579, 143)));
            Mapa.Children.Add(Crear_Cajon(new Point(629, 143)));
            Mapa.Children.Add(Crear_Cajon(new Point(679, 143)));
        }
        private void CargarTabla()
        {

            //ObservableCollection<User> users = new ObservableCollection<User>();
            //users.Add(new User { FirstName = "firstname-1", LastName = "lastname-1" });
            //users.Add(new User { FirstName = "firstname-2", LastName = "lastname-2" });
            //users.Add(new User { FirstName = "firstname-3", LastName = "lastname-3" });
            //users.Add(new User { FirstName = "firstname-4", LastName = "lastname-4" });
            //DataGrid.ItemsSource = users;
            //var registro = from row in db.Registros
            //               join entrada in db.Entradas on row.id_ent equals entrada.id_ent
            //               select row.id_reg;
       
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

        private void Settings_MouseUp(object sender, MouseButtonEventArgs e)
        {
            EspecificacionWindow w = new EspecificacionWindow();
            w.Show();
        
        }
    }
}