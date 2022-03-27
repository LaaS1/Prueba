using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Context.Config
{
    public class AplicacionProvinciaConfig
    {

        public AplicacionProvinciaConfig(EntityTypeBuilder<Provincia> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("Provincia");
            entityTypeBuilder.Property(entity => entity.Id).HasColumnName("Id").HasColumnType("int");
            entityTypeBuilder.Property(entity => entity.IdDepartamento).HasColumnName("IdDepartamento").HasColumnType("int");
            entityTypeBuilder.Property(entity => entity.NombreProvincia).HasColumnName("NombreProvincia").HasColumnType("varchar(500)");


        }




    }
}
