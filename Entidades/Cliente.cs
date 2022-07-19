using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int _id { get; set; }

        public string Identificacion { get; set; }

        public string Nombre { get; set; }

        public string Apellidos { get; set; }

        public string Correo { get; set; }

        public string Telefono { get; set; }




        public Cliente()
        {
            Identificacion = string.Empty;
            Nombre = string.Empty;
            Apellidos = string.Empty;
            Correo = string.Empty;
            Telefono = string.Empty;

        }
    }
}