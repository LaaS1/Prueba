using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Context.Config
{
    public class AplicacionTrabajadoresConfig
    {

        public AplicacionTrabajadoresConfig(EntityTypeBuilder<Trabajadores> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("Trabajadores");
            entityTypeBuilder.Property(entity => entity.Id).HasColumnName("Id").HasColumnType("int");
            entityTypeBuilder.Property(entity => entity.TipoDocumento).HasColumnName("TipoDocumento").HasColumnType("varchar(3)");
            entityTypeBuilder.Property(entity => entity.NumeroDocumento).HasColumnName("NumeroDocumento").HasColumnType("varchar(50)");
            entityTypeBuilder.Property(entity => entity.Nombres).HasColumnName("Nombres").HasColumnType("varchar(500)");
            entityTypeBuilder.Property(entity => entity.Sexo).HasColumnName("Sexo").HasColumnType("varchar(1)");
            entityTypeBuilder.Property(entity => entity.IdDepartamento).HasColumnName("IdDepartamento").HasColumnType("int");
            entityTypeBuilder.Property(entity => entity.IdProvincia).HasColumnName("IdProvincia").HasColumnType("int");
            entityTypeBuilder.Property(entity => entity.IdDistrito).HasColumnName("IdDistrito").HasColumnType("int");


        }


    }
}
