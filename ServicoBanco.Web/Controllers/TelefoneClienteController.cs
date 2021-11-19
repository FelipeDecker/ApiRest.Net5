using Microsoft.AspNetCore.Mvc;
using ServicoBanco.Domain.Commands;
using ServicoBanco.DomainService.IServices;
using System;
using System.Threading.Tasks;

namespace ServicoBanco.Web.Controllers
{
    public class TelefoneClienteController : GenericController
    {
        private readonly ITelefoneClienteService _svcTelefoneCliente;

        public TelefoneClienteController(IAutenticationService svcAutentication, ITelefoneClienteService svcTelefoneCliente) 
            : base(svcAutentication)
        {
            _svcTelefoneCliente = svcTelefoneCliente;
        }

        #region Criar

        [HttpPost]
        [Route("TelefoneCliente/Adicionar")]
        public async Task<JsonResult> AdicionarTelefone([FromBody] TelefoneClienteCommand body)
        {
            await Autenticar();

            body.TratarValoresRecebidos();

            await _svcTelefoneCliente.Adicionar(body);

            return new JsonResult(await _svcTelefoneCliente.BuscarPorUltimoTelefone(body.CodigoCliente));
        }

        #endregion

        #region Editar

        [HttpPut]
        [Route("TelefoneCliente/Atualizar")]
        public async Task<JsonResult> AtualizarTelefone([FromBody] TelefoneClienteCommand body)
        {
            await Autenticar();

            body.TratarValoresRecebidos();

            await _svcTelefoneCliente.Atualizar(body);

            return new JsonResult(await _svcTelefoneCliente.BuscarPorCodigoTelefone(body.CodigoCliente, body.CodigoContato));
        }

        #endregion

        #region Deletar

        [HttpDelete]
        [Route("TelefoneCliente/Deletar")]
        public async Task<JsonResult> DeletarTelefone([FromBody] TelefoneClienteCommand body)
        {
            await Autenticar();

            body.TratarValoresRecebidos();

            await _svcTelefoneCliente.Deletar(body);

            return RetornarSucesso();
        }

        #endregion

        #region Buscar

        [HttpGet]
        [Route("TelefoneCliente/Buscar/Todos")]
        public async Task<JsonResult> BuscarTelefonesPorCliente([FromBody] TelefoneClienteCommand body)
        {
            return new JsonResult(await _svcTelefoneCliente.BuscarTodos(body.CodigoCliente));
        }

        [HttpGet]
        [Route("TelefoneCliente/Buscar/Todos/{codigoCliente}")]
        public async Task<JsonResult> BuscarTelefonesPorClienteUrl(decimal codigoCliente)
        {
            return new JsonResult(await _svcTelefoneCliente.BuscarTodos(codigoCliente));
        }

        [HttpGet]
        [Route("TelefoneCliente/Buscar/CodigoTelefone")]
        public async Task<JsonResult> BuscarPorCodigoTelefone([FromBody] TelefoneClienteCommand body)
        {
            return new JsonResult(await _svcTelefoneCliente.BuscarPorCodigoTelefone(body.CodigoCliente, body.CodigoContato));
        }

        [HttpGet]
        [Route("TelefoneCliente/Buscar/CodigoTelefone/{CodigoCliente}/{CodigoContato}")]
        public async Task<JsonResult> BuscarPorCodigoTelefoneUrl(decimal codigoCliente, decimal codigoContato)
        {
            return new JsonResult(await _svcTelefoneCliente.BuscarPorCodigoTelefone(codigoCliente, codigoContato));
        }
        
        [HttpGet]
        [Route("TelefoneCliente/Buscar/Telefone/{CodigoCliente}/{Telefone}")]
        public async Task<JsonResult> BuscarPorTelefoneUrl(decimal codigoCliente, decimal telefone)
        {
            return new JsonResult(await _svcTelefoneCliente.BuscarPorTelefone(codigoCliente, telefone));
        }

        [HttpGet]
        [Route("TelefoneCliente/Buscar/Situacao")]
        public async Task<JsonResult> BuscarPorSituacao([FromBody] TelefoneClienteCommand body)
        {
            await Autenticar();

            body.TratarValoresRecebidos();

            return new JsonResult(await _svcTelefoneCliente.BuscarPorSituacao(body.CodigoCliente, body.Inativo));
        }

        [HttpGet]
        [Route("TelefoneCliente/Buscar/Contato")]
        public async Task<JsonResult> BuscarPorTipoContato([FromBody] TelefoneClienteCommand body)
        {
            await Autenticar();

            body.TratarValoresRecebidos();

            return new JsonResult(await _svcTelefoneCliente.BuscarPorTipoContato(body.CodigoCliente, body.Tipo));
        }

        #endregion
    }
}
