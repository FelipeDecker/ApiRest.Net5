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
    public class TelefoneClienteService : ServiceBase, ITelefoneClienteService
    {
        private readonly IUnitOfWork _repUnitOfWork;
        private readonly TelefoneClienteValidator _telefonePessoaValidator;
        private readonly TelefoneClienteFactory _telefonePessoaFactory;

        public TelefoneClienteService(IUnitOfWork repUnitOfWork)
        {
            _repUnitOfWork = repUnitOfWork;
            _telefonePessoaValidator = new TelefoneClienteValidator();
            _telefonePessoaFactory = new TelefoneClienteFactory();
        }

        public async Task Adicionar(TelefoneClienteCommand command)
        {
            _telefonePessoaValidator.ValidarCadastro(command);

            if (await BuscarPorTelefone(command.CodigoCliente, command.Telefone) != null)
            {
                GerarErro("Telefone ja cadastrado");
            }

            if (await BuscarPorEmail(command.CodigoCliente, command.Email) != null)
            {
                GerarErro("Email ja cadastrado");
            }

            command.CodigoContato = await _repUnitOfWork.TelefoneCliente.BuscarUltimoCodigoAsync(TelefoneClienteExpression.BuscarPorCodigoTelefone(), TelefoneClienteExpression.BuscarPorCodigoCliente(command.CodigoCliente)) + 1;

            await _repUnitOfWork.TelefoneCliente.AdicionarAsync(_telefonePessoaFactory.Adicionar(command));
        }

        public async Task Atualizar(TelefoneClienteCommand command)
        {
            _telefonePessoaValidator.ValidarEdicao(command);

            TelefoneClienteEntity telefoneCliente = await _repUnitOfWork.TelefoneCliente.BuscarPrimeiroAsync(TelefoneClienteExpression.BuscarPorCodigoTelefone(command.CodigoCliente, command.CodigoContato));

            if (telefoneCliente == null)
            {
                GerarErro("Telefone não encontrado");
            }

            await _repUnitOfWork.TelefoneCliente.AtualizarAsync(_telefonePessoaFactory.Atualizar(command));
        }

        public async Task Deletar(TelefoneClienteCommand command)
        {
            _telefonePessoaValidator.ValidarExclusao(command);

            TelefoneClienteEntity contatoCliente = await _repUnitOfWork.TelefoneCliente.BuscarPrimeiroAsync(TelefoneClienteExpression.BuscarPorCodigoTelefone(command.CodigoCliente, command.CodigoContato));

            if (contatoCliente == null)
            {
                GerarErro("Não foi encontrado o telefone");
            }

            await _repUnitOfWork.TelefoneCliente.DeletarAsync(contatoCliente);
        }
        
        public async Task<ICollection<TelefoneClienteEntity>> BuscarPorSituacao(decimal codigoCliente, decimal ativo)
        {
            return await _repUnitOfWork.TelefoneCliente.BuscarTodosAsync(TelefoneClienteExpression.BuscarPorAtivo(codigoCliente, ativo != 1));
        }

        public async Task<ICollection<TelefoneClienteEntity>> BuscarPorTipoContato(decimal codigoCliente, decimal tipo)
        {
            return await _repUnitOfWork.TelefoneCliente.BuscarTodosAsync(TelefoneClienteExpression.BuscarPorTipo(codigoCliente, tipo));
        }

        public async Task<ICollection<TelefoneClienteEntity>> BuscarTodos(decimal codigoCliente)
        {
            return await _repUnitOfWork.TelefoneCliente.BuscarTodosAsync(TelefoneClienteExpression.BuscarPorCodigoCliente(codigoCliente));
        }

        public async Task<TelefoneClienteEntity> BuscarPorCodigoTelefone(decimal codigoCliente, decimal codigoContato)
        {
            return await _repUnitOfWork.TelefoneCliente.BuscarPrimeiroAsync(TelefoneClienteExpression.BuscarPorCodigoTelefone(codigoCliente, codigoContato));
        }

        public async Task<TelefoneClienteEntity> BuscarPorTelefone(decimal codigoCliente, decimal telefone)
        {
            return await _repUnitOfWork.TelefoneCliente.BuscarPrimeiroAsync(TelefoneClienteExpression.BuscarPorTelefone(codigoCliente, telefone));
        }

        public async Task<TelefoneClienteEntity> BuscarPorEmail(decimal codigoCliente, string email)
        {
            return await _repUnitOfWork.TelefoneCliente.BuscarPrimeiroAsync(TelefoneClienteExpression.BuscarPorEmail(codigoCliente, email));
        }

        public async Task<TelefoneClienteEntity> BuscarPorUltimoTelefone(decimal codigoCliente)
        {
            var codigoUltimo = await _repUnitOfWork.TelefoneCliente.BuscarUltimoCodigoAsync(TelefoneClienteExpression.BuscarPorCodigoTelefone(), TelefoneClienteExpression.BuscarPorCodigoCliente(codigoCliente));

            return await _repUnitOfWork.TelefoneCliente.BuscarPrimeiroAsync(TelefoneClienteExpression.BuscarPorCodigoTelefone(codigoCliente, codigoUltimo));
        }
    }
}
