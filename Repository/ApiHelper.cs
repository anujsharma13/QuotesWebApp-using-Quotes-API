using Refit;
using SampleMvcApp;
using SampleMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SampleMvcApp
{
    public class ApiHelper : IApiHelper
    {
        private readonly Quote quote;
        public double result;

        public async Task<Quote> HelperGet(int id)
        {
            Quote body;
            var call = RestService.For<apicall>($"https://quotesmanagementapi.azurewebsites.net/api/quotes/{id}");

            body = await call.ApiGet();

            return body;
        }

        public async Task<IEnumerable<Quote>> HelperGetAll()
        {
            IEnumerable<Quote> body;
              var call = RestService.For<apicall>("https://quotesmanagementapi.azurewebsites.net/api/quotes");

                body = await call.ApiGetAll();

            return body;
        }

        public async Task<Quote> HelperPost(Quote quote,string token)
        {
            
                var call = RestService.For<apicall>("https://quotesmanagementapi.azurewebsites.net/api/quotes");

                var x= call.ApiPost(quote,token);

            return quote;
        }

        public  async Task<double> HelperPut()
        {
            double body;
            try
            {
                var call = RestService.For<apicall>("https://quotesmanagementapi.azurewebsites.net");

              //  body = await call.ApiPut(quote);

            }
            catch (Exception w)
            {
                throw new InvalidOperationException("Exception");
            }
          
            return result;
        }
    }
}
