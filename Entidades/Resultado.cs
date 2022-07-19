using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Resultado
    {
        public string MensajeUsuario { get; set; }
        public bool OperacionSatisfactoria { get; set; }

        public Resultado()
        {
            MensajeUsuario = "Operacion realizada con exito";
            OperacionSatisfactoria = true;
        }
    }
}
