using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WEBAPI.Helpers;
using SmartSchool.WEBAPI.Models;

namespace SmartSchool.WEBAPI.Data
{
    public class Repository : IRepository
    {
        private readonly SmartContext _context;

        public Repository(SmartContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        async Task<PageList<Aluno>> IRepository.GetAllAlunosAsync(PageParams pageParams,bool includeProfessor)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeProfessor)
            {
                query = query.Include(a => a.AlunosDisciplinas)
                            .ThenInclude(ad => ad.Disciplina)
                            .ThenInclude(d => d.Professor);
            }

            query = query.AsNoTracking().OrderBy(a => a.Id);

            if (!string.IsNullOrEmpty(pageParams.Nome))
                query = query.Where(
                                aluno => aluno.Nome
                                              .ToUpper()
                                              .Contains(pageParams.Nome.ToUpper()) ||
                                aluno.SobreNome
                                              .ToUpper()
                                              .Contains(pageParams.Nome.ToUpper())
                                );
            if (pageParams.Matricula > 0)
                query = query.Where(aluno => aluno.Matricula == pageParams.Matricula);
            
            if (!string.IsNullOrEmpty(pageParams.Ativo))
            {
                if (pageParams.Ativo == "1" || pageParams.Ativo.ToUpper() == "TRUE" || pageParams.Ativo.ToUpper() == "VERDADEIRO")
                    query = query.Where(aluno => aluno.Ativo == true);

                if (pageParams.Ativo == "0" || pageParams.Ativo.ToUpper() == "FALSE" || pageParams.Ativo.ToUpper() == "FALSO")
                    query = query.Where(aluno => aluno.Ativo == false);
            }

            // return await query.ToListAsync();
            return await PageList<Aluno>.CreateAsync(query, pageParams.PageNumber, pageParams.PageSize);
        }

        Aluno[] IRepository.GetAllAlunos(bool includeProfessor)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeProfessor)
            {
                query = query.Include(a => a.AlunosDisciplinas)
                            .ThenInclude(ad => ad.Disciplina)
                            .ThenInclude(d => d.Professor);
            }

            query = query.AsNoTracking().OrderBy(a => a.Id);

            return query.ToArray();
        }

        Aluno[] IRepository.GetAllAlunosByDisciplinaId(int DisciplinaId, bool includeProfessor)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeProfessor)
            {
                query = query.Include(a => a.AlunosDisciplinas)
                            .ThenInclude(ad => ad.Disciplina)
                            .ThenInclude(d => d.Professor);
            }

            query = query.AsNoTracking()
                        .OrderBy(a => a.Id)
                        .Where(aluno => aluno.AlunosDisciplinas.Any(ad => ad.DisciplinaId == DisciplinaId));
            
            return query.ToArray();
        }

        Aluno IRepository.GetAlunoById(int alunoId)
        {
            IQueryable<Aluno> query = _context.Alunos;
            query = query.AsNoTracking()
                        .Where(aluno => aluno.Id == alunoId);
            return query.FirstOrDefault();
        }

        Aluno IRepository.GetAlunoByName(string nome)
        {
            IQueryable<Aluno> query = _context.Alunos;
            query = query.AsNoTracking()
                        .Where(aluno => aluno.Nome == nome);
            return query.FirstOrDefault();            
        }

        Professor[] IRepository.GetAllProfessores(bool includeAlunos)
        {
            IQueryable<Professor> query = _context.Professores;
            if (includeAlunos)
            {
                query = query.Include(p => p.Disciplinas)
                            .ThenInclude(d => d.AlunosDisciplinas)
                            .ThenInclude(ad => ad.Aluno);
            }

            query = query.AsNoTracking()
                        .OrderBy(p => p.Id);
            
            return query.ToArray();
        }

        Professor[] IRepository.GetAllProfessoresByDisciplinaId(int disciplinaId, bool includeAlunos)
        {
            IQueryable<Professor> query = _context.Professores;
            if (includeAlunos)
            {
                query = query.Include(p => p.Disciplinas)
                            .ThenInclude(d => d.AlunosDisciplinas)
                            .ThenInclude(ad => ad.Aluno);
            }

            query = query.AsNoTracking()
                        .OrderBy(p => p.Id)
                        .Where(aluno => aluno.Disciplinas
                                            .Any(d => d.AlunosDisciplinas
                                                        .Any(ad => ad.DisciplinaId == disciplinaId)));
            
            return query.ToArray();
        }

        Professor IRepository.GetProfessorById(int professorId)
        {
            IQueryable<Professor> query = _context.Professores;
            query = query.AsNoTracking()
                        .Where(professor => professor.Id == professorId);
            return query.FirstOrDefault();            
        }

        Professor IRepository.GetProfessorByName(string nome)
        {
            IQueryable<Professor> query = _context.Professores;
            query = query.AsNoTracking()
                        .Where(professor => professor.Nome == nome);
            return query.FirstOrDefault();            
        }

    }
}