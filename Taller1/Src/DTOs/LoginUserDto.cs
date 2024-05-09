using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Taller1.Src.DTOs
{
    public class LoginUserDto
    {
        [Required(ErrorMessage = "El campo Email es obligatorio")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo Contraseña es obligatorio")]
        public string Password { get; set;} = string.Empty;

    }
}