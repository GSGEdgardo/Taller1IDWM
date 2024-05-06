using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Taller1.Src.DTOs;
using Taller1.Src.Services.Interfaces;
using Taller1.Src.Models;

namespace Taller1.Src.Services.Implements
{
    public class MapperService: IMapperService
    {
        private readonly IMapper _mapper;

        public MapperService(IMapper mapper)
        {
            _mapper = mapper;
        } 
        
        public User RegisterUserDtoToUser(RegisterUserDto registerUserDto)
        {
            var mappedUser = _mapper.Map<User>(registerUserDto);
            return mappedUser;
        }

        public IEnumerable<UserDto> UserToUserDto(IEnumerable<User> users)
        {
            var mappedUsers = users.Select(u => _mapper.Map<UserDto>(u)).ToList();
            return mappedUsers;
        }
    }
}