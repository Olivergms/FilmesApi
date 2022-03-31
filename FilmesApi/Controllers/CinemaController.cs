using FilmesApi.Services;
using FilmesAPI.Data.Dtos;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private CinemaService _cinemaService;
        public CinemaController(CinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        [HttpPost]
        public ActionResult AdicionaCinema([FromBody] CreateCinemaDto cinemaDto)
        {
            ReadCinemaDto readDto = _cinemaService.AdicionaCinema(cinemaDto);

            return CreatedAtAction(nameof(RecuperaCinemasPorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        public ActionResult<List<ReadCinemaDto>> RecuperaCinemas([FromQuery] string nomeDoFilme)
        {
            List<ReadCinemaDto> readDto = _cinemaService.RecuperaCinemas(nomeDoFilme);

            if (readDto != null) return Ok(readDto);

            return NotFound();

        }

        [HttpGet("{id}")]
        public ActionResult<ReadCinemaDto> RecuperaCinemasPorId(int id)
        {
            ReadCinemaDto readDto = _cinemaService.RecuperaCinemasPorId(id);

            if (readDto != null) Ok(readDto);

            return NotFound();
        }

        [HttpPut("{id}")]
        public ActionResult AtualizaCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
        {
            Result result = _cinemaService.AtualizaCinema(id, cinemaDto);

            if (result.IsFailed) return NotFound();
            return Ok();
        }


        [HttpDelete("{id}")]
        public ActionResult DeletaCinema(int id)
        {
            Result result = _cinemaService.DeletaCinema(id);
            if (result.IsFailed) return NotFound();
            return Ok();
        }

    }
}
