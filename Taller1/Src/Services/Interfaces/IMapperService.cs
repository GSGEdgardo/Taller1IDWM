using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taller1.Src.DTOs;
using Taller1.Src.DTOs.ProductDTOs;
using Taller1.Src.Models;

namespace Taller1.Src.Services.Interfaces
{
    public interface IMapperService
    {
        public User RegisterUserDtoToUser(RegisterUserDto registerUserDto);

        public IEnumerable<UserDto> UserToUserDto(IEnumerable<User> users);

        public Product CreateProductDtoToProduct(CreateProductDto createProductDto);
    }
}