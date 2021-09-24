using Refit;
using SampleMvcApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleMvcApp
{
    public interface apicall
    {

        //[Headers("x-rapidapi-key : 64892e83d5msh2c4dfea8d121897p1f23a7jsnafd1a9f55ca0")]
        [Get("/")]
        Task<IEnumerable<Quote>> ApiGetAll();
        [Get("/")]
        Task<Quote> ApiGet();

        [Post("/")]
        [Headers("Authorization : bearer {token}")]
        object ApiPost(Quote q,string token);
        Task<Quote> ApiPut(Quote q);
    }
}
