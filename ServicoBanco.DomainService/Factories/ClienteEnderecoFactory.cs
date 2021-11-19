using ServicoBanco.Domain.Commands;
using ServicoBanco.Domain.Entities;
using ServicoBanco.DomainService.Patterns;
using System;

namespace ServicoBanco.DomainService.Factories
{
    public class ClienteEnderecoFactory : IGenericFactory<ClienteEnderecoEntity, ClienteEnderecoCommand>
    {
        public ClienteEnderecoEntity Entidade { get; set; }

        public ClienteEnderecoFactory()
        {
            Entidade = new ClienteEnderecoEntity();
        }

        public ClienteEnderecoEntity Adicionar(ClienteEnderecoCommand command)
        {
            Entidade.CodigoEndereco = command.CodigoEndereco;

            Entidade.Criar(command.CodigoCliente, command.TipoEndereco, command.Notificacao, command.Endereco, command.Numero,
                command.Complemento, command.CaixaPostal, command.Bairro, command.Cep, command.CodigoCidade, command.NomeCidade,
                command.CodigoEstado, command.Contratada, command.CodigoCriacao, command.DataCriacao);

            return Entidade;
        }

        public ClienteEnderecoEntity Atualizar(ClienteEnderecoCommand command)
        {
            Entidade.CodigoEndereco = command.CodigoEndereco;

            Entidade.Criar(command.CodigoCliente, command.TipoEndereco, command.Notificacao, command.Endereco, command.Numero,
                command.Complemento, command.CaixaPostal, command.Bairro, command.Cep, command.CodigoCidade, command.NomeCidade,
                command.CodigoEstado, command.Contratada, command.CodigoCriacao, command.DataCriacao);

            Entidade.Alterar(command.CodigoAlteracao, command.DataAlteracao);

            if (command.Inativo == 1) Entidade.Inativar();

            return Entidade;
        }

        public ClienteEnderecoEntity Deletar(ClienteEnderecoCommand command)
        {
            throw new NotImplementedException("Metodo deletar da Factory não esta implementado");
        }
    }
}
