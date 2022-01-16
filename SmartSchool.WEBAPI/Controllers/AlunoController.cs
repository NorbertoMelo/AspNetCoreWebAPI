using Microsoft.AspNetCore.Mvc;
using SmartSchool.WEBAPI.Data;
using SmartSchool.WEBAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSchool.WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IRepository _repo;

        public AlunoController(IRepository repo)
        {
            _repo = repo;    
        }

        // GET: api/<AlunoController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repo.GetAllAlunos(true));
        }

        // GET api/<AlunoController>/5
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var aluno = _repo.GetAlunoById(id);
            if (aluno == null) return BadRequest("O aluno não foi encontrado");
            return Ok(aluno);
        }        
        
        // GET api/<AlunoController>/Marta
        [HttpGet("{nome}")]
        public IActionResult GetByName(string nome)
        {
            var aluno = _repo.GetAlunoByName(nome);
            if (aluno == null) return BadRequest("O aluno não foi encontrado");
            return Ok(aluno);
        }        
        
        // GET api/<AlunoController>/ByDisciplina/1
        [HttpGet("ByDisciplina/{id}")]
        public IActionResult GetByDisciplina(int id)
        {
            var alunos = _repo.GetAllAlunosByDisciplinaId(id);
            if (alunos == null) return BadRequest("Não há alunos relacionados nesta disciplina");
            return Ok(alunos);
        }

        // POST api/<AlunoController>
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _repo.Add(aluno);
            if (_repo.SaveChanges())
            {
                return Ok(aluno);
            }
            return BadRequest("Aluno não cadastrado");
        }

        // PUT api/<AlunoController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var alu = _repo.GetAlunoById(id);
            if (alu == null) return BadRequest("O aluno não foi encontrado");

            _repo.Update(aluno);
            if (_repo.SaveChanges())
            {
                return Ok(aluno);
            }
            return BadRequest("Aluno não Atualizado");
        }        
        
        // PATCH api/<AlunoController>/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var alu = _repo.GetAlunoById(id);
            if (alu == null) return BadRequest("O aluno não foi encontrado");

            _repo.Update(aluno);
            if (_repo.SaveChanges())
            {
                return Ok(aluno);
            }
            return BadRequest("Aluno não Atualizado");
        }

        // DELETE api/<AlunoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _repo.GetAlunoById(id);
            if (aluno == null) return BadRequest("O aluno não foi encontrado");

            _repo.Delete(aluno);
            if (_repo.SaveChanges())
            {
                return Ok("Aluno Deletado com sucesso");
            }
            return BadRequest("Aluno não Deletado");
        }
    }
}
