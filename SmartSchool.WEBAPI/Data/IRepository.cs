using System.Collections.Generic;
using System.Threading.Tasks;
using SmartSchool.WEBAPI.Helpers;
using SmartSchool.WEBAPI.Models;

namespace SmartSchool.WEBAPI.Data
{
    public interface IRepository
    {
         void Add<T>(T entity) where T: class;
         void Update<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         bool SaveChanges();

         Task<PageList<Aluno>> GetAllAlunosAsync(PageParams pageParams,bool includeProfessor = false);
         Aluno[] GetAllAlunos(bool includeProfessor = false);
         Aluno[] GetAllAlunosByDisciplinaId(int DisciplinaId, bool includeProfessor = false);
         Aluno GetAlunoById(int alunoId);
         Aluno GetAlunoByName(string nome);

         Professor[] GetAllProfessores(bool includeAlunos = false);
         Professor[] GetAllProfessoresByDisciplinaId(int disciplinaId, bool includeAlunos = false);
         Professor GetProfessorById(int professorId);
         Professor GetProfessorByName(string nome);
    }
}