using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocios
{
    public class Logica_Reservaciones
    {
        public static Resultado AgregarReservaciones(Reservaciones A_entidad, Hotel_Db_Context hotel_Db)
        {
            Resultado V_resultado = new Resultado();
            Acceso_Reservaciones objacceso = new Acceso_Reservaciones(hotel_Db);

            try
            {
                List<Reservaciones> lstUsuarios = objacceso.Consultar();

                lstUsuarios = lstUsuarios.FindAll(x => x.Id_habitacion.ToUpper().Equals(A_entidad.Id_habitacion.ToUpper()));

                if (lstUsuarios.Count == 0)
                {
                    //Aqui ejecuta la acción de agregar usuario
                    V_resultado.OperacionSatisfactoria = objacceso.AgregarReservacion(A_entidad);
                    if (!V_resultado.OperacionSatisfactoria)
                        V_resultado.MensajeUsuario = "Error al guardar información la reservación";
                }
                else
                {
                    bool band = true;

                    foreach (var item in lstUsuarios)
                    {
                        if (A_entidad.Fecha_llegada.Date >= item.Fecha_llegada.Date && A_entidad.Fecha_llegada.Date <= item.Fecha_salida.Date)
                        {
                            band = false;
                        }
                        else
                        {
                            if (A_entidad.Fecha_salida.Date <= item.Fecha_salida.Date && A_entidad.Fecha_salida.Date >= item.Fecha_llegada.Date)
                            {
                                band = false;
                            }
                        }
                    }

                    if (band)
                    {
                        //Aqui ejecuta la acción de agregar usuario
                        V_resultado.OperacionSatisfactoria = objacceso.AgregarReservacion(A_entidad);
                        if (!V_resultado.OperacionSatisfactoria)
                            V_resultado.MensajeUsuario = "Error al guardar información la reservación";
                    }
                    else
                    {
                        V_resultado.MensajeUsuario = "La reservación ya existe en la base de datos";
                        V_resultado.OperacionSatisfactoria = false;
                    }
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




        public static Resultado ModificarReservaciones(Reservaciones A_entidad, Hotel_Db_Context hotel_Db)
        {
            Resultado V_resultado = new Resultado();
            Acceso_Reservaciones objacceso = new Acceso_Reservaciones(hotel_Db);

            try
            {
                List<Reservaciones> lstUsuarios = objacceso.Consultar(A_entidad);

                //Valida si la consulta NO retorno resultados, procede con agregar el cliente
                if (lstUsuarios.Count > 0)
                {
                    //Aqui ejecuta la acción de agregar usuario
                    V_resultado.OperacionSatisfactoria = objacceso.ModificarReservacion(A_entidad);
                    if (!V_resultado.OperacionSatisfactoria)
                        V_resultado.MensajeUsuario = "Error al modificar información de la reservación";
                }
                else
                {
                    V_resultado.MensajeUsuario = "La reservación no existe en la base de datos";
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

        public static Resultado EliminarReservaciones(Reservaciones A_entidad, Hotel_Db_Context hotel_Db)
        {
            Resultado V_resultado = new Resultado();
            Acceso_Reservaciones objacceso = new Acceso_Reservaciones(hotel_Db);

            try
            {
                List<Reservaciones> lstUsuarios = objacceso.Consultar(A_entidad);

                //Valida si la consulta NO retorno resultados, procede con agregar el usuario
                if (lstUsuarios.Count > 0)
                {
                    //Aqui ejecuta la acción de agregar usuario
                    V_resultado.OperacionSatisfactoria = objacceso.EliminarReservacion(A_entidad);
                    if (!V_resultado.OperacionSatisfactoria)
                        V_resultado.MensajeUsuario = "Error al eliminar información de la reservación";
                }
                else
                {
                    V_resultado.MensajeUsuario = "La reservación no existe en la base de datos";
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
        public static List<Reservaciones> Consultar(Reservaciones P_Entidad, Hotel_Db_Context context)
        {
            List<Reservaciones> lstUsuarios = new List<Reservaciones>();

            try
            {
                Acceso_Reservaciones objacceso = new Acceso_Reservaciones(context);
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
        public static List<Reservaciones> Consultar(Hotel_Db_Context context)
        {
            List<Reservaciones> lstUsuarios = new List<Reservaciones>();

            try
            {
                Acceso_Reservaciones objacceso = new Acceso_Reservaciones(context);
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
