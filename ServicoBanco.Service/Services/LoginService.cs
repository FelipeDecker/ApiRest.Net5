using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ServicoBanco.Domain.Commands;
using ServicoBanco.Domain.Entities;
using ServicoBanco.DomainService.Helpers;
using ServicoBanco.DomainService.IServices;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ServicoBanco.Service.Services
{
    public class LoginService : ServiceBase, ILoginService
    {
        private readonly IClienteService _svcCliente;

        public LoginService(IClienteService svcCliente)
        {
            _svcCliente = svcCliente;
        }

        public async Task<object> GerarToken(LoginCommand command)
        {
            ClienteEntity cliente = await _svcCliente.BuscarPorCodigo(command.Login);

            var senha = Helper.EncriptarSenha(command.Senha);

            if (cliente == null || cliente.Senha != senha)
            {
                GerarErro("Usuário ou senha inválidos");
            }

            string token = GerarToken(cliente);

            cliente.Senha = "";

            // retornar Role ou policy da pessoa

            CultureInfo.CurrentCulture.ClearCachedData();
            TimeZoneInfo.ClearCachedData();
            CultureInfo.CurrentCulture = new CultureInfo("pt-BR");

            return new 
            { 
                cliente.CodigoCliente, 
                TipoToken = "bearer",
                Token = token,
                Expira = DateTime.Now.AddHours(1),
            };
        }

        private static string GerarToken(ClienteEntity cliente)
        {
            var claims = new List<Claim>();
            var dt1 = DateTime.Now.AddHours(1);

            claims.Add(new Claim("username", cliente.Nome));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, cliente.Nome));

            var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
            var claimPrincipal = new ClaimsPrincipal();

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Helper.SegredinhoApi());

            // Iformações do token

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    //Esse é o parametro do data anotation de autentication

                    //Role > Claim > Policy

                    // Implementar aqui nas clain a verificação que era feita na Função Autenticar
                    // onde era validado na tabela licencaShulzeApi se possuia o "token" para essa aplicação

                    //new Claim(ClaimTypes.Name, cliente.Nome.ToString()),
                    new Claim(ClaimTypes.PrimarySid, cliente.CodigoCliente.ToString()), // ClienteEntity.Identity.Nome
                    new Claim(ClaimTypes.Name, cliente.Nome), // ClienteEntity.Identity.Nome
                    new Claim(ClaimTypes.Role, cliente.TipoUsuario.ToString()), // ClienteEntity.isInRole
                    new Claim("advogado", cliente.Advogado.ToString()) 
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                //Recebe chave e tipo de encliptação 
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
