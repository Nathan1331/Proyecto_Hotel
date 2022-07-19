using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Disponibilidad_Habitacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int _id { set; get; }

        public string Id_habitacion { get; set; }

        public string Tipo_habitacion { get; set; }

        public string Estado_habitacion { get; set; }

        public Disponibilidad_Habitacion()
        {
            Id_habitacion = string.Empty;
            Tipo_habitacion = string.Empty;
            Estado_habitacion = string.Empty;

        }
    }
}
