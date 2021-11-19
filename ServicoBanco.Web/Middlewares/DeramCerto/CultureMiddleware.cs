using Microsoft.AspNetCore.Http;
using System.Globalization;
using System.Threading.Tasks;

namespace ServicoBanco.Web.Middlewares
{
    public class CultureMiddleware
    {
        private readonly RequestDelegate _next;

        public CultureMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            //string cultura = context.Request.Query["Culture"];

            string cultura = "pt-BR";

            if (!string.IsNullOrWhiteSpace(cultura))
            {
                CultureInfo cultureInfo = new(cultura);

                CultureInfo.CurrentCulture.ClearCachedData();

                CultureInfo.CurrentCulture = cultureInfo;
            }

            await _next(context);
        }
    }
}
