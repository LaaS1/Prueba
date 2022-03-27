using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Service.Interface;
using WebApplication1.Service.Repositorios;

namespace WebApplication1.Controllers
{
    public class DepartamentoController : Controller
    {
        private readonly IDepartamentoService _DepartamentoService;

        public DepartamentoController(IDepartamentoService DepartamentoService)
        {
            _DepartamentoService = DepartamentoService;

        }

        [HttpGet]
        public async Task<ActionResult<Respuesta>> GetAll()
        {
            Respuesta respuesta = await _DepartamentoService.GetAll();
            
            return Ok(respuesta);
        }




    }
}
