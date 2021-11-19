using Microsoft.Extensions.DependencyInjection;
using ServicoBanco.DomainService.IRepositories;
using ServicoBanco.DomainService.IServices;
using ServicoBanco.Repository.Repositories;
using ServicoBanco.Service.Services;

namespace ServicoBanco.CrossCutting.DependencyRegisters
{
    public static class DependencyRegister
    {
        public static void RegisterApiServives(this IServiceCollection services)
        {
            #region Observacoes

            //AddTransient - Criado a cada vez que são solicitados
            //AddScoped - Criado uma vez por solicitação
            //AddSingleton - Criado na primeira vez que são executados. Cada 
            //solicitação subsequente usa a instancia que foi criada na
            //primeira vez

            #endregion

            #region Services

            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IAutenticationService, AutenticationService>();
            services.AddScoped<ITelefoneClienteService, TelefoneClienteService>();
            services.AddScoped<IClienteEnderecoService, ClienteEnderecoService>();
            services.AddScoped<ILoginService, LoginService>();

            #endregion

            #region Repositories

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            #endregion
        }
    }
}
