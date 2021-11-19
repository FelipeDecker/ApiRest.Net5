using Microsoft.EntityFrameworkCore;
using ServicoBanco.Domain.Entities;
using ServicoBanco.Repository.EntityConfigs;

namespace ServicoBanco.Repository.Contexts
{
    public class DeveloperDbContext : DbContext
    {
        public DeveloperDbContext(DbContextOptions<DeveloperDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public virtual DbSet<ClienteEntity> Cliente { get; set; }
        public virtual DbSet<LicencaEntity> Licenca { get; set; }
        public virtual DbSet<TelefoneClienteEntity> TelefoneCliente { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteConfig());
            modelBuilder.ApplyConfiguration(new LicencaConfig());
            modelBuilder.ApplyConfiguration(new TelefoneClienteConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
