using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
// using https://www.devmedia.com.br/trabalhando-com-o-projeto-owin/32848

namespace ServicoBanco.Web.Middlewares
{
    public class Teste3Middleware
    {
        private readonly Func<IDictionary<string, object>, Task> _next;

        public Teste3Middleware(Func<IDictionary<string, object>, Task> next)
        {
            _next = next;
        }

        public async Task Invoke(IDictionary<string, object> dict)
        {
            using (var sw = new StreamWriter((Stream)dict["owin.ResponseBody"]))
            {
                await sw.WriteAsync("DevMedia usando a Definicao <br>");
            }

            await _next.Invoke(dict);
        }
    }
}
