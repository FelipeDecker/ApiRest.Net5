using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoBanco.Web.Middlewares.Teste
{
    public class MiddlewareDevMidia
    {
        private readonly Func<IDictionary<string, object>, Task> _next;

        public MiddlewareDevMidia(Func<IDictionary<string, object>, Task> next)
        {
            _next = next;
        }

        public async Task Invoke(IDictionary<string, object> dict)
        {
            // Contexto é um dicionário que contém toda a informação sobre a requisição.
            using (var sw = new StreamWriter((Stream)dict["owin.ResponseBody"]))
            {
                await sw.WriteAsync("DevMedia usando a Definicao <br>");
            }
            await _next.Invoke(dict);
        }
    }
}
