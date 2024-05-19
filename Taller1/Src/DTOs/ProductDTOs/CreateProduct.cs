using System.ComponentModel.DataAnnotations;

namespace Taller1.Src.DTOs.ProductDTOs
{
    public class CreateProductDto
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "El nombre solo puede contener letras")]
        [StringLength(64, MinimumLength = 10, ErrorMessage = "El nombre debe tener entre 10 y 64 caracteres")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "La categoría es requerida")]
        [EnumDataType(typeof(ProductCategory), ErrorMessage = "La categoría no es válida")]
        public string Type { get; set; } = string.Empty;

        [Required(ErrorMessage = "El stock es requerido")]
        [Range(0, 99999, ErrorMessage = "El stock debe ser un número positivo menor a 100000")]
        public int Stock { get; set; }
        
        [Required(ErrorMessage = "El precio es requerido")]
        [Range(0,99999999, ErrorMessage = "El precio debe ser un número positivo menor a 100 millones")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "La imagen es requerida")]
        public string Image { get; set; } = string.Empty;

        public enum ProductCategory
        {
            Tecnologia,
            Electrohogar,
            Jugueteria,
            Ropa,
            Muebles,
            Comida,
            Libros
        }
    }
}