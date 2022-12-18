using FilmeAPI.Data;
using FilmeAPI.Models;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Adicionar([FromBody]Filme filme) {
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
            Filme filme = _context.Filmes.Where<Filme>(f => f.Id == id).FirstOrDefault();

            if (filme != null)
            {
               return Ok(filme);
            }

            return NotFound();
        }


        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Filme filmeAtualizado) {
            Filme filme = _context.Filmes.Where<Filme>(f => f.Id == id).FirstOrDefault();
            if (filme != null)
            {
                filme.Titulo = filmeAtualizado.Titulo;
                filme.Diretor = filmeAtualizado.Diretor;
                filme.Genero = filmeAtualizado.Genero;
                filme.Duracao = filmeAtualizado.Duracao;


                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Atualizar(int id)
        {
            Filme filme = _context.Filmes.Where<Filme>(f => f.Id == id).FirstOrDefault();
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
