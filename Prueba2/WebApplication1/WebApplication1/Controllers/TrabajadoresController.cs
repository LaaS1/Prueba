using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Service.Interface;

namespace WebApplication1.Controllers
{
    public class TrabajadoresController : Controller
    {

        private readonly ITrabajadoresService _trabajadoresService;

        public TrabajadoresController(ITrabajadoresService trabajadoresService)
        {
            _trabajadoresService = trabajadoresService;

        }


        [HttpGet]
        public async Task<ActionResult<Respuesta>> GetAll()
        {
            Respuesta respuesta = await _trabajadoresService.GetAll();
            
            return Ok(respuesta);
        }


        [HttpGet]
        public async Task<ActionResult<Respuesta>> Get(int id)
        {
            Respuesta respuesta = await _trabajadoresService.GetId(id);
           
            return Ok(respuesta);
        }


        [HttpPost]
        public async Task<ActionResult<Respuesta>> Create([FromBody] Trabajadores model)
        {
            Respuesta respuesta = await _trabajadoresService.Create(model);
            
            return Ok(respuesta);
        }


        [HttpPut]
        public async Task<ActionResult<Respuesta>> Update([FromBody] Trabajadores model)
        {
            Respuesta respuesta = await _trabajadoresService.Update(model);
           
            return Ok(respuesta);
        }


        [HttpDelete]
        public async Task<ActionResult<Respuesta>> Delete(int id)
        {
            Respuesta respuesta = await _trabajadoresService.Delete(id);
           
            return Ok(respuesta);
        }




    }
}
