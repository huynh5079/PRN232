using Lab02_ODataBookAPI.Models;
using Lab02_ODataBookAPI.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace Lab02_ODataBookAPI.Controllers
{
    [Route("odata/[controller]")]
    public class BooksController : ODataController
    {
        private readonly IBookService _service;

        public BooksController(IBookService service)
        {
            _service = service;
        }

        [EnableQuery]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetAll());
        }

        [EnableQuery]
        [HttpGet("{key}")]
        public IActionResult Get(int key)
        {
            var book = _service.GetById(key);
            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var created = _service.Add(book);
            return Created(created);
        }

        [HttpPut("{key}")]
        public IActionResult Put(int key, [FromBody] Book book)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (key != book.BookId) return BadRequest("Key mismatch");

            var updated = _service.Update(key, book);
            if (updated == null) return NotFound();

            return Updated(updated);
        }

        [HttpDelete("{key}")]
        public IActionResult Delete(int key)
        {
            var success = _service.Delete(key);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}
