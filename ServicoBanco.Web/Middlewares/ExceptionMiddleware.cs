using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ServicoBanco.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoBanco.Web.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);

                // se bater aqui é pq o retorno esta ok
                //então pega tudo o que veio e bota dentro de um objeto de resposta positiva

                //var objeto = new 
                //{
                //    Status = "OK",
                //    Response = context.Response.Body
                //};
                //string result = JsonConvert.SerializeObject(objeto);

                //await context.Response.WriteAsync(result);
            }
            catch (Exception ex)
            {
                await TratarErros(context, ex);
            }
        }

        private static async Task TratarErros(HttpContext context, Exception ex)
        {
            string traceId = Activity.Current?.Id ?? context?.TraceIdentifier;
            string erro = ex.Message;
            List<string> listaErros = new();
            string innerException = ex?.InnerException?.Message;
            string solucao = "";
            string mensagemUsuario = "";

            try
            {
                #region Banco de Dados

                if (ex.InnerException != null)
                {
                    if (ex.InnerException.ToString().Contains("Violation of PRIMARY KEY"))
                    {
                        context.Response.StatusCode = 500;
                        erro = "Chave primaria esta repetida";
                        solucao = "O Id/Codigo da classe que esta sendo criada, precisa ser definido e incrementado em + 1";
                    }

                    if (ex.InnerException.ToString().Contains("Arithmetic overflow error converting numeric to data type numeric."))
                    {
                        context.Response.StatusCode = 500;
                        erro = "Um ou mais campos podem estar recebendo um valor maior que o limite (erro para campos numericos)";
                        solucao = "Verificar qual o tamanho maximo que os campos devem ter";
                    }

                    if (ex.InnerException.ToString().Contains("String or binary data would be truncated."))
                    {
                        context.Response.StatusCode = 500;
                        erro = "Um ou mais campos podem estar recebendo um valor maior que o limite (erro para campos string)";
                        solucao = "Verificar qual o tamanho maximo que os campos devem ter";
                    }
                }

                if (ex.Message.Contains("Format of the initialization string does not conform to specification starting at index 0"))
                {
                    context.Response.StatusCode = 400;
                    erro = "A string de conexão não esta corretamente definida";
                    solucao = "Verificar qual contexto esta sendo utilizado e verificar a escrita da string de conexão";
                }

                #endregion

                #region Dependecy Register

                if (ex.Message.Contains("Unable to resolve service for type")
                    && ex.Message.Contains("while attempting to activate")
                    && ex.Message.Contains("Service")
                    && ex.Message.Contains("Controller")
                    && ex.Source.Contains("Microsoft.Extensions.DependencyInjection.Abstractions"))
                {
                    context.Response.StatusCode = 500;
                    var Interface = ex.Message.Split("'")[1].Split(".").Last();
                    erro = "Algum metodo que utiliza injeção de dependencia não esta sendo assinado";
                    solucao = "No Projeto de CrossCutting Inserir a Interface do Servico: " + Interface + " com a Implementação do servico: " + Interface[1..];
                }

                #endregion

                #region Services

                if (ex.Message.Contains("Ambiente") && ex.Message.Contains("Service"))
                {
                    var objeto = JsonConvert.DeserializeObject<ErroEntity>(ex.Message);

                    erro = "Alguns dados fornecidos podem estar incorretos";
                    mensagemUsuario = objeto.Erro;
                }

                #endregion

                #region Validators

                if (ex.Message.Contains("Ambiente") && ex.Message.Contains("Validator"))
                {
                    erro = "A requisição não passou nas validações";
                    listaErros = new List<string>();
                    mensagemUsuario = "Um ou mais campos estão indevidamente preenchidos";
                    solucao = "Preencha os campos ";
                }

                #endregion
            }
            catch
            {
                context.Response.StatusCode = 500;
                erro = "Erro no tratamento de erro";
                solucao = "Alguma tratativa no tratamento do erro esta feita sendo feita de maneira incorreta, revisar o codigo";
                mensagemUsuario = "Contate a equipe de desenvolvimento";
            }
            finally
            {
                ErroEntity erroEntity = new(traceId, erro, listaErros, solucao, mensagemUsuario, innerException, ex.StackTrace);

                string result = JsonConvert.SerializeObject(erroEntity);

                await context.Response.WriteAsync(result);
            }
        }
    }
}
