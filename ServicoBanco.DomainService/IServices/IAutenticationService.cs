using System.Threading.Tasks;

namespace ServicoBanco.DomainService.IServices
{
    public interface IAutenticationService
    {
        Task Autenticar(string banco);
    }
}
