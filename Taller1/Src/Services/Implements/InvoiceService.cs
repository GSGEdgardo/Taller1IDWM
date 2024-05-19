using AutoMapper;
using Taller1.Src.DTOs;
using Taller1.Src.DTOs.ProductDTOs;
using Taller1.Src.Models;
using Taller1.Src.Repositories.Interfaces;
using Taller1.Src.Services.Interfaces;

namespace Taller1.Src.Services.Implements
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public InvoiceService(IInvoiceRepository invoiceRepository, IProductRepository productRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<InvoiceDto> CreateInvoice(int productId, int quantity)
        {
            var products = await _productRepository.GetProducts();
            var product = products.FirstOrDefault(p => p.Id == productId);

            if (product == null)
                throw new ArgumentException("Producto no encontrado");

            if (product.Stock < quantity)
                throw new ArgumentException("Stock insuficiente");

            var invoice = new Invoice
            {
                ProductId = productId,
                ProductName = product.Name,
                ProductType = product.Type,
                Quantity = quantity,
                UnitPrice = product.Price,
                TotalPrice = product.Price * quantity,
                Date = DateTime.UtcNow
            };

            // Actualiza el stock del producto
            product.Stock -= quantity;

            await _productRepository.EditProduct(product.Id, new EditProductDto { Stock = product.Stock , Name = product.Name, Type = product.Type, Price = product.Price, Image = product.Image  });

            await _invoiceRepository.CreateAsync(invoice);

            return _mapper.Map<InvoiceDto>(invoice);
        }

        public async Task<InvoiceDto?> GetInvoiceByIdAsync(int id)
        {
            var invoice = await _invoiceRepository.FindByIdAsync(id);
            if (invoice == null)
                return null;

            return _mapper.Map<InvoiceDto>(invoice);
        }



        public async Task<IEnumerable<InvoiceDto>> GetAllInvoices()
        {
            var invoices = await _invoiceRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<InvoiceDto>>(invoices);
        }
    }
}
