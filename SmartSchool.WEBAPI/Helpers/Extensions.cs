using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SmartSchool.WEBAPI.Helpers
{
    public static class Extensions
    {
        public static void AddPagination(this HttpResponse response, 
            int currentPage, int ItemsPerPage, int totalItems, int totalPages)
        {
            var paginationHeader = new PaginationHeader(currentPage,ItemsPerPage,totalItems,totalPages);

            var camelCaseFormatter = new JsonSerializerSettings();
            camelCaseFormatter.ContractResolver = new CamelCasePropertyNamesContractResolver();

            response.Headers.Add("Pagination",JsonConvert.SerializeObject(paginationHeader, camelCaseFormatter));
            response.Headers.Add("Access-Control-Expose-Header","Pagination");
        }
    }
}