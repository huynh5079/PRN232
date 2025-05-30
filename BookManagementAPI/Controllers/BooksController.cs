using BookManagementAPI.Dtos;
using BookManagementAPI.Models;
using BookManagementAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Deltas;

namespace BookManagementAPI.Controllers
{
    [Route("odata/[controller]")]
    public class BooksController : ODataController
    {
        private readonly IBookService _bookService;
        private readonly IPublisherService _publisherService;

        public BooksController(IBookService bookService, IPublisherService publisherService)
        {
            _bookService = bookService;
            _publisherService = publisherService;
        }

        // GET: odata/Books
        [EnableQuery]
        public IQueryable<BookDto> Get()
        {
            return _bookService.GetAll()
                .Select(b => new BookDto
                {
                    Title = b.Title,
                    Price = b.Price,
                    PublisherName = b.Publisher.Name
                });
        }

        // GET: odata/Books(1)
        [EnableQuery]
        public IActionResult Get([FromODataUri] int key)
        {
            var book = _bookService.GetById(key);
            if (book == null) return NotFound();

            var dto = new BookDto
            {
                Title = book.Title,
                Price = book.Price,
                PublisherName = book.Publisher.Name
            };

            return Ok(dto);
        }

        // POST: odata/Books
        public IActionResult Post([FromBody] BookDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var publisher = _publisherService.GetAll()
                .FirstOrDefault(p => p.Name == dto.PublisherName);

            if (publisher == null)
                return BadRequest("Publisher does not exist");

            var book = new Book
            {
                Title = dto.Title,
                Price = dto.Price,
                PublisherId = publisher.Id
            };

            _bookService.Add(book);

            return Created(dto);
        }

        // PUT: odata/Books(1)
        public IActionResult Put([FromODataUri] int key, [FromBody] BookDto dto)
        {
            var existing = _bookService.GetById(key);
            if (existing == null) return NotFound();

            var publisher = _publisherService.GetAll()
                .FirstOrDefault(p => p.Name == dto.PublisherName);

            if (publisher == null)
                return BadRequest("Publisher does not exist");

            existing.Title = dto.Title;
            existing.Price = dto.Price;
            existing.PublisherId = publisher.Id;

            _bookService.Update(existing);
            return Updated(dto);
        }

        // PATCH: odata/Books(1)
        public IActionResult Patch([FromODataUri] int key, [FromBody] Delta<BookDto> delta)
        {
            var book = _bookService.GetById(key);
            if (book == null) return NotFound();

            var dto = new BookDto
            {
                Title = book.Title,
                Price = book.Price,
                PublisherName = book.Publisher?.Name
            };

            delta.Patch(dto);

            if (!string.IsNullOrEmpty(dto.PublisherName))
            {
                var publisher = _publisherService.GetAll()
                    .FirstOrDefault(p => p.Name == dto.PublisherName);

                if (publisher == null)
                    return BadRequest("Publisher does not exist");

                book.PublisherId = publisher.Id;
            }

            book.Title = dto.Title;
            book.Price = dto.Price;

            _bookService.Update(book);
            return Updated(dto);
        }

        // DELETE: odata/Books(1)
        public IActionResult Delete([FromODataUri] int key)
        {
            var book = _bookService.GetById(key);
            if (book == null) return NotFound();

            _bookService.Delete(key);
            return NoContent();
        }
    }
}
