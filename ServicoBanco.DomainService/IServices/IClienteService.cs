using ServicoBanco.Domain.Commands;
using ServicoBanco.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServicoBanco.DomainService.IServices
{
    public interface IClienteService
    {
        Task Adicionar(ClienteCommand command);

        Task Deletar(ClienteCommand command);

        Task Atualizar(ClienteCommand command);

        Task AtualizarRh(ClienteCommand command);

        Task<ICollection<ClienteEntity>> BuscarTodos();

        Task<ICollection<ClienteEntity>> BuscarTodosAtivos();

        Task<ICollection<ClienteEntity>> BuscarPorNome(string nome);

        Task<ClienteEntity> BuscarPorCodigo(decimal codigo);

        Task<ClienteEntity> BuscarPorCpf(decimal cpf);

        Task<ClienteEntity> BuscarPorCnpj(decimal cnpj);
    }
}
