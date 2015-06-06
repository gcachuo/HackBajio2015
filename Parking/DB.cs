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
        private readonly EstacionamientoEntities db = new EstacionamientoEntities();

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
            var cajon = db.Cajon.FirstOrDefault(e => e.nombre_cjn == cajonA.nombre_cjn);
            try
            {
                if (cajon != null) cajon.estatus_cjn = cajonA.estatus_cjn;
                db.SaveChanges();
                return "Estatus de Cajon Actualizado";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        public IQueryable<Cajon> ObtenerCajones()
        {
            var query = from row in db.Cajon select row;
            return query;
        }
        public Cajon ObtieneCajon(string nombre)
        {
            var query = from row in db.Cajon
                        where row.nombre_cjn==nombre
                        select row ;
            return query.Single();
        }

    }
}