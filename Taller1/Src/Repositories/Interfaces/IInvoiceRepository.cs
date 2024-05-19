using Taller1.Src.Models;

namespace Taller1.Src.Repositories.Interfaces
{
    public interface IInvoiceRepository
    {
        Task CreateAsync(Invoice invoice);
        Task<IEnumerable<Invoice>> GetAllAsync();
        Task<Invoice?> FindByIdAsync(int id);
    }
}
