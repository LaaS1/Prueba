using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Service.Interface;

namespace WebApplication1.Controllers
{
    public class DistritoController : Controller
    {

        private readonly IDistritoService _distritoService;

        public DistritoController(IDistritoService distritoService)
        {
            _distritoService = distritoService;

        }

        [HttpGet]
        public async Task<ActionResult<Respuesta>> GetAllByIdProvincia(int IdProvincia)
        {
            Respuesta respuesta = await _distritoService.GetAllByIdProvincia(IdProvincia);
           
            return Ok(respuesta);
        }

    }
}
