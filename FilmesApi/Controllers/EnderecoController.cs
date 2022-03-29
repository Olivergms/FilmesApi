using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Models;
using FilmesApi.Services;
using FilmesAPI.Data.Dtos;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private EnderecoService _enderecoService;

        public EnderecoController(EnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpPost]
        public ActionResult AdicionaEndereco([FromBody] CreateEnderecoDto enderecoDto)
        {
            ReadEnderecoDto readDto = _enderecoService.AdicionaEndereco(enderecoDto);
            return CreatedAtAction(nameof(RecuperaEnderecosPorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        public ActionResult<IEnumerable<ReadEnderecoDto>> RecuperaEnderecos()
        {
            IEnumerable<ReadEnderecoDto> readDtos = _enderecoService.RecuperaEnderecos();
            if (readDtos != null) return Ok(readDtos);
            return NotFound();
        }

        [HttpGet("{id}")]
        public ActionResult<ReadEnderecoDto> RecuperaEnderecosPorId(int id)
        {
            ReadEnderecoDto readDto = _enderecoService.RecuperaEnderecosPorId(id);

            if (readDto != null) return Ok(readDto);
            return NotFound();
        }

        [HttpPut("{id}")]
        public ActionResult AtualizaEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto)
        {
            Result result = _enderecoService.AtualizaEndereco(id, enderecoDto);

            if (result.IsFailed) return NotFound();
            return Ok();
        }


        [HttpDelete("{id}")]
        public ActionResult DeletaEndereco(int id)
        {
            Result result = _enderecoService.DeletaEndereco(id);

            if (result.IsFailed) return NotFound();
            return Ok();
        }

    }
}