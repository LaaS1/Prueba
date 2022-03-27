using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Context;
using WebApplication1.Models;
using WebApplication1.Service.Interface;

namespace WebApplication1.Service.Repositorios
{
    public class DistritoService : IDistritoService
    {


        private readonly AplicacionContext _db;

        public DistritoService(AplicacionContext db)
        {
            _db = db;
        }


        public  async Task<Respuesta> GetAllByIdProvincia( int IdProvincia)
        {
            Respuesta respuesta = new Respuesta();

            try
            {

                respuesta.Data = await _db.Distritos.Where(x => x.IdProvincia == IdProvincia).ToListAsync();
                respuesta.Resultado = true;

            }
            catch (Exception ex)
            {
                respuesta.Data = ex.Message;
                respuesta.Resultado = false;

            }

            return respuesta;
        }
    }
}
