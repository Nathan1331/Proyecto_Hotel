using AccesoDatos;
using Entidades;
using LogicaNegocios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/Reservaciones")]
    [ApiController]
    public class ReservacionesController : ControllerBase
    {
        private readonly Hotel_Db_Context _hotel;

        public ReservacionesController(Hotel_Db_Context context)
        {
            _hotel = context;
        }
        [HttpGet]
        [Route(nameof(Consultar))]
        public IEnumerable<Reservaciones> Consultar()
        {
            return Logica_Reservaciones.Consultar(_hotel);
        }

        [HttpPost]
        [Route(nameof(ConsultarPorID))]
        public IEnumerable<Reservaciones> ConsultarPorID(Reservaciones P_entidad)
        {
            return Logica_Reservaciones.Consultar(P_entidad, _hotel);
        }

        [HttpPost]
        [Route(nameof(Modificar))]
        public Resultado Modificar(Reservaciones P_Entidad)
        {
            return Logica_Reservaciones.ModificarReservaciones(P_Entidad, _hotel);
        }

        [HttpPost]
        [Route(nameof(Eliminar))]
        public Resultado Eliminar(Reservaciones P_Entidad)
        {
            return Logica_Reservaciones.EliminarReservaciones(P_Entidad, _hotel);
        }

        [HttpPost]
        [Route(nameof(Agregar))]
        public Resultado Agregar(Reservaciones P_Entidad)
        {
            return Logica_Reservaciones.AgregarReservaciones(P_Entidad, _hotel);
        }
    }
}
