using Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class Hotel_Db_Context : DbContext
    {
        public Hotel_Db_Context(DbContextOptions<Hotel_Db_Context> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Disponibilidad_Habitacion> Disponibilidad_Habitacions { get; set; }
        public DbSet<Reservaciones> Reservaciones { get; set; }


    }
}
