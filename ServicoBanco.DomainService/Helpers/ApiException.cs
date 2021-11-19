using Newtonsoft.Json;
using ServicoBanco.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicoBanco.DomainService.Helpers
{
    public class ApiException : Exception
    {
        private string Ambiente { get; set; }

        public ApiException()
        {

        }

        public ApiException(string ambiente)
        {
            Ambiente = ambiente;
        }

        public void GerarErro(string ambiente, string erro)
        {
            var objeto = new 
            {
                Ambiente = ambiente,
                Erro = erro
            };

            throw new Exception(JsonConvert.SerializeObject(objeto));
        }

        public void GerarErro(string ambiente, List<string> erros)
        {
            var objeto = new
            {
                Ambiente = ambiente,
                ListaErros = erros
            };

            throw new Exception(JsonConvert.SerializeObject(objeto));
        }

        public void GerarErro(string erro)
        {
            var objeto = new
            {
                Ambiente = Ambiente,
                Erro = erro
            };

            throw new Exception(JsonConvert.SerializeObject(objeto));
        }

        public void GerarErro(List<string> erros)
        {
            var objeto = new
            {
                Ambiente = Ambiente,
                ListaErros = erros
            };

            throw new Exception(JsonConvert.SerializeObject(objeto));
        }
    }
}
