using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
     
        ///METODO 
        ///que recibe la orientacion del cajon para obtener la imagen
        ///
        public void Validar_Cajon(char orientacion, Canvas Cajon)
        {
            var image = new Image()
            {
                Stretch = Stretch.UniformToFill,
                Width = 40,
                Height = 40,
            };

            if (ObjCajon.name== "")
            {
                MessageBox.Show("Por favor, especifique el nombre del cajón");
                CajonOrientacion = 'U';
                image.Source = new BitmapImage(new Uri(PathImage + "up.png"));
            }
            else
            {
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
            }
            Cajon.Children.Clear();
            Cajon.Children.Add(image);
        }

        public void Load(Canvas Cajon)
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
            Cajon.Children.Add(image);
        }

        public double Total(int tiempo)
        {
            const int precio = 1;
            var total = precio * tiempo;
            return total;
        }
    }
}
