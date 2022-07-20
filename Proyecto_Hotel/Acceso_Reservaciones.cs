using Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class Acceso_Reservaciones
    {
        private readonly Hotel_Db_Context _hotel;

        public Acceso_Reservaciones(Hotel_Db_Context context)
        {
            _hotel = context;
        }

        public bool AgregarReservacion(Reservaciones a_entidad)
        {
            try
            {
                _hotel.Add(a_entidad);
                _hotel.SaveChanges();
                _hotel.Dispose();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return true;
        }

        public List<Reservaciones> Consultar()
        {
            try
            {
                return _hotel.Reservaciones.ToList();
                _hotel.Dispose();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public bool ModificarReservacion(Reservaciones? a_entidad)
        {


            try
            {
                if (a_entidad == null || a_entidad._id == 0)
                {
                    return false;
                }
                else
                {
                    Reservaciones CategoryFromDb = _hotel.Reservaciones.Find(a_entidad._id);
                    if (CategoryFromDb == null)
                    {
                        return false;
                    }
                    CategoryFromDb.Id_habitacion = a_entidad.Id_habitacion;
                    CategoryFromDb.Observaciones = a_entidad.Observaciones;
                    CategoryFromDb.Fecha_salida = a_entidad.Fecha_salida;
                    CategoryFromDb.Fecha_llegada = a_entidad.Fecha_llegada;
                    CategoryFromDb.monto = a_entidad.monto;
                    CategoryFromDb.cliente = a_entidad.cliente;
                    _hotel.SaveChanges();
                    _hotel.Dispose();
                    return true;

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public bool EliminarReservacion(Reservaciones a_entidad)
        {
            try
            {
                if (a_entidad == null || a_entidad._id == 0)
                {
                    return false;
                }
                else
                {
                    Reservaciones CategoryFromDb = _hotel.Reservaciones.Find(a_entidad._id);
                    if (CategoryFromDb == null)
                    {
                        return false;
                    }
                    _hotel.Entry(CategoryFromDb).State = EntityState.Deleted;
                    _hotel.SaveChanges();
                    _hotel.Dispose();
                    return true;

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }        
        }

        public Reservaciones? Consultar(Reservaciones? p_Entidad)
        {
            try
            {
                return _hotel.Reservaciones.Find(p_Entidad._id);
            }
            catch (Exception ex)
            {

                throw ex;
            };
        }
    }
}
