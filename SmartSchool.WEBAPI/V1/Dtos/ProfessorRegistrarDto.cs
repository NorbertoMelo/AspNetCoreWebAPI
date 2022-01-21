using System;

namespace SmartSchool.WEBAPI.V1.Dtos
{
    /// <summary>
    /// Defini��o da Classe de transfer�ncia de Dados do objeto Professor
    /// </summary>
    public class ProfessorRegistrarDto
    {
        /// <summary>
        /// Identificador �nico do cadastro do professor no banco de dados.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// N�mero de registro do professor na institui��o de ensino.
        /// </summary>
        public int Registro { get; set; }
        /// <summary>
        /// Primeiro Nome do Professor.
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Segundo Nome ou Sobrenome do Professor.
        /// </summary>
        public string SobreNome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataIni { get; set; } = DateTime.Now;
        public DateTime? DataFim { get; set; } = null;
        public bool Ativo { get; set; } = true;        
    }
}