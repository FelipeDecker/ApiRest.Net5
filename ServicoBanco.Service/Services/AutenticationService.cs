using ServicoBanco.Domain.Entities;
using ServicoBanco.DomainService.IRepositories;
using ServicoBanco.DomainService.IServices;
using System;
using System.Threading.Tasks;

namespace ServicoBanco.Service.Services
{
    public class AutenticationService : ServiceBase, IAutenticationService
    {
        private readonly IUnitOfWork _repUnitOfWork;

        public AutenticationService(IUnitOfWork repUnitOfWork)
        {
            _repUnitOfWork = repUnitOfWork;
        }

        public async Task Autenticar(string banco)
        {
            if (banco == "")
            {
                //GerarErro("Banco de dados não especificado");
            }

            //if (token == "")
            //{
            //    throw new Exception("Chave de autenticação invalida");
            //}

            //LicencaEntity licenca = await _repUnitOfWork.Licenca.BuscarPrimeiroAsync(LicencaExpression.BuscarPorLicenca(Guid.Parse(token)));

            //if (licenca == null)
            //{
            //    throw new Exception("Sua licença para usar a API não foi encontrada");
            //}

            //if (licenca.DataValidade < DateTime.Now || licenca.Descricao != "Servico Banco API")
            //{
            //    throw new Exception("Chave de autenticação invalida");
            //}
        }

        public async Task Criar()
        {
            await _repUnitOfWork.Licenca.AdicionarAsync(new LicencaEntity());
        }
    }
}
