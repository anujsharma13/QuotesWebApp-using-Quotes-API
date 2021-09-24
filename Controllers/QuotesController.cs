using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleMvcApp.Interfaces;
using SampleMvcApp.Models;
using System.IO;
using System.Threading.Tasks;

namespace SampleMvcApp.Controllers
{
   
   [Authorize]
    public class QuotesController : Controller
    {
        IMockQuotesData quotes;
        AccountController account = new AccountController();
        public QuotesController(IMockQuotesData quotes)
        {
            this.quotes = quotes;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            
            var q =await quotes.GetAll();
            return View("Get",q);
        }
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var quote = await quotes.Get(id);
           
            if (quote == null)
            {
                return NotFound("Not found");
            }
            return View("GetId",quote);
        }
        [HttpGet]
        public IActionResult Post()
        {
                return View();
        }
        [HttpPost]
        public async Task<IActionResult> Post(Quote q)
        {
            FileStream f = new FileStream("JWTTokenGenerated.txt", FileMode.Open);
            StreamReader s = new StreamReader(f);
            var token = s.ReadLine();
            var x=await quotes.Post(q,token);
            return View("GetAll");
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id,Quote q)
        {
            var quote = quotes.Put(id,q);
            if(quote==null)
            {
                return NotFound("Not found");
            }
            quote.Title = q.Title;
            quote.Author = q.Author;
            quote.Description = q.Description;
            quote.Type = q.Type;
            quote.CreatedAt = q.CreatedAt;
            return View();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var quote = quotes.Delete(id);
            if (quote == null)
            {
                return NotFound("Not found");
            }

            return View();
        }
        //[HttpGet("[action]")]
        //public IActionResult PagingQuote(int pagenumber,int pagesize)
        //{
        //    var q = quotes.Quotes;
        //    return Ok(q.Skip((pagenumber - 1) * pagesize).Take(pagesize));
        //}
        //[HttpGet("[action]")]
        //public IActionResult SearchQuote(string type)
        //{
        //    var q=quotes.Quotes.Where(q => q.Type == type);
        //    return Ok(q);
        //}
    }
}
