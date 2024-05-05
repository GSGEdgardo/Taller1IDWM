using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taller1.Src.Models;

namespace Taller1.Src.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        Task<Role?> GetRoleById(int id);
    }
}