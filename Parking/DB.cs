#region

using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using ParkingCore;

#endregion

namespace Parking
{
    internal class DB
    {
        public readonly EstacionamientoEntities db = new EstacionamientoEntities();
        
        public static string cajon1
        {
            get;
            set;
        }
        public static string cajon2
        {
            get;
            set;
        }
        public static string cajon3
        {
            get;
            set;

        }

        public string InsertarEntrada(Entradas entrada)
        {
            try
            {
                db.Entradas.Add(entrada);
                db.SaveChanges();
                return "Entrada Registrada";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public string InsertarSalida(Salidas salida)
        {
            try
            {

                //var id_reg=InputMessage;
                var tiempo = DateTime.Now.Hour - ObtieneHoraEntradaAlSalir().Hour;
                if (tiempo < 60)
                {
                    tiempo = tiempo * 60;
                    MessageBox.Show(tiempo + " minutos");
                }
                else
                {
                    MessageBox.Show(tiempo + " horas");
                }
                db.Salidas.Add(salida);
                db.SaveChanges();
                return "Salida Registrada";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public string InsertarRegistro(Registros registro)
        {
            try
            {
                db.Registros.Add(registro);
                db.SaveChanges();
                return "Nuevo Registro añadido";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public string ActualizarEstatus(Cajon cajonA)
        {
            using (new EstacionamientoEntities())
            {
                var cajon = db.Cajon.FirstOrDefault(e => e.nombre_cjn == cajonA.nombre_cjn);
                try
                {
                    if (cajon != null)
                        cajon.estatus_cjn = cajonA.estatus_cjn;
                    db.SaveChanges();
                    return "Estatus de Cajon Actualizado";
                }
                catch (Exception e)
                {
                    return e.ToString();
                }
            }
        }

        public IQueryable<Cajon> ObtenerCajones()
        {
            using (new EstacionamientoEntities())
            {
                var query = from row in db.Cajon
                            select row;
                return query;
            }
        }

        public string ObtieneCajon(string nombre)
        {
            var query = from row in db.Cajon
                        where row.nombre_cjn == nombre
                        select row;
            return query.Single().estatus_cjn;
        }
        public Cajon ObtieneCajon2(string nombre)
        {
            var query = from row in db.Cajon
                        where row.nombre_cjn == nombre
                        select row;
            return query.Single();
        }


        public Entradas ObtieneUltimaEntrada()
        {
            var query = from row in db.Entradas
                        select row;
            return query.OrderByDescending(x => x.entrada)
                .FirstOrDefault();
        }
        public DateTime ObtieneHoraEntradaAlSalir()
        {
            var hora = from row in db.Entradas
                       join entrada in db.Registros on row.id_ent equals entrada.id_ent
                       select row.entrada;
            return hora.Single();
        }
        public int ObtieneRegistroAlSalir()
        {
            var registro = from row in db.Registros
                           join entrada in db.Entradas on row.id_ent equals entrada.id_ent
                           select row.id_reg;
            return registro.Single();
        }
        
        public int ObtenerAutos()
        {
            var entradas = from row in db.Entradas
                           select row;
            var salidas = from row in db.Salidas
                          select row;
            return entradas.Count() - salidas.Count();
        }
        public IQueryable RegistroAuto()
        {
            
            var list = from r in db.Registros
                       from c in db.Cajon
                       from e in db.Entradas
                       select new { r.placas_reg, r.extras_reg, r.color_reg, c.nombre_cjn, e.entrada };
            return list;
        }
        public List<Registros> RRegistro()
        {
            var registro = (from r in db.Registros
                           select r).ToList();
            return registro;
        }
        public List<Entradas> REntrada()
        {
            var registro = (from r in db.Entradas
                            select r).ToList();
            return registro;
        }
        public List<Cajon> RCajon()
        {
            var registro = (from r in db.Cajon
                            select r).ToList();
            return registro;
        }
    }
}