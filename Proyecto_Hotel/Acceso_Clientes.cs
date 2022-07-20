using AccesoDatos;
using Entidades;
using Microsoft.EntityFrameworkCore;

namespace Proyecto_Hotel
{
    public class Acceso_Clientes
    {
        private readonly Hotel_Db_Context _hotel;
        public Acceso_Clientes(Hotel_Db_Context hotel_Db)
        {
            _hotel = hotel_Db;
        }
        public List<Cliente> Consultar()
        {
            try
            {
                return _hotel.Clientes.ToList();
                _hotel.Dispose();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool AgregarCliente(Cliente a_entidad)
        {
            try
            {
                _hotel.Clientes.Add(a_entidad);
                _hotel.SaveChanges();
                _hotel.Dispose();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return true;
        }

        public List<Cliente> Consultar(Cliente a_entidad)
        {
            try
            {
                List<Cliente> lst = new List<Cliente>();
                lst.Add(_hotel.Clientes.Find(a_entidad._id));
                return lst;
            }
            catch (Exception ex)
            {

                throw ex;
            };
        }

        public bool ModificarCliente(Cliente a_entidad)
        {
            try
            {
                if (a_entidad == null || a_entidad._id == 0)
                {
                    return false;
                }
                else
                {
                    Cliente EntityFromDb = _hotel.Clientes.Find(a_entidad._id);
                    if (EntityFromDb == null)
                    {
                        return false;
                    }
                    EntityFromDb.Telefono = a_entidad.Telefono;
                    EntityFromDb.Apellidos = a_entidad.Apellidos;
                    EntityFromDb.Identificacion = a_entidad.Identificacion;
                    EntityFromDb.Correo = a_entidad.Correo;
                    EntityFromDb.Nombre = a_entidad.Nombre;
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

        public bool EliminarCliente(Cliente a_entidad)
        {
            try
            {
                if (a_entidad == null || a_entidad._id == 0)
                {
                    return false;
                }
                else
                {
                    Cliente EntityFromDb = _hotel.Clientes.Find(a_entidad._id);
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