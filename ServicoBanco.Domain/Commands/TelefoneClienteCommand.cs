using System;

namespace ServicoBanco.Domain.Commands
{
    public class TelefoneClienteCommand : CommandBase
    {
        public decimal CodigoCliente { get; set; }
        public decimal CodigoContato { get; set; }
        public string Nome { get; set; }
        public decimal Telefone { get; set; }
        public string Ramal { get; set; }
        public decimal Ddd { get; set; }
        public string Email { get; set; }
        public decimal Cargo { get; set; }
        public decimal EnvioBv { get; set; }
        public decimal Inativo { get; set; }
        public decimal Sms { get; set; }
        public string CodigoCriacao { get; set; }
        public DateTime DataCriacao { get; set; }
        public string CodigoAlteracao { get; set; }
        public DateTime DataAlteracao { get; set; }
        public decimal Tipo { get; set; }
        public decimal TipoTelefone { get; set; }
        public decimal TelefoneFormatado { get; set; }
        public string ContatoOrigem { get; set; }
        public decimal TipoEmail { get; set; }
    }
}
