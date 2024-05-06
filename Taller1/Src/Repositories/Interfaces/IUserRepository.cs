using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taller1.Src.Models;
using Taller1.Src.DTOs;

namespace Taller1.Src.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();

        Task<User?> GetUserByEmail(string Email);

        Task<bool> VerifyUserByEmail(string Email);

        Task<bool> VerifyUserByRut(string Email);

        Task AddUser(User user);

        Task<bool> EditUser(int id, EditUserDto editUser);
    }
}