using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entidades;
using LogicaNegocios;

namespace WebApi.Controllers
{
    [Route("api/Cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        [Route(nameof(Consultar))]
        public IEnumerable<Cliente> Consultar()
        {
            return Logica_Clientes.Consultar();
        }

        [HttpGet]
        [Route(nameof(ConsultarPorID))]
        public IEnumerable<Cliente> ConsultarPorID(Cliente P_entidad)
        {
            return Logica_Clientes.Consultar(P_entidad);
        }

        [HttpPost]
        [Route(nameof(Modificar))]
        public Resultado Modificar(Cliente P_Entidad)
        {
            return Logica_Clientes.ModificarCliente(P_Entidad);
        }

        [HttpPost]
        [Route(nameof(Eliminar))]
        public Resultado Eliminar(Cliente P_Entidad)
        {
            return Logica_Clientes.EliminarCliente(P_Entidad);
        }

        [HttpPost]
        [Route(nameof(Agregar))]
        public Resultado Agregar(Cliente P_Entidad)
        {
            return Logica_Clientes.AgregarCliente(P_Entidad);
        }

    }
}
