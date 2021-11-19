using Microsoft.EntityFrameworkCore;
using ServicoBanco.Domain.Entities;
using ServicoBanco.Repository.EntityConfigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicoBanco.Repository.Contexts
{
    public class BaseContext : DbContext
    {
        public virtual DbSet<ClienteEntity> Cliente { get; set; }
        public virtual DbSet<LicencaEntity> Licenca { get; set; }
        public virtual DbSet<TelefoneClienteEntity> TelefoneCliente { get; set; }

        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteConfig());
            modelBuilder.ApplyConfiguration(new LicencaConfig());
            modelBuilder.ApplyConfiguration(new TelefoneClienteConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
