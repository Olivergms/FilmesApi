using FluentResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Requests;
using UsuariosApi.Services;

namespace UsuariosApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public ActionResult logaUsuario(LoginRequest request)
        {
            Result resultado = _loginService.LogaUsuario(request);

            if (resultado.IsFailed) return StatusCode(StatusCodes.Status401Unauthorized);
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
