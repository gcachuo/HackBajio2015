#region

using System.Windows;
using ParkingCore;

#endregion

namespace Parking
{
    /// <summary>
    ///     Interaction logic for RegistroWindow.xaml
    /// </summary>
    public partial class RegistroWindow : Window
    {
        private readonly DB db = new DB();

        public RegistroWindow()
        {
            InitializeComponent();
        }

        private void Guardar_OnClick(object sender, RoutedEventArgs e)
        {
            var c = db.ObtieneCajon(cmbcajon.Text);
            var reg = new Registros
            {
                placas_reg = txtPlacas.Text,
                extras_reg = txtEspeciones.Text,
                color_reg = cmbcolor.Text,
                id_cjn = c.id_cjn
            };
            db.InsertarRegistro(reg);
        }

        private void RegistroWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            foreach (var cajon in db.ObtenerCajones())
            {
                cmbcajon.Items.Add(cajon.nombre_cjn);
            }
            string[] colores = {"blanco", "negro", "azul", "rojo", "verde", "naranja", "amarillo", "plateado", "cafe"};
            foreach (var color in colores)
            {
                cmbcolor.Items.Add(color);
            }
        }
    }
}