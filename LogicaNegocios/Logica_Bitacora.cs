using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using AccesoDatos;

namespace LogicaNegocios
{
    public class Logica_Bitacora
    {
        public static List<BitacoraHotel> ConsultarBitacora()
        {
            AccesoDatoBitacoraMongoDB objacceso = new AccesoDatoBitacoraMongoDB();
            return objacceso.ConsultarBitacora();
        }

       
        public static Resultado AgregarRegistroBitacora (BitacoraHotel P_Bitacora)
        {
            AccesoDatoBitacoraMongoDB objacceso = new AccesoDatoBitacoraMongoDB();
            Resultado objresultado = new Resultado();

            //Obtengo los registros de usuarios
            List<BitacoraHotel> LstBitacora = objacceso.ConsultarBitacora();

            //Aqui busca si en la lista de registros EXISTE el usuario por agregar
            BitacoraHotel encontrado = LstBitacora.Find(match: x => x.NumeroRegistro.Equals(P_Bitacora.NumeroRegistro));
            if (encontrado == null) //Quiere decir que el usuario no existe en BD, por lo tanto, puedo ingresarlo sin repeticion
            {
                if (!objacceso.AgregarUsuario(P_Bitacora)) //Si sucedio un error a la hora de registrar
                {
                    objresultado = new Resultado
                    {
                        OperacionSatisfactoria = false,
                        MensajeUsuario = "Ocurrio un error al registrar, reintentar o comunicarse con el administrador del sistema",                        
                    };
                }
            }
            else
            {
                objresultado = new Resultado
                {
                    OperacionSatisfactoria = true,
                    MensajeUsuario = "Usuario por registrar, existe en base de datos",
                };
            }

            return objresultado;
        }
    }
}
