using ServicoBanco.Domain.Commands;
using ServicoBanco.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServicoBanco.DomainService.IServices
{
    public interface IClienteEnderecoService
    {
        Task Adicionar(ClienteEnderecoCommand command);

        Task Deletar(ClienteEnderecoCommand command);

        Task Atualizar(ClienteEnderecoCommand command);

        Task<ICollection<ClienteEnderecoEntity>> BuscarTodos();

        Task<ClienteEnderecoEntity> BuscarPorEndereco(decimal codigoCliente, decimal codigoEndereco);

        Task<ClienteEnderecoEntity> BuscarPorUltimoEndereco(decimal codigoCliente);
    }
}
