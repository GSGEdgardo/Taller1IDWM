using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taller1.Src.DTOs;

namespace Taller1.Src.Services.Interfaces
{
    public interface IUserService
    {
        public Task<IEnumerable<UserDto>> GetUsers();

        public Task<bool> EditUser(int id, EditUserDto editUser);
        public Task<bool> UpdateUserStatus(int id, bool status);
    
        public Task<IEnumerable<UserDto>> GetAdmin();
    }
}