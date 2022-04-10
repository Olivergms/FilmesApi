using FluentResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
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

            if (resultado.IsFailed) return StatusCode(StatusCodes.Status401Unauthorized, resultado.Errors.FirstOrDefault());
            return StatusCode(StatusCodes.Status200OK, resultado.Successes.FirstOrDefault());
        }

        [HttpPost("/solicita-reset")]
        public ActionResult SolicitaResetSenhaUsuario(SolicitaResetRequest request)
        {
            Result resultado = _loginService.SolicitaResetSenhaUsuario(request);

            if (resultado.IsFailed) return StatusCode(StatusCodes.Status401Unauthorized,
                resultado.Errors.FirstOrDefault());

            return StatusCode(StatusCodes.Status200OK, resultado.Successes.FirstOrDefault());
        }

        [HttpPost("/efetua-reset")]
        public ActionResult ResetaSenhaUsuario(EfetuaResetRequest request)
        {
            Result resultado = _loginService.ResetaSenhaUsuario(request);

            if (resultado.IsFailed) return StatusCode(StatusCodes.Status401Unauthorized,
                resultado.Errors.FirstOrDefault());

            return StatusCode(StatusCodes.Status200OK, resultado.Successes.FirstOrDefault());
        }
    }
}
