using Microsoft.AspNetCore.Mvc;
using SmartSchool.WEBAPI.Models;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSchool.WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        public List<Aluno> Alunos = new List<Aluno>() {
            new Aluno(){
                Id = 1,
                Nome = "Marcos",
                SobreNome = "Almeida",
                Telefone = "1234567"
            },new Aluno(){
                Id = 2,
                Nome = "Marta",
                SobreNome = "Kent",
                Telefone = "2345678"
            },new Aluno(){
                Id = 3,
                Nome = "Laura",
                SobreNome = "Maria",
                Telefone = "3456789"
            }
        };
        public AlunoController() { }

        // GET: api/<AlunoController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Alunos);
        }

        // GET api/<AlunoController>/5
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("O aluno não foi encontrado");
            return Ok(aluno);
        }        
        
        // GET api/<AlunoController>/Marta
        [HttpGet("{nome}")]
        public IActionResult GetByName(string nome)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Nome.Contains(nome));
            if (aluno == null) return BadRequest("O aluno não foi encontrado");
            return Ok(aluno);
        }

        // POST api/<AlunoController>
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            return Ok(aluno);
        }

        // PUT api/<AlunoController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            return Ok(aluno);
        }        
        
        // PATCH api/<AlunoController>/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            return Ok(aluno);
        }

        // DELETE api/<AlunoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
