using FilmeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FilmeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        public static int currentId = 1;
        public static List<Filme> filmes = new List<Filme>();

        [HttpPost]
        public IActionResult Adicionar([FromBody]Filme filme) {
            filme.Id = currentId++;
            filmes.Add(filme);

            return CreatedAtAction(nameof(BuscaPorId), new { Id = filme.Id }, filme);
        }
        [HttpGet]
        public IActionResult Buscar() {
            return Ok(filmes);
        }
        [HttpGet("{id}")]
        public IActionResult BuscaPorId(int id) {
            Filme filme = filmes.FirstOrDefault(filmes => filmes.Id == id);

            if(filme != null)
            {
               return Ok(filme);
            }

            return NotFound();
        }
    }
}
