using System;

namespace ServicoBanco.Domain.Entities
{
    public class LicencaEntity
    {
        public Guid Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataValidade { get; set; }
        public string Descricao { get; set; }

        public LicencaEntity()
        {
            Id = Guid.NewGuid();
            DataCriacao = DateTime.Now;
            DataValidade = DateTime.Parse("2099/01/01");
            Descricao = "Servico Banco API";
        }

        public LicencaEntity(DateTime dataValidade, string descricao)
        {
            Id = Guid.NewGuid();
            DataCriacao = DateTime.Now;
            DataValidade = dataValidade;
            Descricao = descricao;
        }
    }
}
