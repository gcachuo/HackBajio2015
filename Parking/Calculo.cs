using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Parking
{
    class Calculo
    {
        public static char CajonOrientacion;
        public string PathImage = "pack://application:,,,/image/";
        public DB db = new DB();
        ///METODO 
        ///que recibe la orientacion del cajon para obtener la imagen
 
        public void Validar_Cajon(char orientacion, Canvas Cajon)
        {
            var image = new Image()
            {
                Stretch = Stretch.UniformToFill,
                Width = 40,
                Height = 40,
            };


            switch (CajonOrientacion)
            {
                //UP
                case 'U':
                    if (orientacion == 'R')
                    {
                        CajonOrientacion = 'R';
                        image.Source = new BitmapImage(new Uri(PathImage + "right.png"));
                    }
                    else
                    {
                        CajonOrientacion = 'L';
                        image.Source = new BitmapImage(new Uri(PathImage + "left.png"));
                    }

                    break;
                //DOWN
                case 'D':
                    if (orientacion == 'R')
                    {
                        CajonOrientacion = 'L';
                        image.Source = new BitmapImage(new Uri(PathImage + "left.png"));
                    }
                    else
                    {
                        CajonOrientacion = 'R';
                        image.Source = new BitmapImage(new Uri(PathImage + "right.png"));
                    }
                    break;
                //RIGHT
                case 'R':
                    if (orientacion == 'R')
                    {
                        CajonOrientacion = 'D';
                        image.Source = new BitmapImage(new Uri(PathImage + "down.png"));
                    }
                    else
                    {
                        CajonOrientacion = 'U';
                        image.Source = new BitmapImage(new Uri(PathImage + "up.png"));
                    }
                    break;
                //LEFT
                case 'L':
                    if (orientacion == 'R')
                    {
                        CajonOrientacion = 'U';
                        image.Source = new BitmapImage(new Uri(PathImage + "up.png"));
                    }
                    else
                    {
                        CajonOrientacion = 'D';
                        image.Source = new BitmapImage(new Uri(PathImage + "down.png"));
                    }
                    break;
                default:
                    CajonOrientacion = 'U';
                    image.Source = new BitmapImage(new Uri(PathImage + "up.png"));
                    break;

            }
            Cajon.Children.Clear();
            Cajon.Children.Add(image);
        }

        public void Load(Canvas cajon)
        {
            // UP
            CajonOrientacion = 'U';
            var image = new Image()
            {
                Stretch = Stretch.UniformToFill,
                Width = 40,
                Height = 40,
                Source = new BitmapImage(new Uri(PathImage + "up.png"))
            };
            cajon.Children.Add(image);
        }

        public double Total(double precio,double tiempofinal, double tiempoinicial)
        {
            var total = precio * Horas(tiempofinal, tiempoinicial);
            return total;
        }
        public double Horas(double tiempofinal, double tiempoinicial)
        {
            return tiempofinal - tiempoinicial;
        }
        public string ActualizarEstatus(string estatus)
        {
            try
            {
                var cajones = db.ObtenerCajones();
                foreach (var cajon in cajones.Where(cajon => cajon.estatus_cjn != estatus))
                {
                    cajon.estatus_cjn = estatus;
                    db.ActualizarEstatus(cajon);
                }
                return "estatus actualizados";
            }
            catch (Exception)
            {

                return "error al actualizar";
            }

        }
    }
}
