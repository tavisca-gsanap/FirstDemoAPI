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
            BookResponse bookResponse = _bookService.Get(id);
            if (bookResponse.ErrorList.Count == 0)
                return Ok(bookResponse.Response);
            return NotFound(bookResponse.ErrorList);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Book book)
        {
            BookResponse bookResponse = _bookService.Post(book);
            if (bookResponse.ErrorList.Count == 0)
                return Ok(bookResponse.Response);
            return BadRequest(bookResponse.ErrorList);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Book book)
        {
            BookResponse bookResponse = _bookService.Put(id,book);
            if (bookResponse.ErrorList.Count == 0)
                return Ok(bookResponse.Response);
            return BadRequest(bookResponse.ErrorList);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            BookResponse bookResponse = _bookService.Delete(id);
            if (bookResponse.ErrorList.Count == 0)
                return Ok(bookResponse.Response);
            return BadRequest(bookResponse.ErrorList);
        }
    }
}
