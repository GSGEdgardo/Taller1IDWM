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
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Taller1.Src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
             _userService = userService;
        }

        [HttpGet]
        [Authorize(Roles="Admin")]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var result = await _userService.GetUsers();
            return Ok(result);
        }
        
        [HttpGet("admin")]
        [Authorize(Roles="Admin")]
        public async Task<ActionResult<IEnumerable<User>>> GetAdmin()
        {
            var result = await _userService.GetAdmin();
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

        [HttpPut("{id}/changepassword")]
        public ActionResult<string> ChangePassword(int id, [FromBody] PasswordDto changePasswordDto)
        {
            var (success, errorMessage) = _userService.ChangePassword(id, changePasswordDto).Result;
            if(!success){
                return BadRequest(errorMessage);
            }
            HttpContext.SignOutAsync(JwtBearerDefaults.AuthenticationScheme);
            return Ok("Se ha cambiado la contraseña con éxito, se procederá a cerrar su cuenta.");
        }


        [HttpPatch("{id}/status")]
        [Authorize(Roles="Admin")]
        public async Task<IActionResult> UpdateUserStatus(int id, [FromBody] UpdateUserStatusDto updateUserStatusDto)
        {
            try
            {
                var result = await _userService.UpdateUserStatus(id, updateUserStatusDto.Status);
                if (!result)
                {
                    return NotFound("El usuario no existe en el sistema.");
                }else{
                    return Ok("El usuario se actualizó correctamente");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}