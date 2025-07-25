using AutoMapper;
using Business.DTOs;
using Business.Services.Interface;
using DataAccess.Entities;
using DataAccess.Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Services
{
    public class BookService : IBookService
    {
        private readonly IGenericRepository<Book> _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IGenericRepository<Book> bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<PaginationResult<BookDto>> GetAllBooksAsync(BookFilterAndSearchRequestDto request)
        {
            var books = await _bookRepository.GetAllAsync(
                filter: b =>
                    (string.IsNullOrWhiteSpace(request.SearchTerm) ||
                     b.Title.Contains(request.SearchTerm) ||
                     b.Author.Contains(request.SearchTerm)) &&
                    (string.IsNullOrWhiteSpace(request.TitleStartsWith) ||
                     b.Title.StartsWith(request.TitleStartsWith))
            );

            var sorted = request.SortBy switch
            {
                "Title" => request.SortAsc ? books.OrderBy(b => b.Title) : books.OrderByDescending(b => b.Title),
                "Genre" => request.SortAsc ? books.OrderBy(b => b.Genre) : books.OrderByDescending(b => b.Genre),
                _ => request.SortAsc ? books.OrderBy(b => b.Author) : books.OrderByDescending(b => b.Author)
            };

            var paged = sorted
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();

            var dtoList = _mapper.Map<List<BookDto>>(paged);

            return new PaginationResult<BookDto>(
                dtoList,                 // data
                books.Count(),           // totalItems
                request.PageNumber,      // pageNumber
                request.PageSize         // pageSize
            );

        }

        public async Task<BookDto?> GetBookByIdAsync(string id)
        {
            if (!int.TryParse(id, out int bookId))
                throw new ArgumentException("Invalid book id");

            var book = await _bookRepository.GetAsync(b => b.BookId == bookId);
            return book == null ? null : _mapper.Map<BookDto>(book);
        }

        public async Task<BookDto> CreateBookAsync(CreateBookDto createBookDto)
        {
            var book = _mapper.Map<Book>(createBookDto);
            await _bookRepository.CreateAsync(book);
            return _mapper.Map<BookDto>(book);
        }

        public async Task<BookDto> UpdateBookAsync(UpdateBookDto updateBookDto)
        {
            int bookId = updateBookDto.BookId;

            var book = await _bookRepository.GetAsync(b => b.BookId == bookId);
            if (book == null) throw new Exception("Book not found");

            _mapper.Map(updateBookDto, book);
            await _bookRepository.UpdateAsync(book);
            return _mapper.Map<BookDto>(book);
        }


        public async Task<bool> DeleteBookAsync(string id)
        {
            if (!int.TryParse(id, out int bookId))
                throw new ArgumentException("Invalid book id");

            var book = await _bookRepository.GetAsync(b => b.BookId == bookId);
            if (book == null) return false;

            await _bookRepository.RemoveAsync(book);
            return true;
        }
    }
}
