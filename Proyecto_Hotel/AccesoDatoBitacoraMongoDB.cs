using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AccesoDatos
{
    public class AccesoDatoBitacoraMongoDB
    {
        #region Atributos

        //La instancia de BD hacia el mongoDb
        //private readonly string CadenaConexion = @"mongodb+srv://UsuarioMongoUAM:_UAM2021_@cluster0.biunx.mongodb.net/Seguridad?retryWrites=true&w=majority";
        private readonly string CadenaConexion = @"mongodb://localhost:27017";

        //Crear unas instancias (objetos) que se utilizaran para realizar la conexion
        private MongoClient InstanciaBD;
        private IMongoDatabase BaseDatos;

        //Se describe el nombre de la base de datos
        private const string NombreBD = "BitacoraHotel";
        #endregion

        #region Constructor
        public AccesoDatoBitacoraMongoDB()
        {
            try
            {
                ObtenerConexion();
            }
            catch (MongoException exMG)
            {
                throw exMG;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (InstanciaBD != null)
                    InstanciaBD = null;
                if (BaseDatos != null)
                    BaseDatos = null;
            }
        }

        #endregion


        #region VerificaConexionBD
        private bool ObtenerConexion()
        {
            bool ConexionCorrecta = false;

            try
            {
                //Inicializar o asignar el objeto de InstanciaMongo
                InstanciaBD = new MongoClient(CadenaConexion);

                //Se inicializa el objeto o interfaz de conexion a la BD dentro de la instancia del MongoDb
                BaseDatos = InstanciaBD.GetDatabase(NombreBD);

                ConexionCorrecta = BaseDatos.RunCommandAsync((Command<BsonDocument>)"{ping:1}").Wait(1000);

            }
            catch (MongoException exMG)
            {
                throw exMG;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ConexionCorrecta;
        }
        #endregion

        #region MetodosPublicos

        public bool AgregarUsuario(BitacoraHotel P_Bitacora)
        {
            bool V_resultado = false;

            try
            {
                ObtenerConexion();

                var V_Coleccion = BaseDatos.GetCollection<BitacoraHotel>("BitacoraHotel");
                V_Coleccion.InsertOne(P_Bitacora);
                V_resultado = true;
            }
            catch (MongoException exM)
            {
                throw exM;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (InstanciaBD != null)
                    InstanciaBD = null;
                if (BaseDatos != null)
                    BaseDatos = null;
            }

            return V_resultado;
        }

        /// <summary>
        /// Metodo para listar todos los registros en la base de datos referentes a usuarios 
        /// </summary>
        /// <returns>Entidad Lista de tipo Usuarios</returns>
        public List<BitacoraHotel> ConsultarBitacora()
        {
            List<BitacoraHotel> lstresultados = new List<BitacoraHotel>();

            try
            {
                ObtenerConexion();
                var V_Coleccion = BaseDatos.GetCollection<BitacoraHotel>("BitacoraHotel");
                lstresultados = V_Coleccion.Find(d => true).ToList();
            }
            catch (MongoException exM)
            {
                throw exM;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (InstanciaBD != null)
                    InstanciaBD = null;
                if (BaseDatos != null)
                    BaseDatos = null;
            }

            return lstresultados;
        }

        #endregion


    }
}
