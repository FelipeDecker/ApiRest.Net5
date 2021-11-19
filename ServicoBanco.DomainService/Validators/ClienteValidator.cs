using Newtonsoft.Json;
using ServicoBanco.Domain.Commands;
using ServicoBanco.DomainService.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ServicoBanco.DomainService.Validators
{
    public class ClienteValidator : ValidatorBase
    {
        public ClienteValidator() : base()
        {

        }

        public void ValidarCadastro(ClienteCommand command)
        {
            ValidarTipoPessoa(command.TipoPessoa);
            ValidarNome(command.Nome);
            ValidarTipoAdvogado(command.Advogado, command.TipoAdvogado);
            ValidarCodigoCriacao(command.CodigoCriacao);
            ValidarDataCriacao(command.DataCriacao);
            ValidarFornecedor(command);
            ValidarCpf(command.TipoPessoa, command.Cpf);
            ValidarCnpj(command.TipoPessoa, command.Cnpj);
            ValidarPis(command.Pis);
            ValidarCliente(command);
            ValidarUsuario(command);

            TratarErros();
        }

        public void ValidarEdicao(ClienteCommand command)
        {
            ValidarCodigoCliente(command.CodigoCliente);
            ValidarCpf(command.TipoPessoa, command.Cpf);
            ValidarCnpj(command.TipoPessoa, command.Cnpj);
            ValidarCodigoAlteracao(command.CodigoAlteracao);
            ValidarDataAlteracao(command.DataAlteracao);
            ValidarFornecedor(command);
            ValidarCliente(command);
            ValidarUsuario(command);
            ValidarPis(command.Pis);

            TratarErros();
        }

        public void ValidarExclusao(ClienteCommand command)
        {
            ValidarCodigoCliente(command.CodigoCliente);

            TratarErros();
        }

        public void ValidarBuscaPorCodigo(decimal codigo)
        {
            ValidarCodigoCliente(codigo);

            TratarErros();
        }

        public void ValidarBuscaPorNome(string nome)
        {
            ValidarNome(nome);

            TratarErros();
        }

        private void ValidarCodigoCliente(decimal codigoCliente)
        {
            if (codigoCliente == 0)
            {
                AdicionarErro("Campo Obrigatório: CodigoCliente");
            }
        }

        private void ValidarTipoPessoa(string tipoPessoa)
        {
            if (tipoPessoa != "F" && tipoPessoa != "J")
            {
                AdicionarErro("Campo Obrigatório: TipoPessoa");
            }
        }

        private void ValidarNome(string nome)
        {
            if (nome == null)
            {
                AdicionarErro("Campo Obrigatório: Nome");
            }
        }

        private void ValidarTipoAdvogado(bool? advogado, string tipoAdvogado)
        {
            if (advogado == true)
            {
                switch (tipoAdvogado)
                {
                    case "E":
                        break;
                    case "C":
                        break;
                    case "O":
                        break;
                    case "I":
                        break;
                    default:
                        AdicionarErro("Campo Obrigatório: TipoAdvogado");
                        break;
                }
            }
        }

        private void ValidarCodigoAlteracao(string codigoAlteracao)
        {
            if (codigoAlteracao == "")
            {
                AdicionarErro("Campo Obrigatório: CodigoCriacao");
            }
        }

        private void ValidarDataAlteracao(DateTime? dataAlteracao)
        {
            if (dataAlteracao == new DateTime(1900, 01, 01))
            {
                AdicionarErro("Campo Obrigatório: DataAlteracao");
            }
        }

        private void ValidarCodigoCriacao(string codigoCriacao)
        {
            if (codigoCriacao == "")
            {
                AdicionarErro("Campo Obrigatório: CodigoCriacao");
            }
        }

        private void ValidarDataCriacao(DateTime? dataCriacao)
        {
            if (dataCriacao == new DateTime(1900, 01, 01))
            {
                AdicionarErro("Campo Obrigatório: DataCriacao");
            }
        }

        private void ValidarFornecedor(ClienteCommand command)
        {
            if (command.Fornecedor)
            {
                if (command.Banco == 0)
                {
                    AdicionarErro("Campo Obrigatório: Banco");
                }

                if (command.Agencia == "")
                {
                    AdicionarErro("Campo Obrigatório: Agencia");
                }

                if (command.Conta == "")
                {
                    AdicionarErro("Campo Obrigatório: Conta");
                }

                if (command.DigitoConta == "")
                {
                    AdicionarErro("Campo Obrigatório: DigitoConta");
                }
            }
        }

        private void ValidarCliente(ClienteCommand command)
        {
            if (command.GrupoCliente == 0)
            {
                AdicionarErro("Campo Obrigatório: GrupoCliente");
            }

            if (command.Filial == 0)
            {
                AdicionarErro("Campo Obrigatório: Filial");
            }
        }

        private void ValidarUsuario(ClienteCommand command)
        {
            if (command.Usuario == 1)
            {
                if (command.Filial == 0)
                {
                    AdicionarErro("Campo Obrigatório: Filial");
                }
            }
        }

        private void ValidarCpf(string tipoPessoa, decimal? cpf)
        {
            if (tipoPessoa == "F")
            {
                // função para remover caracteres nao numericos do cpf
                // var apenasDigitos = new Regex(@"[^\d]").Replace(cpf.ToString(), "");

                if (cpf.ToString().Length < 11)
                {
                    if (cpf == 0)
                    {
                        AdicionarErro("Campo Obrigatório: Cpf");
                    }
                    else
                    {
                        AdicionarErro("Cpf deve ter 11 digitos");
                    }
                }
                else
                {
                    if (!Helper.ValidarCpf(cpf.ToString()))
                    {
                        AdicionarErro("Cpf invalido");
                    }
                }
            }
        }

        private void ValidarCnpj(string tipoPessoa, decimal? cnpj)
        {
            if (tipoPessoa == "J")
            {
                // função para remover caracteres nao numericos do cpf
                // var apenasDigitos = new Regex(@"[^\d]").Replace(cpf.ToString(), "");

                if (cnpj.ToString().Length < 14)
                {
                    if (cnpj == 0)
                    {
                        AdicionarErro("Campo Obrigatório: Cnpj");
                    }
                    else
                    {
                        AdicionarErro("Cnpj deve ter 14 digitos");
                    }
                }
                else
                {
                    if (!Helper.ValidarCnpj(cnpj.ToString()))
                    {
                        AdicionarErro("Cnpj invalido");
                    }
                }
            }
        }

        private void ValidarPis(decimal? pis)
        {
            if (pis != 0)
            {
                if (pis.ToString().Length < 11)
                {
                    AdicionarErro("Pis deve ter 11 digitos");
                }
                else
                {
                    if (!Helper.ValidarPis(pis.ToString()))
                    {
                        AdicionarErro("Pis invalido");
                    }
                }
            }
        }
    }
}
