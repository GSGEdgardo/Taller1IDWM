using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taller1.Src.DTOs.ProductDTOs
{
    public class GetProductDto
    {
        public int Id {get; set; }
        public string Name {get; set; } = string.Empty;
        public string Description {get; set; } = string.Empty;
        public string Type {get; set; } = string.Empty;
        public decimal Price {get; set; }
        public int Stock {get; set; }
        public string Image {get; set; } = string.Empty;

    }
}