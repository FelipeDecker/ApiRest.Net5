using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicoBanco.Web.Middlewares.Teste
{
    public class MiddlewareOwin
    {
        public Task OwinHello(IDictionary<string, object> environment)
        {
            string responseText = "Hello World via OWIN";
            byte[] responseBytes = Encoding.UTF8.GetBytes(responseText);

            // OWIN Environment Keys: https://owin.org/spec/spec/owin-1.0.0.html
            var responseStream = (Stream)environment["owin.ResponseBody"];
            var responseHeaders = (IDictionary<string, string[]>)environment["owin.ResponseHeaders"];

            responseHeaders["Content-Length"] = new string[] { responseBytes.Length.ToString(CultureInfo.InvariantCulture) };
            responseHeaders["Content-Type"] = new string[] { "text/plain" };

            return responseStream.WriteAsync(responseBytes, 0, responseBytes.Length);
        }
    }
}
