using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServicoBanco.Domain.Entities;

namespace ServicoBanco.Repository.EntityConfigs
{
    public class TelefoneClienteConfig : IEntityTypeConfiguration<TelefoneClienteEntity>
    {
        public void Configure(EntityTypeBuilder<TelefoneClienteEntity> builder)
        {
            builder.ToTable("TelefoneCliente");

            builder.HasKey(x => x.CodigoCliente);
            builder.HasKey(x => x.CodigoContato);

            builder.Property(x => x.CodigoCliente).HasColumnName("cd_cliente");
            builder.Property(x => x.CodigoContato).HasColumnName("cd_contato");
            builder.Property(x => x.Nome).HasColumnName("no_contato");
            builder.Property(x => x.Telefone).HasColumnName("nr_telefone");
            builder.Property(x => x.Ramal).HasColumnName("nr_ramal");
            builder.Property(x => x.Ddd).HasColumnName("nr_ddd");
            builder.Property(x => x.Email).HasColumnName("de_email");
            builder.Property(x => x.Cargo).HasColumnName("cd_cargo");
            builder.Property(x => x.EnvioBv).HasColumnName("fl_envio_bv");
            builder.Property(x => x.Inativo).HasColumnName("fl_inativo");
            builder.Property(x => x.Sms).HasColumnName("fl_sms");
            builder.Property(x => x.CodigoCriacao).HasColumnName("cd_usu_cad");
            builder.Property(x => x.DataCriacao).HasColumnName("dt_usu_cad");
            builder.Property(x => x.CodigoAlteracao).HasColumnName("cd_usu_alt");
            builder.Property(x => x.DataAlteracao).HasColumnName("dt_usu_alt");
            builder.Property(x => x.Tipo).HasColumnName("fl_tipo");
            builder.Property(x => x.TipoTelefone).HasColumnName("cd_tipo");
            builder.Property(x => x.TelefoneFormatado).HasColumnName("nr_telefone_pesquisa");
            builder.Property(x => x.ContatoOrigem).HasColumnName("no_contato_origem");
            builder.Property(x => x.TipoEmail).HasColumnName("cdtipoemail");
        }
    }
}
