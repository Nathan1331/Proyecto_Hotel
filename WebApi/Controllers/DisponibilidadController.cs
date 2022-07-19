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
        [HttpGet]
        [Route(nameof(Consultar))]
        public IEnumerable<Disponibilidad_Habitacion> Consultar()
        {
            return Logica_Habitaciones.Consultar();
        }

        [HttpGet]
        [Route(nameof(ConsultarPorID))]
        public IEnumerable<Disponibilidad_Habitacion> ConsultarPorID(Disponibilidad_Habitacion P_entidad)
        {
            return Logica_Habitaciones.Consultar(P_entidad);
        }

        [HttpPost]
        [Route(nameof(Modificar))]
        public Resultado Modificar(Disponibilidad_Habitacion P_Entidad)
        {
            return Logica_Habitaciones.ModificarHabitaciones(P_Entidad);
        }

        [HttpPost]
        [Route(nameof(Eliminar))]
        public Resultado Eliminar(Disponibilidad_Habitacion P_Entidad)
        {
            return Logica_Habitaciones.EliminarHabitacion(P_Entidad);
        }

        [HttpPost]
        [Route(nameof(Agregar))]
        public Resultado Agregar(Disponibilidad_Habitacion P_Entidad)
        {
            return Logica_Habitaciones.AgregarHabitaciones(P_Entidad);
        }
    }
}
