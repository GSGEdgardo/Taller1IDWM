using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taller1.Src.DTOs;

namespace Taller1.Src.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string?> Login(LoginUserDto loginUserDto);
    }
}