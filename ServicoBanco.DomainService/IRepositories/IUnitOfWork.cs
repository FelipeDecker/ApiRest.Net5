using ServicoBanco.Domain.Entities;

namespace ServicoBanco.DomainService.IRepositories
{
    public interface IUnitOfWork
    {
        IGenericRepository<ClienteEntity> Cliente { get; }
        IGenericRepository<ClienteEnderecoEntity> ClienteEndereco { get; }
        IGenericRepository<LicencaEntity> Licenca { get; }
        IGenericRepository<TelefoneClienteEntity> TelefoneCliente { get; }

        void Commit();
    }
}
