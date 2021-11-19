using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicoBanco.Repository.Contexts
{
    public class TestDbContext : WebApplicationFactory<ApplicationDbContext>
    {
        // WebApplicationFactory c#
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Create a new service provider.
                var serviceProvider = new ServiceCollection().AddEntityFrameworkSqlServer();
                    //.AddEntityFrameworkInMemoryDatabase()
                    //.BuildServiceProvider();

                // Add a database context (ApplicationDbContext) using an in-memory 
                // database for testing.
                services.AddDbContext<ApplicationDbContext>(options =>
                {
                    //IMemoryCache cache;
                    //options.UseMemoryCache(cache);
                    //options.UseInMemoryDatabase("InMemoryDbForTesting");
                    //options.UseInternalServiceProvider(builder.UseDefaultServiceProvider);
                });

            });
        }
    }
}
