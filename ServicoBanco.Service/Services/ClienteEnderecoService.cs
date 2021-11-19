using ServicoBanco.Domain.Commands;
using ServicoBanco.Domain.Entities;
using ServicoBanco.DomainService.Expressions;
using ServicoBanco.DomainService.Factories;
using ServicoBanco.DomainService.IRepositories;
using ServicoBanco.DomainService.IServices;
using ServicoBanco.DomainService.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoBanco.Service.Services
{
    public class ClienteEnderecoService : ServiceBase, IClienteEnderecoService
    {
        private readonly IUnitOfWork _repUnitOfWork;
        private readonly ClienteEnderecoValidator _clienteValidator;
        private readonly ClienteEnderecoFactory _clienteEnderecoFactory;

        public ClienteEnderecoService(IUnitOfWork unitOfWork)
        {
            _repUnitOfWork = unitOfWork;
            _clienteValidator = new ClienteEnderecoValidator();
            _clienteEnderecoFactory = new ClienteEnderecoFactory();
        }

        public async Task Adicionar(ClienteEnderecoCommand command)
        {
            _clienteValidator.ValidarCadastro(command);

            ICollection<ClienteEnderecoEntity> enderecos = await _repUnitOfWork.ClienteEndereco.BuscarTodosAsync(ClienteEnderecoExpression.BuscarPorCodigoCliente(command.CodigoCliente));

            if (enderecos.Where(x => x.Notificacao == 1).ToList().Count == 0)
            {
                command.Notificacao = 1;
            }
            else if (command.Notificacao == 1)
            {
                command.Notificacao = 1;

                var enderecosComNotificacao = enderecos.Where(x => x.Notificacao == 1).ToList();

                foreach (var endereco in enderecosComNotificacao)
                {
                    endereco.Notificacao = 0;

                    await _repUnitOfWork.ClienteEndereco.AtualizarAsync(endereco);
                }
            }

            if (enderecos.Where(x => x.TipoEndereco == 1).ToList().Count > 0 && command.TipoEndereco == 1)
            {
                GerarErro("Ja existe um endereco de contrato cadastrado.");
            }

            command.CodigoEndereco = await _repUnitOfWork.ClienteEndereco.BuscarUltimoCodigoAsync(ClienteEnderecoExpression.BuscarPorCodigoEndereco(), ClienteEnderecoExpression.BuscarPorCodigoCliente(command.CodigoCliente)) + 1;

            await _repUnitOfWork.ClienteEndereco.AdicionarAsync(_clienteEnderecoFactory.Adicionar(command));
        }

        public async Task Atualizar(ClienteEnderecoCommand command)
        {
            _clienteValidator.ValidarEdicao(command);

            ICollection<ClienteEnderecoEntity> enderecos = await _repUnitOfWork.ClienteEndereco.BuscarTodosAsync(ClienteEnderecoExpression.BuscarPorCodigoCliente(command.CodigoCliente));

            ClienteEnderecoEntity endereco = await _repUnitOfWork.ClienteEndereco.BuscarPrimeiroAsync(ClienteEnderecoExpression.BuscarPorEndereco(command.CodigoCliente, command.CodigoEndereco));

            if (enderecos.Where(x => x.Notificacao == 1).ToList().Count == 0)
            {
                command.Notificacao = 1;
            }
            else if (command.Notificacao == 1)
            {
                command.Notificacao = 1;

                var enderecosComNotificacao = enderecos.Where(x => x.Notificacao == 1).ToList();

                foreach (var enderecoNotificacao in enderecosComNotificacao)
                {
                    enderecoNotificacao.Notificacao = 0;

                    await _repUnitOfWork.ClienteEndereco.AtualizarAsync(enderecoNotificacao);
                }
            }

            if (enderecos.Where(x => x.TipoEndereco == 1).ToList().Count > 0 && command.TipoEndereco == 1)
            {
                GerarErro("Ja existe um endereco de contrato cadastrado.");
            }

            if (endereco.TipoEndereco == 1 && command.TipoEndereco != 1)
            {
                GerarErro("Não é possivel desvincular o endereço de contrato! Em caso de dúvida, contate a TI.");
            }

            await _repUnitOfWork.ClienteEndereco.AtualizarAsync(_clienteEnderecoFactory.Atualizar(command));
        }

        public async Task Deletar(ClienteEnderecoCommand command)
        {
            _clienteValidator.ValidarExclusao(command);

            ICollection<ClienteEnderecoEntity> enderecos = await _repUnitOfWork.ClienteEndereco.BuscarTodosAsync(ClienteEnderecoExpression.BuscarPorCodigoCliente(command.CodigoCliente));

            ClienteEnderecoEntity endereco = await _repUnitOfWork.ClienteEndereco.BuscarPrimeiroAsync(ClienteEnderecoExpression.BuscarPorEndereco(command.CodigoCliente, command.CodigoEndereco));
            
            if (enderecos.ToList().Count == 1)
            {
                GerarErro("Não é possivel excluir o endereço se ele for o ultimo");
            }

            if (endereco.Notificacao == 1)
            {
                GerarErro("Não é possivel excluir um endereço de notificação");
            }

            if (endereco.TipoEndereco == 1)
            {
                GerarErro("Não é possivel excluir um endereço de contrato");
            }

            await _repUnitOfWork.ClienteEndereco.DeletarAsync(endereco);
        }

        public async Task<ICollection<ClienteEnderecoEntity>> BuscarTodos()
        {
            return await _repUnitOfWork.ClienteEndereco.BuscarTodosAsync();
        }

        public async Task<ClienteEnderecoEntity> BuscarPorEndereco(decimal codigoCliente, decimal codigoEndereco)
        {
            return await _repUnitOfWork.ClienteEndereco.BuscarPrimeiroAsync(ClienteEnderecoExpression.BuscarPorEndereco(codigoCliente, codigoEndereco));
        }

        public async Task<ClienteEnderecoEntity> BuscarPorUltimoEndereco(decimal codigoCliente)
        {
            var ultimoCodigo = await _repUnitOfWork.ClienteEndereco.BuscarUltimoCodigoAsync(ClienteEnderecoExpression.BuscarPorCodigoEndereco(), ClienteEnderecoExpression.BuscarPorCodigoCliente(codigoCliente));

            return await _repUnitOfWork.ClienteEndereco.BuscarPrimeiroAsync(ClienteEnderecoExpression.BuscarPorEndereco(codigoCliente, ultimoCodigo));
        }
    }
}
