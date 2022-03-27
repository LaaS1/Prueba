using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Departamento
    {


        [Key]
        public int Id { get; set; }

        public string NombreDepartamento { get; set; }
    }
}
