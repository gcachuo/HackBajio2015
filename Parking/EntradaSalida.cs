#region

using System;
using System.IO.Ports;
using System.Windows.Controls;
using Timer = System.Timers.Timer;

#endregion

namespace Parking
{
    internal class EntradaSalida
    {
        private int _entrando;
        private int _saliendo;

        public void Load(Timer timer1, SerialPort serialPort1)
        {
            timer1.Enabled = true;
            serialPort1.Open();
        }


        private string timer1_Tick(SerialPort serialPort1, TextBox txtEntrada, TextBox txtSalida, TextBox txtArduino)
        {
            try
            {
                string datos;
                datos = serialPort1.ReadLine();

                if (datos == "In \r")
                {
                    _entrando++;
                    txtEntrada.Text = _entrando.ToString();
                }
                if (datos == "Out\r")
                {
                    _saliendo++;
                    txtSalida.Text = _saliendo.ToString();
                }
                txtArduino.Text = datos;
                return "Tick Completo";
            }
            catch (Exception)
            {
                return "Error al dar Tick";
            }
        }


        private void Salir(SerialPort serialPort1)
        {
            serialPort1.Close();
        }
    }
}