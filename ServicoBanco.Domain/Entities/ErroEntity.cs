using System;
using System.Collections.Generic;

namespace ServicoBanco.Domain.Entities
{
    public class ErroEntity
    {
        public string TraceId { get; set; }
        public string Erro { get; set; }
        public List<string> ListaErros { get; set; }
        public string Solucao { get; set; }
        public string MensagemUsuario { get; set; }
        public string InnerException { get; set; }
        public string StackTrace { get; set; }
        public DateTime Data { get; set; }

        // experimental
        public string Ambiente { get; set; }
        public int Gravidade { get; set; } // irde 1 - 5, dependendo de cada nivel, registra log ou ate mesmo contata alguem da empresa

        public ErroEntity(string traceId, string erro, List<string> listaErros, string solucao, 
            string mensagemUsuario ,string innerException, string stackTrace)
        {
            TraceId = traceId;
            Erro = erro;
            ListaErros = listaErros;
            Solucao = solucao;
            MensagemUsuario = mensagemUsuario;
            InnerException = innerException;
            StackTrace = stackTrace;
            Data = DateTime.UtcNow;
        }
    }
}
