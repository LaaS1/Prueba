using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Context.Config
{
    public class AplicacionDistritoConfig
    {

        public  AplicacionDistritoConfig(EntityTypeBuilder<Distrito> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("Distrito");
            entityTypeBuilder.Property(entity => entity.Id).HasColumnName("Id").HasColumnType("int");
            entityTypeBuilder.Property(entity => entity.IdProvincia).HasColumnName("IdProvincia").HasColumnType("int");
            entityTypeBuilder.Property(entity => entity.NombreDistrito).HasColumnName("NombreDistrito").HasColumnType("varchar(500)");
        }



    }
}
