using System;

namespace SmartSchool.WEBAPI.V2.Dtos
{
    /// <summary>
    /// Defini��o da Classe de transfer�ncia de Dados do objeto Aluno
    /// </summary>
    public class AlunoRegistrarDto
    {
        /// <summary>
        /// Identificador �nico do cadastro do aluno no banco de dados.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// N�mero da matr�cula do aluno na insittui��o de ensino.
        /// </summary>
        public int Matricula { get; set; }
        /// <summary>
        /// Primeiro Nome do Aluno.
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Segundo Nome ou Sobrenome do Aluno.
        /// </summary>
        public string SobreNome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNasc { get; set; }
        public DateTime DataIni { get; set; } = DateTime.Now;
        public DateTime? DataFim { get; set; } = null;
        public bool Ativo { get; set; } = true;        
    }
}