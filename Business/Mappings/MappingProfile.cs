using AutoMapper;
using Business.DTOs;
using DataAccess.Entities;

namespace Business.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Entity → DTO
            CreateMap<Book, BookDto>()
                .ForMember(dest => dest.AssignedToEmail,
                    opt => opt.MapFrom(src => src.AssignedToNavigation != null ? src.AssignedToNavigation.Email : null));

            // DTO → Entity
            CreateMap<CreateBookDto, Book>();
            CreateMap<UpdateBookDto, Book>()
                .ForMember(dest => dest.BookId, opt => opt.Ignore()); // Không cập nhật khóa chính nếu không cần

            // Nếu bạn cần ánh xạ ngược lại
            CreateMap<BookDto, Book>();
        }
    }
}
