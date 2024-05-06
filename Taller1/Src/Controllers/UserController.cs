using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Taller1.Src.Models;
using Taller1.Src.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Taller1.Src.DTOs;
using Taller1.Src.Services.Interfaces;

namespace Taller1.Src.Controllers
{
    [ApiController]
    //[Authorize(Roles= "Admin")]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
             _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var result = await _userService.GetUsers();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public ActionResult<string> EditUser(int id, [FromBody] EditUserDto editUser)
        {
            var result = _userService.EditUser(id, editUser).Result;
            if(!result){
                return NotFound("El usuario no existe en el sistema.");
            }
            return Ok("El usuario se editó correctamente");
        }

    }
}