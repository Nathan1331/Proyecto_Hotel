using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Reservaciones
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int _id { set; get; }

        public string Id_habitacion { get; set; }

        public DateTime Fecha_llegada { get; set; }

        public DateTime Fecha_salida { get; set; }

        public string cliente { get; set; }

        public int monto { get; set; }

        public string Observaciones { get; set; }



        public Reservaciones()
        {
            Observaciones = string.Empty;
            Fecha_llegada = DateTime.MinValue;
            Fecha_salida = DateTime.MinValue;
            monto = 0;
            cliente = string.Empty;
            Id_habitacion = string.Empty;
        }
    }
}
