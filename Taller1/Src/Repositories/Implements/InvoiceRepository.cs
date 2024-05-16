using Microsoft.EntityFrameworkCore;
using Taller1.Src.Data;
using Taller1.Src.Models;
using Taller1.Src.Repositories.Interfaces;

namespace Taller1.Src.Repositories.Implements
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly DataContext _context;

        public InvoiceRepository(DataContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Invoice invoice)
        {
            await _context.Invoices.AddAsync(invoice);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Invoice>> GetAllAsync()
        {
            return await _context.Invoices.ToListAsync();
        }

        public async Task<Invoice?> FindByIdAsync(int id)
        {
            return await _context.Invoices.FindAsync(id);
        }
    }
}
