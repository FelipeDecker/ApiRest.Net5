using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServicoBanco.Domain.Commands;
using ServicoBanco.DomainService.IServices;
using System.Threading.Tasks;

namespace ServicoBanco.Web.Controllers
{
    public class ClienteController : GenericController
    {
        private readonly IClienteService _svcCliente;

        public ClienteController(IClienteService svcCliente, IAutenticationService svcAutentication)
            : base(svcAutentication)
        {
            _svcCliente = svcCliente;
        }

        #region Criar

        [HttpPost]
        [Route("Cliente/Adicionar")]
        //[Authorize(Roles = "gerente,funcionario")] // autenticados e com determinada autorização
        //[Authorize(Roles = "gerente", Policy = "teste")]
        public async Task<JsonResult> AdicionarCliente([FromBody] ClienteCommand body)
        {
            body.TratarValoresRecebidos();

            await _svcCliente.Adicionar(body);

            return new JsonResult(body.TipoPessoa == "F" ? await _svcCliente.BuscarPorCpf(body.Cpf) : await _svcCliente.BuscarPorCnpj(body.Cnpj));
        }

        #endregion

        #region Editar

        [HttpPut]
        [Route("Cliente/Atualizar")]
        public async Task<JsonResult> AtualizarCliente([FromBody] ClienteCommand body)
        {
            body.TratarValoresRecebidos();

            await _svcCliente.Atualizar(body);

            return new JsonResult(await _svcCliente.BuscarPorCodigo(body.CodigoCliente));
        }

        [HttpPut]
        [Route("Cliente/Atualizar/Rh")]
        public async Task<JsonResult> AtualizarRh([FromBody] ClienteCommand body)
        {
            body.TratarValoresRecebidos();

            await _svcCliente.AtualizarRh(body);

            return new JsonResult(await _svcCliente.BuscarPorCodigo(body.CodigoCliente));
        }

        #endregion

        #region Excluir

        [HttpDelete]
        [Route("Cliente/Deletar")]
        public async Task<JsonResult> DeletarCliente([FromBody] ClienteCommand body)
        {
            body.TratarValoresRecebidos();

            await _svcCliente.Deletar(body);

            return RetornarSucesso();
        }

        #endregion

        #region Buscar

        [HttpGet]
        [Route("Cliente/Buscar/Todos")]
        public async Task<JsonResult> BuscarTodos()
        {
            return new JsonResult(await _svcCliente.BuscarTodos());
        }

        [HttpGet]
        [Route("Cliente/Buscar/Ativos")]
        public async Task<JsonResult> BuscarPorAtivos()
        {
            return new JsonResult(await _svcCliente.BuscarTodosAtivos());
        }

        [HttpGet]
        [Route("Cliente/Buscar/Nome")]
        public async Task<JsonResult> BuscarPorNome([FromBody] ClienteCommand body)
        {
            return new JsonResult(await _svcCliente.BuscarPorNome(body.Nome));
        }

        [HttpGet]
        [Route("Cliente/Buscar/Nome/{nome}")]
        public async Task<JsonResult> BuscarPorNomeUrl(string nome)
        {
            return new JsonResult(await _svcCliente.BuscarPorNome(nome));
        }

        [HttpGet]
        [Route("Cliente/Buscar/Codigo")]
        public async Task<JsonResult> BuscarPorCodigo([FromBody] ClienteCommand body)
        {
            return new JsonResult(await _svcCliente.BuscarPorCodigo(body.CodigoCliente));
        }

        [HttpGet]
        [Route("Cliente/Buscar/Codigo/{id}")]
        public async Task<JsonResult> BuscarPorCodigoUrl(decimal id)
        {
            return new JsonResult(await _svcCliente.BuscarPorCodigo(id));
        }

        [HttpGet]
        [Route("Cliente/Buscar/Cpf/{cpf}")]
        public async Task<JsonResult> BuscarPorCpfUrl(decimal cpf)
        {
            return new JsonResult(await _svcCliente.BuscarPorCpf(cpf));
        }

        [HttpGet]
        [Route("Cliente/Buscar/Cnpj/{cnpj}")]
        public async Task<JsonResult> BuscarPorCnpjUrl(decimal cnpj)
        {
            return new JsonResult(await _svcCliente.BuscarPorCnpj(cnpj));
        }

        #endregion

    }
}
