using AutoMapper;
using DataLayer.DTOs;
using DataLayer.Entities;

namespace BusinessLayer.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Map từ Entity -> DTO (dùng để đọc/hiển thị dữ liệu)
            CreateMap<Courses, CourseDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName))
                .ForMember(dest => dest.AuthorEmail, opt => opt.MapFrom(src => src.User.Email));

            CreateMap<Categories, CategoryDto>();
            CreateMap<Users, UserDto>();
            CreateMap<Enrollments, EnrollmentDto>()
                 .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.User.Email))
                 .ForMember(dest => dest.CourseTitle, opt => opt.MapFrom(src => src.Course.Title));

            // Map từ DTO -> Entity (dùng khi tạo mới/cập nhật)
            CreateMap<CourseCreateDto, Courses>();
            CreateMap<CourseUpdateDto, Courses>();
            CreateMap<CategoryCreateDto, Categories>();
            CreateMap<CategoryUpdateDto, Categories>();
            CreateMap<UserRegisterDto, Users>();
            CreateMap<EnrollmentCreateDto, Enrollments>();
        }
    }
}