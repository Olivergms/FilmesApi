using FluentResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using UsuariosApi.Data.Dtos;
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

        public ActionResult CadastrarUsuario(CreateUsuarioDto createDto)
        {
            Result result = _cadastroService.CadastraUsuario(createDto);

            if (result.IsFailed) return StatusCode(StatusCodes.Status500InternalServerError, result.Errors.FirstOrDefault());

            return StatusCode(StatusCodes.Status201Created, result.Successes.FirstOrDefault());
        }
    }
}
