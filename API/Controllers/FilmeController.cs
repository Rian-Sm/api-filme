using API.Models.Dtos;
using AutoMapper;
using FilmeAPI.Data;
using FilmeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace FilmeAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public FilmeController(FilmeContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }
    
        [HttpPost]
        public IActionResult Adicionar([FromBody]CreateFilmeDto filmeDto) {
            Filme filme = _mapper.Map<Filme>(filmeDto);

           _context.Filmes.Add(filme);
           _context.SaveChanges();

            return CreatedAtAction(nameof(BuscaPorId), new { Id = filme.Id }, filme);
        }

        [HttpGet]
        public IActionResult Buscar() {
            List<Filme> filmes = _context.Filmes.ToList();

            return Ok(filmes);
        }
        [HttpGet("{id}")]
        public IActionResult BuscaPorId(int id) {
            Filme filme = _context.Filmes.FirstOrDefault(f => f.Id == id);

            if (filme != null)
            {
                ReadFilmeDto filmeDto = _mapper.Map<ReadFilmeDto>(filme);

               return Ok(filmeDto);
            }
            return NotFound();
        }


        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, UpdateFilmeDto filmeDto) {
            Filme filme = _context.Filmes.Where<Filme>(f => f.Id == id).FirstOrDefault();
            if (filme != null)
            {
                _mapper.Map(filmeDto, filme);

                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Atualizar(int id)
        {
            Filme filme = _context.Filmes.Where<Filme>(f => f.Id == id).FirstOrDefault(); // query com a funçao de busca do EF
            if (filme != null)
            {
                _context.Remove(filme);
                _context.SaveChanges();
                return NoContent();
            }

            return NotFound();

        }
    }
}
