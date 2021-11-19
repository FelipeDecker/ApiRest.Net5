using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ServicoBanco.DomainService.IServices;
using System;
using System.Threading.Tasks;

namespace ServicoBanco.Web.Controllers
{
    [ApiController]
    [Authorize]
    public abstract class GenericController : ControllerBase
    {
        protected readonly IAutenticationService _svcAutentication;

        public GenericController(IAutenticationService svcAutentication)
        {
            _svcAutentication = svcAutentication;
        }

        protected async Task Autenticar()
        {
            await _svcAutentication.Autenticar(Request.Headers["DataBase"].ToString());
        }
        protected JsonResult RetornarSucesso()
        {
            return new JsonResult(new { Sucesso = 1 });
        }

        protected JsonResult RetornarErro(Exception ex)
        {
            return new JsonResult(ex);
        }
    }
}
