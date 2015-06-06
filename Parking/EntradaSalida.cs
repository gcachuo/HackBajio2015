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


        public int timer_Tick(SerialPort serialPort1,TextBox txtSalida=null,TextBox txtArduino=null, TextBox txtEntrada = null)
        {
            try
            {
                var datos = serialPort1.ReadLine();
                var autos=0;
                if (datos == "In \r")
                {
                    _entrando++;
                    autos = _entrando - _saliendo;
                    return autos;
                }
                if (datos == "Out\r")
                {
                    _saliendo++;
                    autos = _entrando - _saliendo;
                    return autos;
                }
                return autos;
            }
            catch (Exception)
            {
                return -1;
            }
        }


        public void Salir(SerialPort serialPort1)
        {
            serialPort1.Close();
        }
    }
}