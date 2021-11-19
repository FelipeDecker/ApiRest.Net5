using ServicoBanco.Domain.Commands;
using System.Threading.Tasks;

namespace ServicoBanco.DomainService.IServices
{
    public interface ILoginService
    {
        Task<object> GerarToken(LoginCommand command);
    }
}
