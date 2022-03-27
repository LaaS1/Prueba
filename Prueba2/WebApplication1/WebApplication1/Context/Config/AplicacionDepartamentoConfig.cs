using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Context.Config
{
    public class AplicacionDepartamentoConfig
    {

        public AplicacionDepartamentoConfig(EntityTypeBuilder<Departamento> entityTypeBuilder)
        {

            entityTypeBuilder.ToTable("Departamento");
            entityTypeBuilder.Property(entity => entity.Id).HasColumnName("Id").HasColumnType("int");
            entityTypeBuilder.Property(entity => entity.NombreDepartamento).HasColumnType("NombreDepartamento").HasColumnType("varchar(500)");

        }



    }
}
