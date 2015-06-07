#region

using System;
using System.IO.Ports;
using System.Windows;
using System.Windows.Threading;
using ParkingCore;

#endregion

namespace Parking
{
    internal class EntradaSalida
    {
        private readonly DB _db = new DB();
        private int _autos;
        private int _entrando;
        private int _saliendo;
        private SerialPort _serialPort1;

        public SerialPort Load(DispatcherTimer timer)
        {
            try
            {
                _autos = 0;
                _serialPort1 = new SerialPort
                {
                    PortName = "COM4",
                    ReadTimeout = 1500
                };
                timer.Start();

                _serialPort1.Open();
                return _serialPort1;
            }
            catch (Exception)
            {
                return null;
            }
        }


        public int timer_Tick(SerialPort serialPort1)
        {
            string datos;
            try
            {
                try
                {
                    datos = serialPort1.ReadLine();

                    var valores = datos.Split('/', 'A', 'B', 'C');
                    switch (valores[1])
                    {
                        case "In":
                            RegistrarEntrada();
                            break;
                        case "Out":
                            RegistrarSalida();
                            break;
                    }
                    DB.cajon1 = ComprobarLugar(valores[2], "a");
                    DB.cajon2 = ComprobarLugar(valores[3], "b");
                    DB.cajon3 = ComprobarLugar(valores[4], "c");
                }
                catch (Exception)
                {
                    datos = "";
                }
                return _autos;
            }
            catch (TimeoutException)
            {
                return _autos;
            }
        }


        public void Salir(SerialPort serialPort1)
        {
            serialPort1.Close();
        }

        public void RegistrarEntrada()
        {
            var entrada = new Entradas
            {
                entrada = DateTime.Now
            };
            _db.InsertarEntrada(entrada);
            _entrando++;
            _autos = _entrando - _saliendo;
            var window = new RegistroWindow();
            window.Show();
        }

        public void RegistrarSalida()
        {
            var salida = new Salidas
            {
                salida = DateTime.Now
            };
            _saliendo++;
            _autos = _entrando - _saliendo;
            _db.InsertarSalida(salida);
        }

        public string ComprobarLugar(string status, string cajon)
        {
            if (status.Length > 1)
            {
                status = status.Substring(0, 1);
            }
            if (_db.ObtieneCajon(cajon) == status) return status;
            var caj = new Cajon
            {
                nombre_cjn = cajon,
                estatus_cjn = status
            };
            _db.ActualizarEstatus(caj);
            return status;
        }
    }
}