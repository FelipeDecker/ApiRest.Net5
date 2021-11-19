using ServicoBanco.Domain.Commands;
using ServicoBanco.Domain.Entities;
using ServicoBanco.DomainService.Expressions;
using ServicoBanco.DomainService.Factories;
using ServicoBanco.DomainService.IRepositories;
using ServicoBanco.DomainService.IServices;
using ServicoBanco.DomainService.Validators;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServicoBanco.Service.Services
{
    public class ClienteService : ServiceBase, IClienteService
    {
        private readonly IUnitOfWork _repUnitOfWork;
        private readonly ITelefoneClienteService _svcTelefoneCliente;
        private readonly ClienteValidator _clienteValidator;
        private readonly ClienteFactory _clienteFactory;

        public ClienteService(IUnitOfWork repUnitOfWork, ITelefoneClienteService svcTelefoneCliente)
        {
            _repUnitOfWork = repUnitOfWork;
            _svcTelefoneCliente = svcTelefoneCliente;
            _clienteValidator = new ClienteValidator();
            _clienteFactory = new ClienteFactory();
        }

        public async Task Adicionar(ClienteCommand command)
        {
            _clienteValidator.ValidarCadastro(command);

            if (command.TipoPessoa == "F" && await _repUnitOfWork.Cliente.BuscarPrimeiroAsync(ClienteExpression.BuscarPorCpf(command.Cpf)) != null)
            {
                GerarErro("Cpf ja cadastrado");
            }

            if (command.TipoPessoa == "J" && await _repUnitOfWork.Cliente.BuscarPrimeiroAsync(ClienteExpression.BuscarPorCnpj(command.Cnpj)) != null)
            {
                GerarErro("Cnpj ja cadastrado");
            }

            if (command.Ramal != 0 )
            {
                ClienteEntity ramalCliente = await _repUnitOfWork.Cliente.BuscarPrimeiroAsync(ClienteExpression.BuscarPorRamal(command.Ramal));

                GerarErro("Ramal ja cadastrado");
            }

            command.CodigoCliente = await _repUnitOfWork.Cliente.BuscarUltimoCodigoAsync(ClienteExpression.BuscarPorUltimoCodigoCliente());

            await _repUnitOfWork.Cliente.AdicionarAsync(_clienteFactory.Adicionar(command));
        }

        public async Task Atualizar(ClienteCommand command)
        {
            _clienteValidator.ValidarEdicao(command);

            ClienteEntity cliente = await _repUnitOfWork.Cliente.BuscarPrimeiroAsync(ClienteExpression.BuscarPorCodigoCliente(command.CodigoCliente));

            if (cliente == null)
            {
                GerarErro("Não foi encontrado um cliente com esse codigo");
            }

            await _repUnitOfWork.Cliente.AtualizarAsync(_clienteFactory.Atualizar(command));
        }

        public async Task AtualizarRh(ClienteCommand command)
        {
            _clienteValidator.ValidarEdicao(command);

            ClienteEntity cliente = await _repUnitOfWork.Cliente.BuscarPrimeiroAsync(ClienteExpression.BuscarPorCodigoCliente(command.CodigoCliente));

            if (cliente == null)
            {
                GerarErro("Não foi encontrado um cliente com esse codigo");
            }

            await _repUnitOfWork.Cliente.AtualizarAsync(_clienteFactory.AtualizarRh(command));
        }

        public async Task Deletar(ClienteCommand command)
        {
            _clienteValidator.ValidarExclusao(command);

            ClienteEntity cliente = await _repUnitOfWork.Cliente.BuscarPrimeiroAsync(ClienteExpression.BuscarPorCodigoCliente(command.CodigoCliente));

            if (cliente == null)
            {
                GerarErro("Não foi encontrado um cliente com esse codigo");
            }

            var teste = await _svcTelefoneCliente.BuscarTodos(command.CodigoCliente);
            if (teste.Count > 0)
            {
                GerarErro("Este devedor não pode ser excluído. Existe(m) Telefone(s) para ele.");
            }

            if (command.Usuario != 0)
            {
                await _repUnitOfWork.Cliente.AtualizarAsync(_clienteFactory.Deletar(command));
            }
            else
            {
                await _repUnitOfWork.Cliente.DeletarAsync(cliente);
            }
        }

        public async Task<ICollection<ClienteEntity>> BuscarTodos()
        {
            return await _repUnitOfWork.Cliente.BuscarTodosAsync();
        }

        public async Task<ICollection<ClienteEntity>> BuscarTodosAtivos()
        {
            return await _repUnitOfWork.Cliente.BuscarTodosAsync(ClienteExpression.BuscarPorAtivo());
        }

        public async Task<ICollection<ClienteEntity>> BuscarPorNome(string nome)
        {
            _clienteValidator.ValidarBuscaPorNome(nome);

            return await _repUnitOfWork.Cliente.BuscarTodosAsync(ClienteExpression.BuscarPorNome(nome));
        }

        public async Task<ClienteEntity> BuscarPorCodigo(decimal codigo)
        {
            _clienteValidator.ValidarBuscaPorCodigo(codigo);

            return await _repUnitOfWork.Cliente.BuscarPrimeiroAsync(ClienteExpression.BuscarPorCodigoCliente(codigo));
        }

        public async Task<ClienteEntity> BuscarPorCpf(decimal cpf)
        {
            return await _repUnitOfWork.Cliente.BuscarPrimeiroAsync(ClienteExpression.BuscarPorCpf(cpf));
        }

        public async Task<ClienteEntity> BuscarPorCnpj(decimal cnpj)
        {
            return await _repUnitOfWork.Cliente.BuscarPrimeiroAsync(ClienteExpression.BuscarPorCnpj(cnpj));
        }
    }
}
