﻿using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Service.Interface
{
    public interface IDepartamentoService
    {

        Task<Respuesta> GetAll();
    }
}
