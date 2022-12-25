using API.Models;
using API.Models.Dtos.Cinema;
using API.Models.Dtos.Filme;
using AutoMapper;
using FilmeAPI.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public CinemaController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody] CreateCinemaDto cinemaDto)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDto);

            _context.Cinemas.Add(cinema);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Adicionar), new { Id = cinema.Id }, cinemaDto);
        }

        [HttpGet]
        public IActionResult Buscar()
        {
            List<Cinema> cinemas = _context.Cinemas.ToList();
            
            return Ok(cinemas);
        }
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema != null)
            {
                ReadCinemaDto cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);

                return Ok(cinemaDto);
            }
            return NotFound();   
        }
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody] UpdateCinemaDto cinemaDto ) {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);

            if(cinema != null)
            {
                _mapper.Map(cinemaDto, cinema);
                _context.SaveChanges();

                return NoContent();
            }
            return NotFound();
        }

    }
}
