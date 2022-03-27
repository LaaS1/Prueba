using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Service.Interface;

namespace WebApplication1.Controllers
{
    public class ProvinciaController : Controller
    {

        private readonly IProvinciaService _provinciaService;

        public ProvinciaController(IProvinciaService provinciaService)
        {
            _provinciaService = provinciaService;

        }

        [HttpGet]
        public async Task<ActionResult<Respuesta>> GetAllByIdDepartamento(int IdDepartamento)
        {
            Respuesta respuesta = await _provinciaService.GetAllByIdDepartamento(IdDepartamento);
           
            return Ok(respuesta);
        }


    }
}
