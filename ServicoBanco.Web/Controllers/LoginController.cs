using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServicoBanco.Domain.Commands;
using ServicoBanco.DomainService.IServices;
using System;
using System.Threading.Tasks;

namespace ServicoBanco.Web.Controllers
{
    public class LoginController : GenericController
    {
        private readonly ILoginService _svcLogin;
        public LoginController(IAutenticationService svcAutentication, ILoginService svcLogin)
            : base(svcAutentication)
        {
            _svcLogin = svcLogin;
        }

        #region Gerar

        [HttpPost]
        [Route("Login/Token")]
        [AllowAnonymous]
        public async Task<JsonResult> GerarToken([FromBody] LoginCommand body)
        {
            return new JsonResult(await _svcLogin.GerarToken(body));
        }

        #endregion
    }
}
