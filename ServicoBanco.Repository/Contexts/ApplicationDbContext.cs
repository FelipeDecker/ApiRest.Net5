using Microsoft.EntityFrameworkCore;
using ServicoBanco.Domain.Entities;
using ServicoBanco.Repository.EntityConfigs;

namespace ServicoBanco.Repository.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
            //, string connectionString
            //Database.SetConnectionString(connectionString);

        }

        public virtual DbSet<ClienteEntity> Cliente { get; set; }
        public virtual DbSet<ClienteEnderecoEntity> ClienteEndereco { get; set; }
        public virtual DbSet<LicencaEntity> Licenca { get; set; }
        public virtual DbSet<TelefoneClienteEntity> TelefoneCliente { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //if (Database.IsSqlServer)
            //{
            //    Coloca a config para sql aqui
            //}

            modelBuilder.ApplyConfiguration(new ClienteConfig());
            modelBuilder.ApplyConfiguration(new ClienteEnderecoConfig());
            modelBuilder.ApplyConfiguration(new LicencaConfig());
            modelBuilder.ApplyConfiguration(new TelefoneClienteConfig());

            base.OnModelCreating(modelBuilder);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("minha connection string");
        //}

        public static ApplicationDbContext Create(string banco)
        {
            var stringConexao = "";

            if (banco == "producao")
            {
                stringConexao = "x";
            }
            else if (banco == "teste")
            {
                stringConexao = "x";

            }

            return new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        }
    }
}
