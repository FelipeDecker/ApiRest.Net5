using System;

namespace ServicoBanco.Domain.Entities
{
    public class TelefoneClienteEntity
    {
        public decimal CodigoCliente { get; set; }
        public decimal CodigoContato { get; set; }
        public string Nome { get; set; }
        public decimal? Telefone { get; set; }
        public string Ramal { get; set; }
        public decimal? Ddd { get; set; }
        public string Email { get; set; }
        public decimal? Cargo { get; set; }
        public decimal? EnvioBv { get; set; }
        public decimal? Inativo { get; set; }
        public decimal? Sms { get; set; }
        public string CodigoCriacao { get; set; }
        public DateTime? DataCriacao { get; set; }
        public string CodigoAlteracao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public decimal? Tipo { get; set; }
        public decimal? TipoTelefone { get; set; }
        public decimal? TelefoneFormatado { get; set; }
        public string ContatoOrigem { get; set; }
        public decimal? TipoEmail { get; set; }

        public TelefoneClienteEntity()
        {
            Nome = "";
            Telefone = 0;
            Ramal = "";
            Ddd = 0;
            Email = "";
            Cargo = 0;
            EnvioBv = 0;
            Inativo = 0;
            Sms = 0;
            CodigoCriacao = "";
            DataCriacao = new DateTime(1900, 01, 01);
            CodigoAlteracao = "";
            DataAlteracao = new DateTime(1900, 01, 01);
            Tipo = 0;
            TipoTelefone = 0;
            TelefoneFormatado = 0;
            ContatoOrigem = "";
            TipoEmail = 0;
        }

        public void Criar(decimal codigoCliente, string nome, decimal? telefone, string ramal, decimal? ddd, 
            string email, decimal? cargo, decimal? envioBv, decimal? sms, string codigoCriacao, 
            decimal? tipo, decimal? tipoTelefone, string contatoOrigem, decimal? tipoEmail)
        {
            CodigoCliente = codigoCliente;
            Nome = nome;
            Telefone = telefone;
            Ramal = ramal;
            Ddd = ddd;
            Email = email;
            Cargo = cargo;
            EnvioBv = envioBv;
            Inativo = 0;
            Sms = sms;
            CodigoCriacao = codigoCriacao;
            DataCriacao = DateTime.Now;
            Tipo = tipo;
            TipoTelefone = tipoTelefone;
            TelefoneFormatado = Convert.ToDecimal(Convert.ToString(ddd) + Convert.ToString(telefone));
            ContatoOrigem = contatoOrigem;
            TipoEmail = tipoEmail;
        }

        public void Atualizar(string codigoAlteracao, DateTime? dataAlteracao)
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
