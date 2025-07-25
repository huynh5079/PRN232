using Business.DTOs;
using Business.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace PEBolomadto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET: api/Book
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] BookFilterAndSearchRequestDto request)
        {
            var result = await _bookService.GetAllBooksAsync(request);
            return Ok(result);
        }

        // GET: api/Book/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null)
                return NotFound();

            return Ok(book);
        }

        // POST: api/Book
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBookDto createDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdBook = await _bookService.CreateBookAsync(createDto);
            return CreatedAtAction(nameof(GetById), new { id = createdBook.BookId }, createdBook);
        }

        // PUT: api/Book
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBookDto updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var updatedBook = await _bookService.UpdateBookAsync(updateDto);
                return Ok(updatedBook);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE: api/Book/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var deleted = await _bookService.DeleteBookAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
