using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Context;
using WebApplication1.Models;
using WebApplication1.Service.Interface;
using WebApplication1.ViewModel;

namespace WebApplication1.Service.Repositorios
{
    public class TrabajadoresService : ITrabajadoresService
    {

        private readonly AplicacionContext _db;
        public TrabajadoresService(AplicacionContext db)
        {
            _db = db;
        }


        public async Task<Respuesta> Create(Trabajadores model)
        {
            Respuesta respuesta = new Respuesta();

            try
            {
                bool trabajadorexiste = _db.Trabajadores.Any(x => x.NumeroDocumento == model.NumeroDocumento);
                if (trabajadorexiste)
                {
                    respuesta.Data = "El número de Documento ya esta asignado a otro trabajador";
                    respuesta.Resultado = false;
                }
                else
                {
                    _db.Trabajadores.Add(model);
                    await _db.SaveChangesAsync();

                    respuesta.Data = "Registro Creado";
                    respuesta.Resultado = true;
                }
 
            }
            catch (Exception ex)
            {
                respuesta.Data=ex.Message;
                respuesta.Resultado = false;
                
            }

            return respuesta;
        }



        public async Task<Respuesta> Delete(int Id)
        {
            Respuesta respuesta = new Respuesta();

            try
            {
                Trabajadores trabajadores = await _db.Trabajadores.FindAsync(Id);
                _db.Trabajadores.Remove(trabajadores);
                await _db.SaveChangesAsync();

                respuesta.Data = "Registro Eliminado";
                respuesta.Resultado = true;

            }
            catch (Exception ex)
            {
                respuesta.Data = ex.Message;
                respuesta.Resultado = false;

            }

            return respuesta;
        }




        public async Task<Respuesta> GetAll()
        {

            Respuesta respuesta = new Respuesta();

            try
            {

                List<TrabajadoresViewModel> lstTrabajadores = await (from trab in _db.Trabajadores
                                                                     join dep in _db.Departamentos on trab.IdDepartamento equals dep.Id
                                                                     join prov in _db.Provincias on trab.IdProvincia equals prov.Id
                                                                     join dist in _db.Distritos on trab.IdDistrito equals dist.Id
                                                             select new TrabajadoresViewModel
                                                             {
                                                                 Id  = trab.Id,
                                                                 TipoDocumento = trab.TipoDocumento,
                                                                 NumeroDocumento = trab.NumeroDocumento,
                                                                 Nombres = trab.Nombres,
                                                                 Sexo = trab.Sexo,
                                                                 Departamento = dep.NombreDepartamento,
                                                                 Provincia = prov.NombreProvincia,
                                                                 Distrito = dist.NombreDistrito
                                                             }).ToListAsync();

                respuesta.Data = lstTrabajadores;
                respuesta.Resultado = true;

            }
            catch (Exception ex)
            {
                respuesta.Data = ex.Message;
                respuesta.Resultado = false;

            }

            return respuesta;

        }



        public async Task<Respuesta> GetId(int Id)
        {

            Respuesta respuesta = new Respuesta();

            try
            {

                respuesta.Data = await _db.Trabajadores.FindAsync(Id);
                respuesta.Resultado = true;

            }
            catch (Exception ex)
            {
                respuesta.Data = ex.Message;
                respuesta.Resultado = false;

            }

            return respuesta;
        }



        public async Task<Respuesta> Update(Trabajadores model)
        {
            Respuesta respuesta = new Respuesta();

            try
            {
                bool trabajadorexiste = _db.Trabajadores.Any(x => x.NumeroDocumento == model.NumeroDocumento && x.Id != model.Id);
                if (trabajadorexiste)
                {
                    respuesta.Data = "El número de Documento ya esta siendo Utilizado";
                    respuesta.Resultado = false;
                }
                else
                {
                    _db.Trabajadores.Update(model);
                    await _db.SaveChangesAsync();
                    respuesta.Data = "Registro Actualizado";
                    respuesta.Resultado = true;
                }

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
