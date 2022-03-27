using Microsoft.EntityFrameworkCore;
using WebApplication1.Context.Config;
using WebApplication1.Models;

namespace WebApplication1.Context
{
    public class AplicacionContext :DbContext
    {

        public AplicacionContext(DbContextOptions<AplicacionContext> options) : base(options)
        {

        }

        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Distrito> Distritos { get; set; }
        public DbSet<Provincia> Provincias { get; set; }

        public DbSet<Trabajadores> Trabajadores { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new AplicacionDepartamentoConfig(modelBuilder.Entity<Departamento>());
            new AplicacionDistritoConfig(modelBuilder.Entity<Distrito>());  
            new AplicacionProvinciaConfig(modelBuilder.Entity<Provincia>());   
            new AplicacionTrabajadoresConfig(modelBuilder.Entity<Trabajadores>());
        }



    }
}
