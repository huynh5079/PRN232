using Business.DTOs;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interface
{
    public interface IBookService
    {
        Task<PaginationResult<BookDto>> GetAllBooksAsync(BookFilterAndSearchRequestDto request);
        Task<BookDto?> GetBookByIdAsync(string id);
        Task<BookDto> CreateBookAsync(CreateBookDto createBookDto);
        Task<BookDto> UpdateBookAsync(UpdateBookDto updateBookDto);
        Task<bool> DeleteBookAsync(string id);
    }
    
}
