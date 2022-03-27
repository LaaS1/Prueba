using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Service.Interface
{
    public interface IProvinciaService
    {

        Task<Respuesta> GetAllByIdDepartamento(int IdDepartamento);
    }
}
