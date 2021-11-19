using System;
using System.Reflection;

namespace ServicoBanco.Domain.Commands
{
    public class ClienteEnderecoCommand : CommandBase
    {
        public decimal CodigoCliente { get; set; }
        public decimal CodigoEndereco { get; set; }
        public decimal TipoEndereco { get; set; }
        public decimal Notificacao { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string CaixaPostal { get; set; }
        public string Bairro { get; set; }
        public decimal Cep { get; set; }
        public decimal CodigoCidade { get; set; }
        public string NomeCidade { get; set; }
        public string CodigoEstado { get; set; }
        public string Contratada { get; set; }
        public decimal Inativo { get; set; }
        public string CodigoCriacao { get; set; }
        public DateTime DataCriacao { get; set; }
        public string CodigoAlteracao { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
