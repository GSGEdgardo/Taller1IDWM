using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Taller1.Src.DTOs
{
    public class RegisterUserDto
    {
        [Required(ErrorMessage = "El campo RUT es obligatorio")]
        public string Rut { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo nombre es obligatorio")]
        [MinLength(8, ErrorMessage ="El nombre debe tener al menos 8 caracteres.")]
        [MaxLength(255, ErrorMessage = "El nombre debe tener a lo más 255 caracteres.")]
        public string Name { get; set; } = string.Empty;

        public DateOnly Birthdate { get; set;}

        [Required(ErrorMessage = "El campo email es obligatorio")]
        [EmailAddress(ErrorMessage = "El email no tiene formato valido")]
        public string Email { get; set; } = string.Empty;

        public string Gender { get; set;} = string.Empty;

        [Required(ErrorMessage = "La Contraseña es obligatoria.")]
        [RegularExpression(@"^(?=.*[0-9])(?=.*[a-zA-Z])[a-zA-Z0-9]+$", ErrorMessage = "La Contraseña debe ser alfanumérica.")]
        [MinLength(8, ErrorMessage = "La contraseña debe tener al menos 8 caracteres.")]
        [MaxLength(20, ErrorMessage = "La contraseña debe tener a lo más 20 caracteres.")]
        public string Password { get; set; } = string.Empty;

        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}