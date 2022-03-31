using FilmesApi.Data.Dtos.Gerente;
using FilmesApi.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {
        private GerenteService _gerenteService;

        public GerenteController(GerenteService gerenteService)
        {
            _gerenteService = gerenteService;
        }

        [HttpPost]
        public ActionResult AdicionaGerente(CreateGerenteDto dto)
        {
            ReadGerenteDto readDto = _gerenteService.AdicionaGerente(dto);
            return CreatedAtAction(nameof(RecuperaGerentesPorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet("{id}")]
        public ActionResult<ReadGerenteDto> RecuperaGerentesPorId(int id)
        {
            ReadGerenteDto readDto = _gerenteService.RecuperaGerentePorId(id);
            if (readDto != null) Ok(readDto);
            return NotFound();
        }

        [HttpDelete("{id}")]
        public ActionResult DeletaGerente(int id)
        {
            Result result = _gerenteService.DeletaGerente(id);

            if (result.IsFailed) return NotFound();
            return Ok();
        }
    }
}
