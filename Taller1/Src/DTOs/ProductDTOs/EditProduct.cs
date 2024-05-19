using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taller1.Src.DTOs.ProductDTOs
{
    public class EditProductDto
    {
        public string? Name {get; set; } = string.Empty;
        public string? Type {get; set; } = string.Empty;
        public int? Price {get; set; }
        public int? Stock {get; set; }
        public string? Image {get; set; } = string.Empty;

    }
}