using BookManagementAPI.Dtos;
using BookManagementAPI.Models;
using BookManagementAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;

namespace BookManagementAPI.Controllers
{
    [Route("odata/[controller]")]
    public class PublishersController : ODataController
    {
        private readonly IPublisherService _service;
        private readonly IBookService _bookService;

        public PublishersController(IPublisherService service, IBookService bookService)
        {
            _service = service;
            _bookService = bookService;
        }

        // READ ALL
        [EnableQuery]
        [HttpGet]
        public IQueryable<PublisherDto> Get()
        {
            return _service.GetAll()
                .Include(p => p.Books)
                .Select(p => new PublisherDto
                {
                    Name = p.Name,
                    BookTitles = p.Books.Select(b => b.Title).ToList()
                });
        }

        // READ ONE
        [EnableQuery]
        [HttpGet("({key})")]
        public ActionResult<PublisherDto> Get(int key)
        {
            var publisher = _service.GetById(key);
            if (publisher == null)
                return NotFound();

            var dto = new PublisherDto
            {
                Name = publisher.Name,
                BookTitles = publisher.Books?.Select(b => b.Title).ToList() ?? new List<string>()
            };

            return Ok(dto);
        }

        // CREATE
        [HttpPost]
        public ActionResult<PublisherDto> Post([FromBody] PublisherDto dto)
        {
            var publisher = new Publisher
            {
                Name = dto.Name,
                Books = dto.BookTitles?.Select(title => new Book
                {
                    Title = title,
                    Price = 0 
                }).ToList()
            };

            var created = _service.Add(publisher);
            var result = new PublisherDto
            {
                Name = created.Name,
                BookTitles = created.Books?.Select(b => b.Title).ToList() ?? new List<string>()
            };

            return Created(result);
        }

        // UPDATE FULL (PUT)
        [HttpPut("({key})")]
        public IActionResult Put(int key, [FromBody] PublisherDto dto)
        {
            var existing = _service.GetById(key);
            if (existing == null) return NotFound();

            existing.Name = dto.Name;
            existing.Books = dto.BookTitles?.Select(title => new Book
            {
                Title = title,
                Price = 0, 
                PublisherId = key
            }).ToList();

            _service.Update(existing);
            return NoContent();
        }

        // UPDATE PARTIAL (PATCH)
        [HttpPatch("({key})")]
        public IActionResult Patch(int key, [FromBody] PublisherDto dto)
        {
            var existing = _service.GetById(key);
            if (existing == null) return NotFound();

            if (!string.IsNullOrEmpty(dto.Name)) existing.Name = dto.Name;

            if (dto.BookTitles != null && dto.BookTitles.Any())
            {
                existing.Books = dto.BookTitles.Select(title => new Book
                {
                    Title = title,
                    Price = 0,
                    PublisherId = key
                }).ToList();
            }

            _service.Update(existing);
            return NoContent();
        }

        // DELETE
        [HttpDelete("({key})")]
        public IActionResult Delete(int key)
        {
            if (!_service.Exists(key)) return NotFound();

            _service.Delete(key);
            return NoContent();
        }
    }
}
