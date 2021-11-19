using Microsoft.AspNetCore.Http;
using ServicoBanco.Repository.Contexts;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ServicoBanco.Web.Middlewares.DeramCerto
{
    public class DataBaseMiddleware
    {
        private readonly RequestDelegate _next;

        public DataBaseMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var banco = httpContext.Request.Headers["DataBase"];

            //ApplicationDbContext.Create(banco);

            await _next(httpContext);
        }
    }
}
