using SampleMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleMvcApp.Interfaces
{
   public interface IMockQuotesData
    {
        public Task<Quote> Get(int id);
        public Task<IEnumerable<Quote>> GetAll();
        public Task<Quote> Post(Quote quote,string token);
        public Quote Put(int id,Quote q);
        public Quote Delete(int id);
    }
}
