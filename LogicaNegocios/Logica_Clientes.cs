using AccesoDatos;
using Entidades;
using Proyecto_Hotel;

namespace LogicaNegocios
{
    public class Logica_Clientes
    {
        public static Resultado AgregarCliente(Cliente A_entidad, Hotel_Db_Context hotel_Db)
        {
            Resultado V_resultado = new Resultado();
            Acceso_Clientes objacceso = new Acceso_Clientes(hotel_Db);

            try
            {
                List<Cliente> lstUsuarios = objacceso.Consultar();
                lstUsuarios = lstUsuarios.FindAll(x => x.Identificacion.ToUpper().Equals(A_entidad.Identificacion.ToUpper()));

                //Valida si la consulta NO retorno resultados, procede con agregar el usuario
                if (lstUsuarios.Count == 0)
                {
                    //Aqui ejecuta la acción de agregar usuario
                    V_resultado.OperacionSatisfactoria = objacceso.AgregarCliente(A_entidad);
                    if (!V_resultado.OperacionSatisfactoria)
                        V_resultado.MensajeUsuario = "Error al guardar información del cliente";
                }
                else
                {
                    V_resultado.MensajeUsuario = "El clientr ya existe en la base de datos";
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




        public static Resultado ModificarCliente(Cliente A_entidad, Hotel_Db_Context hotel_Db)
        {
            Resultado V_resultado = new Resultado();
            Acceso_Clientes objacceso = new Acceso_Clientes(hotel_Db);

            try
            {
                List<Cliente> lstUsuarios = objacceso.Consultar(A_entidad);

                //Valida si la consulta NO retorno resultados, procede con agregar el cliente
                if (lstUsuarios.Count > 0)
                {
                    //Aqui ejecuta la acción de agregar usuario
                    V_resultado.OperacionSatisfactoria = objacceso.ModificarCliente(A_entidad);
                    if (!V_resultado.OperacionSatisfactoria)
                        V_resultado.MensajeUsuario = "Error al modificar información del cliente";
                }
                else
                {
                    V_resultado.MensajeUsuario = "El cliente no existe en la base de datos";
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

        public static Resultado EliminarCliente(Cliente A_entidad, Hotel_Db_Context hotel_Db)
        {
            Resultado V_resultado = new Resultado();
            Acceso_Clientes objacceso = new Acceso_Clientes(hotel_Db);

            try
            {
                List<Cliente> lstUsuarios = objacceso.Consultar(A_entidad);

                //Valida si la consulta NO retorno resultados, procede con agregar el usuario
                if (lstUsuarios.Count > 0)
                {
                    //Aqui ejecuta la acción de agregar usuario
                    V_resultado.OperacionSatisfactoria = objacceso.EliminarCliente(A_entidad);
                    if (!V_resultado.OperacionSatisfactoria)
                        V_resultado.MensajeUsuario = "Error al eliminar información del cliente";
                }
                else
                {
                    V_resultado.MensajeUsuario = "El cliente no existe en la base de datos";
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
        public static List<Cliente> Consultar(Cliente P_Entidad, Hotel_Db_Context hotel_Db)
        {
            List<Cliente> lstUsuarios = new List<Cliente>();

            try
            {
                Acceso_Clientes objacceso = new Acceso_Clientes(hotel_Db);
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
        public static List<Cliente> Consultar(Hotel_Db_Context hotel_Db)
        {
            List<Cliente> lstUsuarios = new List<Cliente>();

            try
            {
                Acceso_Clientes objacceso = new Acceso_Clientes(hotel_Db);
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