using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FirstDemoAPI.Model;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FirstDemoAPI.Controllers
{
    
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        BookService _bookService = new BookService();
        // GET: api/values
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return _bookService.Get();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                Book book = _bookService.Get(id);
                return Ok(book);
            }
            catch(BookNotFoundException)
            {
                return NotFound($"Book with given id : {id} Not Found");
            }
        }

        // POST api/values
        [HttpPost]
        public string Post([FromBody]Book book)
        {
            return _bookService.Post(book);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody]Book book)
        {
            return _bookService.Put(id,book);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _bookService.Delete(id);
        }
    }
}
