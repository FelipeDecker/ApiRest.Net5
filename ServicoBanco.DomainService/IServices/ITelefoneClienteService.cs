using ServicoBanco.Domain.Commands;
using ServicoBanco.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServicoBanco.DomainService.IServices
{
    public interface ITelefoneClienteService
    {
        Task Adicionar(TelefoneClienteCommand command);

        Task Atualizar(TelefoneClienteCommand command);

        Task Deletar(TelefoneClienteCommand command);

        Task<TelefoneClienteEntity> BuscarPorCodigoTelefone(decimal codigoCliente, decimal codigoContato);

        Task<TelefoneClienteEntity> BuscarPorTelefone(decimal codigoCliente, decimal telefone);

        Task<TelefoneClienteEntity> BuscarPorUltimoTelefone(decimal codigoCliente);

        Task<TelefoneClienteEntity> BuscarPorEmail(decimal codigoCliente, string email);

        Task<ICollection<TelefoneClienteEntity>> BuscarTodos(decimal codigoCliente);

        Task<ICollection<TelefoneClienteEntity>> BuscarPorSituacao(decimal codigoCliente, decimal ativo);

        Task<ICollection<TelefoneClienteEntity>> BuscarPorTipoContato(decimal codigoCliente, decimal tipo);
    }
}
