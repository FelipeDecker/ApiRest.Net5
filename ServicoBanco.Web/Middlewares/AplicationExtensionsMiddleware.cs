using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ServicoBanco.DomainService.Helpers;
using ServicoBanco.Web.Middlewares.DeramCerto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicoBanco.Web.Middlewares
{
    public static class AplicationExtensionsMiddleware
    {
        // Tipos de Middleware

        // Definir o Culture Info
        // Cache
        // Autenticação
        // Autorização

        // 2 - Segundo
        public static void UseDataBaseMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<DataBaseMiddleware>();
        }

        // 3 - Terceiro
        public static void UseCultureMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<CultureMiddleware>();
        }

        // 1 - Primeiro
        public static void UseExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }

        #region Services


        #endregion


        public static void ConfigureApiAuthenticationJwtBearer(this IServiceCollection service)
        {
            service.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                //x.ForwardForbid
                //x.ForwardSignIn
                //x.ForwardSignOut = ""; 

                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Helper.SegredinhoApi())),
                    // esses dois servem para quando for distribuir a aplicação
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }
    }
}
