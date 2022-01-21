using System;

namespace SmartSchool.WEBAPI.V1.Dtos
{
    /// <summary>
    /// Defini��o da Classe de transfer�ncia de Dados do Objeto Professor
    /// </summary>    
    public class ProfessorDto
    {
        public int Id { get; set; }
        public int Registro { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataIni { get; set; }
        public bool Ativo { get; set; }
    }
}