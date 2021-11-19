using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServicoBanco.Domain.Entities;

namespace ServicoBanco.Repository.EntityConfigs
{
    public class ClienteEnderecoConfig : IEntityTypeConfiguration<ClienteEnderecoEntity>
    {
        public void Configure(EntityTypeBuilder<ClienteEnderecoEntity> builder)
        {
            builder.ToTable("ClienteEnderecos");

            builder.HasKey(x => x.CodigoCliente);
            builder.HasKey(x => x.CodigoEndereco);

            builder.Property(x => x.CodigoCliente).HasColumnName("cd_cliente");
            builder.Property(x => x.CodigoEndereco).HasColumnName("cd_seq");
            builder.Property(x => x.TipoEndereco).HasColumnName("tp_endereco");
            builder.Property(x => x.Notificacao).HasColumnName("fl_notificacao");
            builder.Property(x => x.Endereco).HasColumnName("de_endereco");
            builder.Property(x => x.Numero).HasColumnName("nr_endereco");
            builder.Property(x => x.Complemento).HasColumnName("de_complemento");
            builder.Property(x => x.CaixaPostal).HasColumnName("nr_cxpostal");
            builder.Property(x => x.Bairro).HasColumnName("no_bairro");
            builder.Property(x => x.Cep).HasColumnName("nr_cep");
            builder.Property(x => x.CodigoCidade).HasColumnName("cd_cidade");
            builder.Property(x => x.NomeCidade).HasColumnName("no_cidade");
            builder.Property(x => x.CodigoEstado).HasColumnName("cd_estado");
            builder.Property(x => x.Contratada).HasColumnName("de_contratada");
            builder.Property(x => x.Inativo).HasColumnName("fl_inativo");
            builder.Property(x => x.CodigoCriacao).HasColumnName("cd_criacao");
            builder.Property(x => x.DataCriacao).HasColumnName("dt_criacao");
            builder.Property(x => x.CodigoAlteracao).HasColumnName("cd_alteracao");
            builder.Property(x => x.DataAlteracao).HasColumnName("dt_alteracao");
        }
    }
}
