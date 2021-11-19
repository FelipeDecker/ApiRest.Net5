using ServicoBanco.Domain.Commands;
using System;
using System.Text;

namespace ServicoBanco.DomainService.Validators
{
    public class TelefoneClienteValidator : ValidatorBase
    {
        public TelefoneClienteValidator() : base()
        {

        }

        public void ValidarCadastro(TelefoneClienteCommand telefoneCliente)
        {
            ValidarCodigoCliente(telefoneCliente.CodigoCliente);
            ValidarNome(telefoneCliente.Nome);
            ValidarTelefone(telefoneCliente.Telefone);
            ValidarTipoTelefone(telefoneCliente.TipoTelefone);
            ValidarDdd(telefoneCliente.Ddd);

            TratarErros();
        }

        public void ValidarEdicao(TelefoneClienteCommand telefoneCliente)
        {
            ValidarCodigoCliente(telefoneCliente.CodigoCliente);
            ValidarCodigoContato(telefoneCliente.CodigoContato);
            ValidarNome(telefoneCliente.Nome);
            ValidarTelefone(telefoneCliente.Telefone);
            ValidarTipoTelefone(telefoneCliente.TipoTelefone);
            ValidarDdd(telefoneCliente.Ddd);

            TratarErros();
        }

        public void ValidarExclusao(TelefoneClienteCommand telefoneCliente)
        {
            ValidarCodigoCliente(telefoneCliente.CodigoCliente);
            ValidarCodigoContato(telefoneCliente.CodigoContato);

            TratarErros();
        }

        private void ValidarCodigoCliente(decimal codigoCliente)
        {
            if (codigoCliente == 0)
            {
                AdicionarErro("-Campo Obrigatorio: CodigoCliente");
            }
        }

        private void ValidarCodigoContato(decimal codigoContato)
        {
            if (codigoContato == 0)
            {
                AdicionarErro("-Campo Obrigatorio: CodigoContato");
            }
        }

        private void ValidarNome(string nome)
        {
            if (nome == "")
            {
                AdicionarErro("-Campo Obrigatorio: Nome");
            }
        }

        private void ValidarTelefone(decimal telefone)
        {
            if (telefone == 0)
            {
                AdicionarErro("-Campo Telefone deve conter entre 8 e 9 digitos");
            }
        }

        private void ValidarTipoTelefone(decimal tipoTelefone)
        {
            if (tipoTelefone < 3)
            {
                AdicionarErro("-Tipo de telefone invalido: selecionar 3 ou mais");
            }
        }

        private void ValidarDdd(decimal ddd)
        {
            if (ddd < 2)
            {
                AdicionarErro("-Campo Obrigatorio: Ddd");
            }
        }
    }
}
