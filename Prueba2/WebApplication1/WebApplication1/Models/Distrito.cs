using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Distrito
    {


        [Key]
        public int Id { get; set; }

        public int IdProvincia { get; set; }

        public string NombreDistrito { get; set; }
    }
}
