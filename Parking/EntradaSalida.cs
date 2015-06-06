#region

using System;
using System.IO.Ports;
using System.Timers;
using System.Windows.Controls;
using System.Windows.Threading;

#endregion

namespace Parking
{
    internal class EntradaSalida
    {
        private int _entrando;
        private int _saliendo;
        private SerialPort _serialPort1;

        public SerialPort Load(DispatcherTimer timer)
        {
            _serialPort1 = new SerialPort();
            _serialPort1.PortName="COM4";
            timer.Start();
            try
            {
                _serialPort1.Open();
                return _serialPort1;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public string timer_Tick(SerialPort serialPort1,TextBox txtSalida=null,TextBox txtArduino=null, TextBox txtEntrada = null)
        {
            try
            {
                var datos = serialPort1.ReadLine();

                if (datos == "In \r")
                {
                    _entrando++;
                    return _entrando.ToString();
                }
                if (datos == "Out\r")
                {
                    _saliendo++;
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