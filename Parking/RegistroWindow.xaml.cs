#region

using System;
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
            try
            {
                var c = db.ObtieneCajon2(cmbcajon.Text);
                var reg = new Registros
                {
                    placas_reg = txtPlacas.Text,
                    extras_reg = txtEspeciones.Text,
                    color_reg = cmbcolor.Text,
                    id_cjn = c.id_cjn,
                   id_ent = db.ObtieneUltimaEntrada().id_ent
                };
                db.InsertarRegistro(reg);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar: "+ex);
            }
           
        }

        private void RegistroWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (var cajon in db.ObtenerCajones())
                {
                    cmbcajon.Items.Add(cajon.nombre_cjn);
                }
                string[] colores = { "blanco", "negro", "azul", "rojo", "verde", "naranja", "amarillo", "plateado", "cafe" };
                foreach (var color in colores)
                {
                    cmbcolor.Items.Add(color);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Error al cargar combobox");
            }
           
        }
    }
}