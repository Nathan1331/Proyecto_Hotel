using AccesoDatos;
using Entidades;
using LogicaNegocios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/Disponibilidad")]
    [ApiController]
    public class DisponibilidadController : ControllerBase
    {

        private readonly Hotel_Db_Context _hotel;

        public DisponibilidadController(Hotel_Db_Context context)
        {
            _hotel = context;
        }
        [HttpGet]
        [Route(nameof(Consultar))]
        public IEnumerable<Disponibilidad_Habitacion> Consultar()
        {
            return Logica_Habitaciones.Consultar(_hotel);
        }

        //[HttpPost]
        //[Route(nameof(ConsultarPorID))]
        //public IEnumerable<Disponibilidad_Habitacion> ConsultarPorID()
        //{
        //    List<Disponibilidad_Habitacion> lst = new List<Disponibilidad_Habitacion>();
        //    lst.Add(Logica_Habitaciones.Consultar(P_entidad, _hotel));
        //    return lst;
        //}
        [HttpPost]
        [Route(nameof(ConsultarPorID))]
        public IEnumerable<Disponibilidad_Habitacion> ConsultarPorID(Disponibilidad_Habitacion P_entidad)
        {
            List<Disponibilidad_Habitacion> lst = new List<Disponibilidad_Habitacion>();
            lst.Add(Logica_Habitaciones.Consultar(P_entidad, _hotel));
            return lst;
        }

        [HttpPost]
        [Route(nameof(Modificar))]
        public Resultado Modificar(Disponibilidad_Habitacion P_Entidad)
        {
            return Logica_Habitaciones.ModificarHabitaciones(P_Entidad, _hotel);
        }

        [HttpPost]
        [Route(nameof(Eliminar))]
        public Resultado Eliminar(Disponibilidad_Habitacion P_Entidad)
        {
            return Logica_Habitaciones.EliminarHabitacion(P_Entidad, _hotel);
        }

        [HttpPost]
        [Route(nameof(Agregar))]
        public Resultado Agregar(Disponibilidad_Habitacion P_Entidad)
        {
            return Logica_Habitaciones.AgregarHabitaciones(P_Entidad, _hotel);
        }
    }
}
