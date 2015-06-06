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
    /// Interaction logic for CajonWindow.xaml
    /// </summary>
    public partial class CajonWindow : Window
    {
        public CajonWindow()
        {
            InitializeComponent();
        }
        string kind;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text == "" && kind=="")
            {
                MessageBox.Show("Llena los datos del cajon");
            }
            else
            {
                ObjCajon.name = txtName.Text;
                ObjCajon.tipo = kind;
                this.Close();
            }
        }

        private void vip_MouseUp(object sender, MouseButtonEventArgs e)
        {
            kind = "vip";
        }

        private void discapacitado_MouseUp(object sender, MouseButtonEventArgs e)
        {
            kind = "discapacitado";
        }

        private void normal_MouseUp(object sender, MouseButtonEventArgs e)
        {
            kind = "normal";
        }
    }
}
