using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WEBAPI.Data;
using SmartSchool.WEBAPI.Dtos;
using SmartSchool.WEBAPI.Models;

namespace SmartSchool.WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        public ProfessorController(IRepository repo, IMapper mapper) 
        {
            _repo = repo;
            _mapper = mapper;
        }
        
        // GET: api/<ProfessorController>
        [HttpGet]
        public IActionResult Get()
        {
            var professores = _repo.GetAllProfessores(false);

            return Ok(_mapper.Map<IEnumerable<ProfessorDto>>(professores));
        }

        // GET api/<ProfessorController>/1
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var professor = _repo.GetProfessorById(id);
            if (professor == null) return BadRequest("O professor não foi encontrado");

            var professorDto = _mapper.Map<ProfessorDto>(professor);
            return Ok(professorDto);
        }

        // GET api/<ProfessorController>/NewRegister
        [HttpGet("getRegister")]
        public IActionResult GetRegister()
        {
            return Ok(new ProfessorRegistrarDto());
        }

        // GET api/<ProfessorController>/Alexandre
        [HttpGet("{nome}")]
        public IActionResult GetByName(string nome)
        {
            var professor = _repo.GetProfessorByName(nome);
            if (professor == null) return BadRequest("O professor não foi encontrado");

            var professorDto = _mapper.Map<ProfessorDto>(professor);
            return Ok(professorDto);
        }

        
        // GET api/<ProfessorController>/ByDisciplina/1
        [HttpGet("ByDisciplina/{id}")]
        public IActionResult GetByDisciplina(int id)
        {
            var professores = _repo.GetAllProfessoresByDisciplinaId(id,true);
            if (professores == null) return BadRequest("Não há professores relacionados nesta disciplina");

            var professoresDto = _mapper.Map<IEnumerable<ProfessorDto>>(professores);
            return Ok(professoresDto);
        }

        // POST api/<ProfessorController>
        [HttpPost]
        public IActionResult Post(ProfessorRegistrarDto model)
        {
            var professor = _mapper.Map<Professor>(model);

            _repo.Add(professor);
            if (_repo.SaveChanges())
            {
                return Created($"/api/professor/{model.Id}",_mapper.Map<ProfessorDto>(professor));
            }
            return BadRequest("Professor não cadastrado");
        }

        // PUT api/<ProfessorController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, ProfessorRegistrarDto model)
        {
            var professor = _repo.GetProfessorById(id);
            if (professor == null) return BadRequest("O professor não foi encontrado");

            _mapper.Map(model, professor);

            _repo.Update(professor);
            if (_repo.SaveChanges())
            {
                return Created($"/api/professor/{model.Id}",_mapper.Map<ProfessorDto>(professor));
            }
            return BadRequest("Professor não Atualizado");
        }        
        
        // PATCH api/<ProfessorController>/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, ProfessorRegistrarDto model)
        {
            var professor = _repo.GetProfessorById(id);
            if (professor == null) return BadRequest("O professor não foi encontrado");
            
            _mapper.Map(model,professor);

            _repo.Update(professor);
            if (_repo.SaveChanges())
            {
                return Created($"/api/professor/{model.Id}",_mapper.Map<ProfessorDto>(professor));
            }
            return BadRequest("Professor não Atualizado");
        }

        // DELETE api/<ProfessorController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = _repo.GetProfessorById(id);
            if (professor == null) return BadRequest("O professor não foi encontrado");
            
            _repo.Delete(professor);
            if (_repo.SaveChanges())
            {
                return Ok("Professor Deletado com sucesso");
            }
            return BadRequest("Professor não Deletado");
        }    
    }
}
