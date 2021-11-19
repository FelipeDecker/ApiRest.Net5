using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using ServicoBanco.Repository.Contexts;
using ServicoBanco.CrossCutting.DependencyRegisters;
using ServicoBanco.Web.Middlewares;
using System;

//[assembly: OwinStartup(typeof(ServicoBanco.Web.Startup))]
namespace ServicoBanco.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddControllers(); // estava antes do dbcontext

            services.ConfigureApiAuthenticationJwtBearer();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy => policy.RequireRole("maneger"));
                options.AddPolicy("Gerente", policy => policy.RequireRole("maneger"));
                options.AddPolicy("Coordenador", policy => policy.RequireRole("maneger"));
                options.AddPolicy("Funcionario", policy => policy.RequireRole("maneger"));
            });

            services.RegisterApiServives();

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DeveloperConnection")));

            services.AddDbContext<DeveloperDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DeveloperConnection")));

            //services.AddDbContext<DeveloperDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DeveloperConnection")));

            //services.AddDbContext<ProductionDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ProductionConnection")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ServicoBanco.Web", Version = "v1" });
            });

            services.AddTransient<IServiceCollection, ServiceCollection>();
        }

        public void Configure(IApplicationBuilder app, IServiceCollection service)
        {
            //service.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ProductionConnection")));

            app.ApplicationServices
                .GetService<IServiceCollection>()
                .AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ProductionConnection")));
                
            //.ConfigureServices(x => x.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ProductionConnection"))));

            if (Environment.IsDevelopment())
            {
                Console.WriteLine("Ambiente de Desenvolvimento - " + Environment.EnvironmentName);

                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ServicoBanco.Web v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseAuthentication();

            app.UseAuthorization();

            //app.UseCookiePolicy();

            //app.UseOwin();

            app.UseCultureMiddleware();

            app.UseExceptionMiddleware();

            app.UseDataBaseMiddleware();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
