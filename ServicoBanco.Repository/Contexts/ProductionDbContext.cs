using Microsoft.EntityFrameworkCore;

namespace ServicoBanco.Repository.Contexts
{
    public class ProductionDbContext : ApplicationDbContext
    {
        public ProductionDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
