using Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class Acceso_Habitaciones
    {
        private readonly Hotel_Db_Context _hotel;
        public Acceso_Habitaciones(Hotel_Db_Context hotel_Db)
        {
            _hotel = hotel_Db;
        }
        public List<Disponibilidad_Habitacion> Consultar()
        {
            try
            {
                return _hotel.Disponibilidad_Habitacions.ToList();
                _hotel.Dispose();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool AgregarHabitacion(Disponibilidad_Habitacion a_entidad)
        {
            try
            {
                _hotel.Disponibilidad_Habitacions.Add(a_entidad);
                _hotel.SaveChanges();
                _hotel.Dispose();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return true;
        }

        public Disponibilidad_Habitacion? Consultar(Disponibilidad_Habitacion p_Entidad)
        {
            try
            {
                return _hotel.Disponibilidad_Habitacions.Find(p_Entidad._id);
            }
            catch (Exception ex)
            {

                throw ex;
            };
        }

        public bool ModificarHabitacion(Disponibilidad_Habitacion a_entidad)
        {
            try
            {
                if (a_entidad == null || a_entidad._id == 0)
                {
                    return false;
                }
                else
                {
                    Disponibilidad_Habitacion EntityFromDb = _hotel.Disponibilidad_Habitacions.Find(a_entidad._id);
                    if (EntityFromDb == null)
                    {
                        return false;
                    }
                    EntityFromDb.Estado_habitacion = a_entidad.Estado_habitacion;
                    EntityFromDb.Tipo_habitacion = a_entidad.Tipo_habitacion;
                    EntityFromDb.Id_habitacion = a_entidad.Id_habitacion;
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

        public bool EliminarHabitacion(Disponibilidad_Habitacion a_entidad)
        {
            try
            {
                if (a_entidad == null || a_entidad._id == 0)
                {
                    return false;
                }
                else
                {
                    Disponibilidad_Habitacion EntityFromDb = _hotel.Disponibilidad_Habitacions.Find(a_entidad._id);
                    if (EntityFromDb == null)
                    {
                        return false;
                    }
                    _hotel.Entry(EntityFromDb).State = EntityState.Deleted;
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
    }
}
