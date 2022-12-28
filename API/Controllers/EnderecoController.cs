using API.Models;
using API.Models.Dtos.Endereco;
using AutoMapper;
using FilmeAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {

        private FilmeContext _context;
        private IMapper _mapper;

        public EnderecoController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // GET: EnderecoController
        [HttpGet]
        public IActionResult Buscar()
        {
            List<Endereco> enderecos = _context.Enderecos.ToList();

            return Ok(enderecos);
        }

        // GET: EnderecoController/5
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(e => e.Id == id);
            if (endereco == null)
                return NotFound();
            ReadEnderecoDto enderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);

            return Ok(enderecoDto);
        }
        // POST: EnderecoController
        [HttpPost]
        public ActionResult Adicionar([FromBody] CreateEnderecoDto enderecoDto)
        {
            Endereco endereco = _mapper.Map<Endereco>(enderecoDto);

            _context.Enderecos.Add(endereco);
            _context.SaveChanges();


            return Ok(enderecoDto);
        }
        // POST: EnderecoController/Edit/5
        [HttpPut("{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Atualizar(int id, UpdateEnderecoDto enderecoDto)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault<Endereco>(e => e.Id == id);
            if (endereco == null)
                return NotFound();

            _mapper.Map(enderecoDto, endereco);

            _context.SaveChanges();

            return NoContent();
        }

        // GET: EnderecoController/Delete/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault<Endereco>(e => e.Id == id);
            if (endereco == null)
                return NotFound();

            _context.Enderecos.Remove(endereco);
            _context.SaveChanges();

            return Ok();
        }
    }
}
