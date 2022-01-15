using System;

namespace SmartSchool.WEBAPI.Models
{
    public class AlunoDisciplina
    {
        public AlunoDisciplina() {}
        public AlunoDisciplina(int alunoId, int disciplinaId)
        {
            this.AlunoId = alunoId;
            this.DisciplinaId = disciplinaId;
        }
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }
        public int DisciplinaId { get; set; }
        public Disciplina Disciplina { get; set; }
        public DateTime DataIni { get; set; } = DateTime.Now;
        public DateTime? DataFim { get; set; }    }
}