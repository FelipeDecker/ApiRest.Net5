using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicoBanco.Domain.Entities
{
    public class ClienteEnderecoEntity
    {
        public decimal CodigoCliente { get; set; }
        public decimal CodigoEndereco { get; set; }
        public decimal? TipoEndereco { get; set; }
        public decimal? Notificacao { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string CaixaPostal { get; set; }
        public string Bairro { get; set; }
        public decimal? Cep { get; set; }
        public decimal? CodigoCidade { get; set; }
        public string NomeCidade { get; set; }
        public string CodigoEstado { get; set; }
        public string Contratada { get; set; }
        public decimal? Inativo { get; set; }
        public string CodigoCriacao { get; set; }
        public DateTime? DataCriacao { get; set; }
        public string CodigoAlteracao { get; set; }
        public DateTime? DataAlteracao { get; set; }

        public ClienteEnderecoEntity()
        {
            TipoEndereco = 0;
            Notificacao = 0;
            Endereco = "";
            Numero = "";
            Complemento = "0";
            CaixaPostal = "";
            Bairro = "";
            Cep = 0;
            CodigoCidade = 0;
            NomeCidade = "";
            CodigoEstado = "";
            Contratada = "";
            Inativo = 0;
            CodigoCriacao = "";
            DataCriacao = new DateTime(1900, 01, 01);
            CodigoAlteracao = "";
            DataAlteracao = new DateTime(1900, 01, 01);
        }

        public void Criar(decimal codigoCliente, decimal? tipoEndereco, decimal? notificacao, string endereco, 
            string numero, string complemento, string caixaPostal, string bairro, decimal? cep, decimal? codigoCidade, 
            string nomeCidade, string codigoEstado, string contratada, string codigoCriacao, DateTime? dataCriacao)
        {
            CodigoCliente = codigoCliente;
            TipoEndereco = tipoEndereco;
            Notificacao = notificacao;
            Endereco = endereco;
            Numero = numero;
            Complemento = complemento;
            CaixaPostal = caixaPostal;
            Bairro = bairro;
            Cep = cep;
            CodigoCidade = codigoCidade;
            NomeCidade = nomeCidade;
            CodigoEstado = codigoEstado;
            Contratada = contratada;
            CodigoCriacao = codigoCriacao;
            DataCriacao = dataCriacao;
        }

        public void Alterar(string codigoAlteracao, DateTime? dataAlteracao)
        {
            CodigoAlteracao = codigoAlteracao;
            DataAlteracao = dataAlteracao;
        }

        public void Inativar()
        {
            Inativo = 1;
        }
    }
}
