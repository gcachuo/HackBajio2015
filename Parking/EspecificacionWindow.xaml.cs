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
using System.Windows.Shapes;

namespace Parking
{
    /// <summary>
    /// Interaction logic for EspecificacionWindow.xaml
    /// </summary>
    public partial class EspecificacionWindow : Window
    {
        public EspecificacionWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            int[] horas = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 };
            int[] minutos = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 53, 54, 55, 56, 57, 58, 59, 60 };
            foreach (var hr in horas)
            {
                cmbHr.Items.Add(hr);
            }
            foreach (var mn in minutos)
            {
                cmbMin.Items.Add(mn);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
