using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using WebApplication1.Context;
using WebApplication1.Models;
using WebApplication1.Service.Interface;

namespace WebApplication1.Service.Repositorios
{
    public class DepartamentoService : IDepartamentoService
    {

        private readonly AplicacionContext _db;
        public DepartamentoService(AplicacionContext db)
        {
            _db = db;
        }

        public async Task<Respuesta> GetAll()
        {
            Respuesta respuesta = new Respuesta();

            try
            {

                respuesta.Data = await _db.Departamentos.ToListAsync();
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
