using Microsoft.AspNetCore.Mvc;
using SmartSchool.WEBAPI.Data;
using SmartSchool.WEBAPI.Models;

namespace SmartSchool.WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IRepository _repo;

        public ProfessorController(IRepository repo) 
        {
            _repo = repo;
        }
        
        // GET: api/<ProfessorController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repo.GetAllProfessores(true));
        }

        // GET api/<ProfessorController>/1
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var professor = _repo.GetProfessorById(id);
            if (professor == null) return BadRequest("O professor não foi encontrado");
            return Ok(professor);
        }

        // GET api/<ProfessorController>/Alexandre
        [HttpGet("{nome}")]
        public IActionResult GetByName(string nome)
        {
            var professor = _repo.GetProfessorByName(nome);
            if (professor == null) return BadRequest("O professor não foi encontrado");
            return Ok(professor);
        }

        
        // GET api/<ProfessorController>/ByDisciplina/1
        [HttpGet("ByDisciplina/{id}")]
        public IActionResult GetByDisciplina(int id)
        {
            var professores = _repo.GetAllProfessoresByDisciplinaId(id);
            if (professores == null) return BadRequest("Não há professores relacionados nesta disciplina");
            return Ok(professores);
        }

        // POST api/<ProfessorController>
        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _repo.Add(professor);
            if (_repo.SaveChanges())
            {
                return Ok(professor);
            }
            return BadRequest("Professor não cadastrado");
        }

        // PUT api/<ProfessorController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var prof = _repo.GetProfessorById(id);
            if (prof == null) return BadRequest("O professor não foi encontrado");
            
            _repo.Update(professor);
            if (_repo.SaveChanges())
            {
                return Ok(professor);
            }
            return BadRequest("Professor não Atualizado");
        }        
        
        // PATCH api/<ProfessorController>/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var prof = _repo.GetProfessorById(id);
            if (prof == null) return BadRequest("O professor não foi encontrado");
            
            _repo.Update(professor);
            if (_repo.SaveChanges())
            {
                return Ok(professor);
            }
            return BadRequest("Professor não Atualizado");
        }

        // DELETE api/<ProfessorController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var prof = _repo.GetProfessorById(id);
            if (prof == null) return BadRequest("O professor não foi encontrado");
            
            _repo.Delete(prof);
            if (_repo.SaveChanges())
            {
                return Ok("Professor Deletado com sucesso");
            }
            return BadRequest("Professor não Deletado");
        }    
    }
}
