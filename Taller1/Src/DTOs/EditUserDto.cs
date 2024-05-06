using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taller1.Src.DTOs
{
    public class EditUserDto
    {
        public string Name { get; set; } = string.Empty;

        public DateOnly Birthdate { get; set;}

        public string Gender { get; set;} = string.Empty;
    }
}