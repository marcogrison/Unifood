using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.Domain.Services;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly AutenticacaoService _autenticacaoService;

        public LoginController(AutenticacaoService autenticacaoService)
        {
            _autenticacaoService = autenticacaoService;
        }

        [HttpPost("realizar-login")]
        public IActionResult RealizarLogin([FromBody] LoginModel model)
        {
            bool usuarioAutenticado = _autenticacaoService.AutenticarUsuario(model.NomeUsuario, model.SenhaHash);

            if (usuarioAutenticado)
                return Ok();
            

            // Caso contrário, retornar um código de status Unauthorized com uma mensagem de erro
            return Unauthorized("Usuário ou senha inválidos");
        }
    }
}
