using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Provincia
    {

        [Key]
        public int Id { get; set; }

        public int IdDepartamento { get; set; }

        public string NombreProvincia { get; set; }
    }
}
