using Newtonsoft.Json;
using ServicoBanco.DomainService.Helpers;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ServicoBanco.DomainService.Validators
{
    public class ValidatorBase
    {
        protected List<string> Erros { get; set; }
        private ApiException Exception { get; set; }

        public ValidatorBase()
        {
            Erros = new List<string>();
            Exception = new ApiException("Validator");
        }

        protected void TratarErros()
        {
            if (Erros.Count > 1)
            {
                Exception.GerarErro(Erros);
            }
        }

        protected void AdicionarErro(string erro)
        {
            Erros.Add(erro);
        }
    }
}
