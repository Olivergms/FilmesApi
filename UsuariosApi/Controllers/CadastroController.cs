using FluentResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Data.Requests;
using UsuariosApi.Services;

namespace UsuariosApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        private CadastroService _cadastroService;

        public CadastroController(CadastroService cadastroService)
        {
            _cadastroService = cadastroService;
        }

        [HttpPost]
        public ActionResult CadastrarUsuario(CreateUsuarioDto createDto)
        {
            Result result = _cadastroService.CadastraUsuario(createDto);

            if (result.IsFailed) return StatusCode(StatusCodes.Status500InternalServerError, result.Errors.FirstOrDefault());

            return StatusCode(StatusCodes.Status201Created, result.Successes.FirstOrDefault());
        }

        [HttpGet("/ativa")]
        public ActionResult AtivaContaUsuario([FromQuery]AtivaContaRequest request)
        {
            Result resultado = _cadastroService.AtivaContaUsuario(request);

            if (resultado.IsFailed) return StatusCode(StatusCodes.Status500InternalServerError,
                resultado.Errors.FirstOrDefault());

            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
