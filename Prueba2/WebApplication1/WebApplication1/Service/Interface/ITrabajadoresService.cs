﻿using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Service.Interface
{
    public interface ITrabajadoresService
    {

        Task<Respuesta> GetAll();
        Task<Respuesta> GetId(int Id);
        Task<Respuesta> Create(Trabajadores model);
        Task<Respuesta> Update(Trabajadores model);
        Task<Respuesta> Delete(int Id);

    }
}
