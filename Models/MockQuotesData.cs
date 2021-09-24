using SampleMvcApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleMvcApp.Models
{
    public class MockQuotesData : IMockQuotesData
    {
        ApiHelper apiHelper = new ApiHelper();
        public Quote Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Quote> Get(int id)
        {
            Quote quote =await apiHelper.HelperGet(id);
            return quote;
        }

        public async Task<IEnumerable<Quote>> GetAll()
        {
            
            IEnumerable<Quote> quotes=await apiHelper.HelperGetAll();
            return quotes;
        }

        public async Task<Quote> Post(Quote quote,string token)
        {
            Quote q = await apiHelper.HelperPost(quote,token);
            return q;
        }

        public Quote Put(int id,Quote quote)
        {
            throw new NotImplementedException();
        }
    }
}
