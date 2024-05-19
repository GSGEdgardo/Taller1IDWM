using Taller1.Src.DTOs;

namespace Taller1.Src.Services.Interfaces
{
    public interface IInvoiceService
    {
        Task<InvoiceDto> CreateInvoice(int productId, int quantity);
        Task<IEnumerable<InvoiceDto>> GetAllInvoices();
        Task<InvoiceDto?> GetInvoiceByIdAsync(int id);
    }
}
