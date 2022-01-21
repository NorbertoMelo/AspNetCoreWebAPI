using System;

namespace SmartSchool.WEBAPI.V2.Dtos
{
    /// <summary>
    /// Definição da Classe de transferência de Dados do Objeto Aluno
    /// </summary>
    public class AlunoDto
    {
        public int Id { get; set; }
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public int Idade { get; set; }
        public DateTime DataIni { get; set; }
        public bool Ativo { get; set; }
    }
}