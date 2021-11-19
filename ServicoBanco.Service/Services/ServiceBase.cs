using ServicoBanco.DomainService.Helpers;
using ServicoBanco.DomainService.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicoBanco.Service.Services
{
    public class ServiceBase
    {
        public ApiException Exception { get; set; }

        public ServiceBase()
        {
            Exception = new ApiException("Service");
        }

        public void GerarErro(string erro)
        {
            Exception.GerarErro(erro);
        }

        public void GerarErro(List<string> erros)
        {
            Exception.GerarErro(erros);
        }
    }
}
