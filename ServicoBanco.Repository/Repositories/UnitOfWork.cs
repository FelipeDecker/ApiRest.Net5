using Microsoft.EntityFrameworkCore;
using ServicoBanco.Domain.Entities;
using ServicoBanco.DomainService.IRepositories;
using ServicoBanco.Repository.Contexts;
using System;

namespace ServicoBanco.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private bool disposed = false;
        //private DbContext meuContexto;
        private readonly ApplicationDbContext _context;
        private readonly DeveloperDbContext _developer;

        private GenericRepository<ClienteEntity> ClienteRepository = null;
        private GenericRepository<ClienteEnderecoEntity> ClienteEnderecoRepository = null;
        private GenericRepository<LicencaEntity> LicencaRepository = null;
        private GenericRepository<TelefoneClienteEntity> TelefoneClienteRepository = null;

        public UnitOfWork(ApplicationDbContext context, DeveloperDbContext developer)
        {
            _context = context;
            _developer = developer;
        }

        public void AlteraConnectionString(string banco)
        {
            //if (banco == "teste")
            //{
            //    meuContexto = _context;
            //}

            //if (banco == "producao")
            //{
            //    meuContexto = _developer;
            //}
        }

        public IGenericRepository<ClienteEntity> Cliente
        {
            get
            {
                if (ClienteRepository == null)
                {
                    ClienteRepository = new GenericRepository<ClienteEntity>(_context);
                }

                return ClienteRepository;
            }
        }

        public IGenericRepository<ClienteEnderecoEntity> ClienteEndereco
        {
            get
            {
                if (ClienteEnderecoRepository == null)
                {
                    ClienteEnderecoRepository = new GenericRepository<ClienteEnderecoEntity>(_context);
                }

                return ClienteEnderecoRepository;
            }
        }

        public IGenericRepository<LicencaEntity> Licenca
        {
            get
            {
                if (LicencaRepository == null)
                {
                    LicencaRepository = new GenericRepository<LicencaEntity>(_context);
                }

                return LicencaRepository;
            }
        }

        public IGenericRepository<TelefoneClienteEntity> TelefoneCliente
        {
            get
            {
                if (TelefoneClienteRepository == null)
                {
                    TelefoneClienteRepository = new GenericRepository<TelefoneClienteEntity>(_context);
                }

                return TelefoneClienteRepository;
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
