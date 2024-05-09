using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Taller1.Src.Data;
using Taller1.Src.Models;
using Taller1.Src.Repositories.Interfaces;
using Taller1.Src.DTOs;

namespace Taller1.Src.Repositories.Implements
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _context.Users.Where(u => u.RoleId == 2).ToListAsync();
            return users;
        }

        public async Task<User?> GetUserByEmail(string Email)
        {
            var user = await _context.Users.Where(u => u.Email == Email)
                                            .Include(u => u.Role)
                                            .FirstOrDefaultAsync();
            return user;
        }

        public async Task AddUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> VerifyUserByEmail(string Email)
        {
            var user = await _context.Users.Where(u => u.Email == Email)
                                            .FirstOrDefaultAsync();
            if(user == null){
                return false;
            }
            return true;

        }

        public async Task<bool> VerifyUserByRut(string rut)
        {
            var user = await _context.Users.Where(u => u.Rut == rut)
                                        .FirstOrDefaultAsync();
            if (user == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> EditUser(int id, EditUserDto editUser)
        {
            var existingUser = await _context.Users.FindAsync(id);
            if (existingUser == null){
                return false;
            }

            existingUser.Name = editUser.Name ?? existingUser.Name;
            if (editUser.Birthdate != default(DateOnly))
            {
                existingUser.Birthdate = editUser.Birthdate;
            }

            if (!string.IsNullOrEmpty(editUser.Gender))
            {
                existingUser.Gender = editUser.Gender;
            }

            _context.Entry(existingUser).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;

        }
    }
}