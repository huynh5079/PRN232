using AutoMapper;
using BusinessLayer.Repositories;
using DataLayer.DTOs;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<Users> _userRepository;
        private readonly IMapper _mapper;

        public UserService(IGenericRepository<Users> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto?> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetAsync(u => u.UserId == id);
            return _mapper.Map<UserDto?>(user);
        }

        public async Task<UserDto> RegisterUserAsync(UserRegisterDto registerDto)
        {
            var existingUser = await _userRepository.GetAsync(u => u.Email == registerDto.Email);
            if (existingUser != null)
            {
                throw new InvalidOperationException("Email already exists.");
            }

            var userEntity = _mapper.Map<Users>(registerDto);
            //userEntity.Password = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);

            await _userRepository.CreateAsync(userEntity);
            await _userRepository.SaveAsync();

            //Map DTO (none password)
            return _mapper.Map<UserDto>(userEntity);
        }
    }
}