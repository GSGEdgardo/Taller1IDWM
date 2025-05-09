using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taller1.Src.Repositories.Interfaces;
using Taller1.Src.Data;
using Taller1.Src.Models;
using SQLitePCL;
using Microsoft.EntityFrameworkCore;

namespace Taller1.Src.Repositories.Implements
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DataContext _context;

        public RoleRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Role?> GetRoleById(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            return role;
        }

        public async Task<Role?> GetRoleByName(string name)
        {
            var role = await _context.Roles.Where(r => r.Name == name).FirstOrDefaultAsync();
            return role;
        }
    }
}