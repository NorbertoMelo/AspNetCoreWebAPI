using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WEBAPI.Data;
using SmartSchool.WEBAPI.Models;

namespace SmartSchool.WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly SmartContext _context;

        public ProfessorController(SmartContext context) 
        {
            _context = context;
        }
        
        // GET: api/<ProfessorController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Professores);
        }

        // GET api/<ProfessorController>/1
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var professor = _context.Professores.FirstOrDefault(p => p.Id == id);
            if (professor == null) return BadRequest("O professor não foi encontrado");
            return Ok(professor);
        }

        // GET api/<ProfessorController>/Alexandre
        [HttpGet("{nome}")]
        public IActionResult GetByName(string nome)
        {
            var professor = _context.Professores.FirstOrDefault(p => p.Nome.Contains(nome));
            if (professor == null) return BadRequest("O professor não foi encontrado");
            return Ok(professor);
        }

        // POST api/<ProfessorController>
        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _context.Add(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        // PUT api/<ProfessorController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var prof = _context.Professores.AsNoTracking().FirstOrDefault(p => p.Id == id);
            if (prof == null) return BadRequest("O professor não foi encontrado");
            
            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }        
        
        // PATCH api/<ProfessorController>/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var prof = _context.Professores.AsNoTracking().FirstOrDefault(p => p.Id == id);
            if (prof == null) return BadRequest("O professor não foi encontrado");
            
            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        // DELETE api/<ProfessorController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var prof = _context.Professores.AsNoTracking().FirstOrDefault(p => p.Id == id);
            if (prof == null) return BadRequest("O professor não foi encontrado");
            
            _context.Remove(prof);
            _context.SaveChanges();
            return Ok("Exclusão efetuada com sucesso");
        }    
    }
}
