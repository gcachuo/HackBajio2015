#region

using System;
using System.IO.Ports;
using System.Windows.Controls;
using System.Windows.Threading;
using ParkingCore;

#endregion

namespace Parking
{
    internal class EntradaSalida
    {
        private int _entrando;
        private int _saliendo;
        private SerialPort _serialPort1;
        DB db = new DB();
        EstacionamientoEntities entity = new EstacionamientoEntities();

        public SerialPort Load(DispatcherTimer timer)
        {
            _serialPort1 = new SerialPort();
            _serialPort1.PortName = "COM4";
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


        public int timer_Tick(SerialPort serialPort1)
        {
            try
            {
                var datos = serialPort1.ReadLine();
                var autos = 0;
                if (datos == "In \r")
                {
                    var entrada = new Entradas
                    {
                        entrada = DateTime.Now
                    };
                    db.InsertarEntrada(entrada);
                    _entrando++;
                    autos = _entrando - _saliendo;
                    return autos;
                }
                if (datos == "Out\r")
                {
                    var salida = new Salidas()
                    {
                        salida = DateTime.Now
                    };
                    db.InsertarSalida(salida);
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