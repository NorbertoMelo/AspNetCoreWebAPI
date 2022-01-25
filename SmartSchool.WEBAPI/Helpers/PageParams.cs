namespace SmartSchool.WEBAPI.Helpers
{
    public class PageParams
    {
        public const int MaxPageSize = 50;
        private int pageSize = 10;
        public int PageNumber { get; set; } = 1;
        public int PageSize 
        { 
            get{return pageSize;} 
            set{pageSize = (value > MaxPageSize) ? MaxPageSize : value;}
        }

        public int? Matricula { get; set; } = null;
        public string Nome { get; set; } = string.Empty;
        public string Ativo { get; set; } = string.Empty;
    }
}