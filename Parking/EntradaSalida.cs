#region

using System;
using System.IO.Ports;
using System.Timers;
using System.Windows.Controls;

#endregion

namespace Parking
{
    internal class EntradaSalida
    {
        private int _entrando;
        private int _saliendo;
        private SerialPort _serialPort1;

        public string Load(Timer timer)
        {
            _serialPort1 = new SerialPort();
            timer.Enabled = true;
            try
            {
                _serialPort1.Open();
                return "puerto serial abierto";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }


        public string timer_Tick(SerialPort serialPort1,ref TextBox txtEntrada, ref TextBox txtSalida, ref TextBox txtArduino)
        {
            try
            {
                var datos = serialPort1.ReadLine();

                if (datos == "In \r")
                {
                    _entrando++;
                    txtEntrada.Text = _entrando.ToString();
                    return _entrando.ToString();
                }
                if (datos == "Out\r")
                {
                    _saliendo++;
                    txtSalida.Text = _saliendo.ToString();
                    return _saliendo.ToString();
                }
                txtArduino.Text = datos;
                return datos;
            }
            catch (Exception)
            {
                return "Error al dar Tick";
            }
        }


        public void Salir(SerialPort serialPort1)
        {
            serialPort1.Close();
        }
    }
}