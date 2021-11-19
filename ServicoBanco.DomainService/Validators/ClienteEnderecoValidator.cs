using ServicoBanco.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicoBanco.DomainService.Validators
{
    public class ClienteEnderecoValidator : ValidatorBase
    {
        public ClienteEnderecoValidator() : base()
        {

        }

        public void ValidarCadastro(ClienteEnderecoCommand command)
        {
            ValidarCodigoCliente(command);
            ValidarEndereco(command);
            ValidarNumero(command);
            ValidarCep(command);
            ValidarCidade(command);
            ValidarInativo(command);

            TratarErros();
        }

        public void ValidarEdicao(ClienteEnderecoCommand command)
        {
            ValidarCodigoCliente(command);
            ValidarCodigoEndereco(command);
            ValidarEndereco(command);
            ValidarNumero(command);
            ValidarCep(command);

            TratarErros();
        }

        public void ValidarExclusao(ClienteEnderecoCommand command)
        {
            ValidarCodigoCliente(command);
            ValidarCodigoEndereco(command);

            TratarErros();
        }

        private void ValidarCodigoCliente(ClienteEnderecoCommand command)
        {
            if (command.CodigoCliente == 0)
            {
                AdicionarErro("-Campo Obrigatorio: CodigoCliente");
            }
        }

        private void ValidarCodigoEndereco(ClienteEnderecoCommand command)
        {
            if (command.CodigoEndereco == 0)
            {
                AdicionarErro("-Campo Obrigatorio: CodigoEndereco");
            }
        }

        private void ValidarEndereco(ClienteEnderecoCommand command)
        {
            if (command.Endereco == "")
            {
                AdicionarErro("-Campo Obrigatorio: Endereco");
            }
        }

        private void ValidarNumero(ClienteEnderecoCommand command)
        {
            if (command.Numero == "")
            {
                AdicionarErro("-Campo Obrigatorio: Numero");
            }
        }

        private void ValidarCep(ClienteEnderecoCommand command)
        {
            if (command.Cep == 0)
            {
                AdicionarErro("-Campo Obrigatorio: Cep");
            }
            else
            {
                if (command.Cep < 8)
                {
                    AdicionarErro("-Cep deve ter 8 digitos");
                }
            }
        }

        private void ValidarCidade(ClienteEnderecoCommand command)
        {
            if (command.NomeCidade == "")
            {
                AdicionarErro("-Campo Obrigatorio: NomeCidade");
            }
        }

        private void ValidarInativo(ClienteEnderecoCommand command)
        {
            if (command.Inativo == 1)
            {
                AdicionarErro("Não é possivel cadastrar um endereço como inativo");
            }
        }
    }
}
