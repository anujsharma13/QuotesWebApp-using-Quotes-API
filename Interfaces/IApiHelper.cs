using SampleMvcApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleMvcApp
{
    public interface IApiHelper
    {
        
        public Task<Quote> HelperGet(int id);
        public Task<IEnumerable<Quote>> HelperGetAll();
        public Task<Quote> HelperPost(Quote quote,string token);
        public Task<double> HelperPut();

    }
}
