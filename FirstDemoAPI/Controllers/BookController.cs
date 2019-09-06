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
            if (bookResponse._errorList.Count == 0)
                return Ok(bookResponse.Response);
            return NotFound(bookResponse._errorList);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Book book)
        {
            BookResponse bookResponse = _bookService.Post(book);
            if (bookResponse._errorList.Count == 0)
                return Ok(bookResponse.Response);
            return BadRequest(bookResponse._errorList);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Book book)
        {
            BookResponse bookResponse = _bookService.Put(id,book);
            if (bookResponse._errorList.Count == 0)
                return Ok(bookResponse.Response);
            return BadRequest(bookResponse._errorList);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _bookService.Delete(id);
        }
    }
}
