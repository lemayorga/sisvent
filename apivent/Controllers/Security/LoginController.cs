using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using apivent.Application.DTOs.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using apivent.Services;
using apivent.Application.Interfaces.Securiry;

namespace apivent.Controllers.Security
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly ISecurityService servicesSecurity;
        private readonly ISecurityTokenService servicesToken;

        public LoginController(IConfiguration configuration, ISecurityService servicesSecurity, ISecurityTokenService servicesToken)
        {
            this.configuration = configuration;
            this.servicesSecurity = servicesSecurity;
            this.servicesToken = servicesToken;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UsuarioLogin usuarioLogin)
        {
            UsuarioInfo userInfo = await Task.FromResult(servicesSecurity.Autentication(usuarioLogin.Usuario, usuarioLogin.Password));
            if (userInfo != null)
                return Ok(new { userName = usuarioLogin.Usuario ,token = this.servicesToken.GenerarTokenJWT(this.configuration,userInfo) });

            return Unauthorized();
        }
    }
}