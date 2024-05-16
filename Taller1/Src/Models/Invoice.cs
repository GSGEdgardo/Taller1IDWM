namespace Taller1.Src.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductType { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }

        // Relación con Producto
        public Product? Product { get; set; }
    }
}
