using API.Models.Dtos;
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

        public FilmeController(FilmeContext context) {
            _context = context;
        }
    
        [HttpPost]
        public IActionResult Adicionar([FromBody]CreateFilmeDto filmeDto) {
            Filme filme = new Filme
            {
                Titulo = filmeDto.Titulo,
                Diretor = filmeDto.Diretor,
                Duracao = filmeDto.Duracao,
                Genero = filmeDto.Genero,
            };

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
                ReadFilmeDto filmeDto = new ReadFilmeDto
                {
                    Id = filme.Id,
                    Titulo = filme.Titulo,
                    Diretor = filme.Diretor,
                    Genero = filme.Genero,
                    Duracao = filme.Duracao,
                    HrRequisicao = DateTime.Now

                };

               return Ok(filmeDto);
            }
            return NotFound();
        }


        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, UpdateFilmeDto filmeDto) {
            Filme filme = _context.Filmes.Where<Filme>(f => f.Id == id).FirstOrDefault();
            if (filme != null)
            {
                filme.Titulo = filmeDto.Titulo;
                filme.Diretor = filmeDto.Diretor;
                filme.Genero = filmeDto.Genero;
                filme.Duracao = filmeDto.Duracao;

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
