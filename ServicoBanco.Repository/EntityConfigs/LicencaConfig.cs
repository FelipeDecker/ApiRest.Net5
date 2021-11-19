using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServicoBanco.Domain.Entities;

namespace ServicoBanco.Repository.EntityConfigs
{
    public class LicencaConfig : IEntityTypeConfiguration<LicencaEntity>
    {
        public void Configure(EntityTypeBuilder<LicencaEntity> builder)
        {
            builder.ToTable("LicencaSchulzeApi");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("id_licenca");
            builder.Property(x => x.DataCriacao).HasColumnName("dt_criacao");
            builder.Property(x => x.DataValidade).HasColumnName("dt_validade");
            builder.Property(x => x.Descricao).HasColumnName("de_licenca");
        }
    }
}
