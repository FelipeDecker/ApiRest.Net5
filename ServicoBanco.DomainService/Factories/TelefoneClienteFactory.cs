using ServicoBanco.Domain.Commands;
using ServicoBanco.Domain.Entities;
using ServicoBanco.DomainService.Patterns;
using System;

namespace ServicoBanco.DomainService.Factories
{
    public class TelefoneClienteFactory : IGenericFactory<TelefoneClienteEntity, TelefoneClienteCommand>
    {
        public TelefoneClienteEntity Entidade { get; set; }

        public TelefoneClienteFactory()
        {
            Entidade = new TelefoneClienteEntity();
        }

        public TelefoneClienteEntity Adicionar(TelefoneClienteCommand command)
        {
            Entidade.CodigoContato = command.CodigoContato;

            Entidade.Criar(command.CodigoCliente, command.Nome, command.Telefone, command.Ramal, command.Ddd,
                command.Email, command.Cargo, command.EnvioBv, command.Sms, command.CodigoCriacao,
                command.Tipo, command.TipoTelefone, command.ContatoOrigem, command.TipoEmail);

            return Entidade;
        }

        public TelefoneClienteEntity Atualizar(TelefoneClienteCommand command)
        {
            Entidade.CodigoContato = command.CodigoContato;

            Entidade.Criar(command.CodigoCliente, command.Nome, command.Telefone, command.Ramal, command.Ddd,
                command.Email, command.Cargo, command.EnvioBv, command.Sms, command.CodigoCriacao,
                command.Tipo, command.TipoTelefone, command.ContatoOrigem, command.TipoEmail);

            Entidade.Atualizar(command.CodigoAlteracao, command.DataAlteracao);

            if (command.Inativo == 1) Entidade.Inativar();

            return Entidade;
        }

        public TelefoneClienteEntity Deletar(TelefoneClienteCommand command)
        {
            throw new NotImplementedException("Metodo Deletar da Factory não esta implementado");
        }
    }
}
