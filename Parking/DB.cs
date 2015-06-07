#region

using System;
using System.Collections.Generic;
using System.Linq;
using ParkingCore;

#endregion

namespace Parking
{
    internal class DB
    {
        public readonly EstacionamientoEntities db = new EstacionamientoEntities();
        public int idcambio;

        public static string cajon1 { get; set; }
        public static string cajon2 { get; set; }
        public static string cajon3 { get; set; }

        public string InsertarEntrada(Entradas entrada)
        {
            try
            {
                entrada.idcambio = idcambio;
                db.Entradas.Add(entrada);
                db.SaveChanges();
                return "Entrada Registrada";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public List<Registros> CargarTabla()
        {
            try
            {
                var registros = from row in db.Registros
                    join id in db.Cajon on row.id_cjn equals id.id_cjn
                    join id2 in db.Entradas on row.id_ent equals id2.id_ent
                    select row;

                var list = new List<Registros>();

                foreach (var registro in registros)
                {
                    list.Add(new Registros
                    {
                        id_reg = registro.id_reg,
                        color_reg = registro.color_reg,
                        extras_reg = registro.extras_reg,
                        placas_reg = registro.placas_reg,
                        id_ent = registro.id_ent,
                        id_cjn = registro.id_reg
                    });
                }
                return list;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string InsertarSalida(Salidas salida)
        {
            try
            {
                db.Salidas.Add(salida);
                db.SaveChanges();
                var tiempo = DateTime.Now.Minute - ObtieneHoraEntradaAlSalir().Minute;
                if (tiempo >= 60)
                    return (tiempo + " horas");
                tiempo = tiempo*60;
                return (tiempo + " minutos");
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
                    idcambio = cajon.id_cjn;
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
                where row.id_ent == idcambio
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
                select new
                {
                    r.placas_reg,
                    r.extras_reg,
                    r.color_reg,
                    c.nombre_cjn,
                    e.entrada
                };
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