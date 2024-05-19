using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taller1.Src.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Rut { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public DateOnly Birthdate { get; set;}

        public string Gender { get; set;} = string.Empty;

        public int RoleId { get; set;}

        

    }
}