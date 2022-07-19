using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocios
{
    public class Logica_Habitaciones
    {
        public static Resultado AgregarHabitaciones(Disponibilidad_Habitacion A_entidad)
        {
            Resultado V_resultado = new Resultado();
            Acceso_Habitaciones objacceso = new Acceso_Habitaciones();

            try
            {
                List<Disponibilidad_Habitacion> lstUsuarios = objacceso.Consultar();
                lstUsuarios = lstUsuarios.FindAll(x => x.Id_habitacion.ToUpper().Equals(A_entidad.Id_habitacion.ToUpper()));

                //Valida si la consulta NO retorno resultados, procede con agregar el usuario
                if (lstUsuarios.Count == 0)
                {
                    //Aqui ejecuta la acción de agregar usuario
                    V_resultado.OperacionSatisfactoria = objacceso.AgregarHabitacion(A_entidad);
                    if (!V_resultado.OperacionSatisfactoria)
                        V_resultado.MensajeUsuario = "Error al guardar información la habitación";
                }
                else
                {
                    V_resultado.MensajeUsuario = "La habitación ya existe en la base de datos";
                    V_resultado.OperacionSatisfactoria = false;
                }

            }
            catch (Exception ex)
            {
                //GuardarLOG(ex);
                V_resultado.MensajeUsuario = "Ocurrio un error, comuniquese con el encargado del sistema";
                V_resultado.OperacionSatisfactoria = false;
            }

            return V_resultado;


        }

        public static Resultado ModificarHabitaciones(Disponibilidad_Habitacion A_entidad)
        {
            Resultado V_resultado = new Resultado();
            Acceso_Habitaciones objacceso = new Acceso_Habitaciones();

            try
            {
                List<Disponibilidad_Habitacion> lstUsuarios = objacceso.Consultar(A_entidad);

                //Valida si la consulta NO retorno resultados, procede con agregar el cliente
                if (lstUsuarios.Count > 0)
                {
                    //Aqui ejecuta la acción de agregar usuario
                    V_resultado.OperacionSatisfactoria = objacceso.ModificarHabitacion(A_entidad);
                    if (!V_resultado.OperacionSatisfactoria)
                        V_resultado.MensajeUsuario = "Error al modificar información de la habitación";
                }
                else
                {
                    V_resultado.MensajeUsuario = "La habitación no existe en la base de datos";
                    V_resultado.OperacionSatisfactoria = false;
                }

            }
            catch (Exception ex)
            {
                //GuardarLOG(ex);
                V_resultado.MensajeUsuario = "Ocurrio un error, comuniquese con el encargado del sistema";
                V_resultado.OperacionSatisfactoria = false;
            }


            return V_resultado;
        }

        public static Resultado EliminarHabitacion(Disponibilidad_Habitacion A_entidad)
        {
            Resultado V_resultado = new Resultado();
            Acceso_Habitaciones objacceso = new Acceso_Habitaciones();

            try
            {
                List<Disponibilidad_Habitacion> lstUsuarios = objacceso.Consultar(A_entidad);

                //Valida si la consulta NO retorno resultados, procede con agregar el usuario
                if (lstUsuarios.Count > 0)
                {
                    //Aqui ejecuta la acción de agregar usuario
                    V_resultado.OperacionSatisfactoria = objacceso.EliminarHabitacion(A_entidad);
                    if (!V_resultado.OperacionSatisfactoria)
                        V_resultado.MensajeUsuario = "Error al eliminar información de la haitación";
                }
                else
                {
                    V_resultado.MensajeUsuario = "La habitación no existe en la base de datos";
                    V_resultado.OperacionSatisfactoria = false;
                }

            }
            catch (Exception ex)
            {
                //GuardarLOG(ex);
                V_resultado.MensajeUsuario = "Ocurrio un error, comuniquese con el encargado del sistema";
                V_resultado.OperacionSatisfactoria = false;
            }

            return V_resultado;
        }

        /// <summary>
        /// Metodo para listar usuarios registrados por Usuario
        /// </summary>
        /// <param name="P_Entidad">Entidad de tipo usuarios</param>
        /// <returns>Entidad Lista de tipo usuarios</returns>
        public static List<Disponibilidad_Habitacion> Consultar(Disponibilidad_Habitacion P_Entidad)
        {
            List<Disponibilidad_Habitacion> lstUsuarios = new List<Disponibilidad_Habitacion>();

            try
            {
                Acceso_Habitaciones objacceso = new Acceso_Habitaciones();
                lstUsuarios = objacceso.Consultar(P_Entidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lstUsuarios;
        }
        /// <summary>
        /// Metodo para listar usuarios registrados
        /// </summary>        
        /// <returns>Entidad Lista de tipo usuarios</returns>
        public static List<Disponibilidad_Habitacion> Consultar()
        {
            List<Disponibilidad_Habitacion> lstUsuarios = new List<Disponibilidad_Habitacion>();

            try
            {
                Acceso_Habitaciones objacceso = new Acceso_Habitaciones();
                lstUsuarios = objacceso.Consultar();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lstUsuarios;
        }
    }
}
