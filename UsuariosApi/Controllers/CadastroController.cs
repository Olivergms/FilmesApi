using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Dtos;

namespace UsuariosApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        public ActionResult CadastrarUsuario(CreateUsuarioDto createDto)
        {
            return Ok();
        }
    }
}
