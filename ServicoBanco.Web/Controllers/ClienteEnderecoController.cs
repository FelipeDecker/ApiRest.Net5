using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicoBanco.Domain.Commands;
using ServicoBanco.DomainService.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoBanco.Web.Controllers
{
    public class ClienteEnderecoController : GenericController
    {
        private readonly IClienteEnderecoService _svcClienteEndereco;

        public ClienteEnderecoController(IAutenticationService svcAutentication, IClienteEnderecoService svcClienteEndereco)
            : base(svcAutentication)
        {
            _svcClienteEndereco = svcClienteEndereco;
        }

        #region Adicionar

        [HttpPost]
        [Route("ClienteEndereco/Adicionar")]
        public async Task<JsonResult> AdicionarEndereco([FromBody] ClienteEnderecoCommand body)
        {
            await _svcAutentication.Autenticar(Request.Headers["DataBase"].ToString());

            body.TratarValoresRecebidos();

            await _svcClienteEndereco.Adicionar(body);

            return new JsonResult(await _svcClienteEndereco.BuscarPorUltimoEndereco(body.CodigoCliente));
        }

        #endregion

        #region Atualizar

        [HttpPut]
        [Route("ClienteEndereco/Atualizar")]
        public async Task<JsonResult> AtualizarEndereco([FromBody] ClienteEnderecoCommand body)
        {
            await _svcAutentication.Autenticar(Request.Headers["DataBase"].ToString());

            body.TratarValoresRecebidos();

            await _svcClienteEndereco.Atualizar(body);

            return new JsonResult(await _svcClienteEndereco.BuscarPorEndereco(body.CodigoCliente, body.CodigoEndereco));
        }

        #endregion

        #region Deletar

        [HttpDelete]
        [Route("ClienteEndereco/Deletar")]
        public async Task<JsonResult> DeletarEndereco([FromBody] ClienteEnderecoCommand body)
        {
            await _svcAutentication.Autenticar(Request.Headers["DataBase"].ToString());

            await _svcClienteEndereco.Deletar(body);

            return new JsonResult(1);
        }

        #endregion

        #region Buscar

        [HttpGet]
        [Route("ClienteEndereco/Buscar/Todos")]
        public async Task<JsonResult> BuscarTodos()
        {
            await _svcAutentication.Autenticar(Request.Headers["DataBase"].ToString());

            return new JsonResult(await _svcClienteEndereco.BuscarTodos());
        }

        [HttpGet]
        [Route("ClienteEndereco/Buscar/Endereco")]
        public async Task<JsonResult> BuscarPorEndereco([FromBody] ClienteEnderecoCommand body)
        {
            await _svcAutentication.Autenticar(Request.Headers["DataBase"].ToString());

            return new JsonResult(await _svcClienteEndereco.BuscarPorEndereco(body.CodigoCliente, body.CodigoEndereco));
        }

        #endregion
    }
}
