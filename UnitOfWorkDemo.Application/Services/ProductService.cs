using UnitOfWorkAndxUnit.Application.Interfaces;
using UnitOfWorkAndxUnit.Domain.Entities;
using UnitOfWorkAndxUnit.Domain.Interfaces;

namespace UnitOfWorkAndxUnit.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
            => await _unitOfWork.Products.GetAllAsync();

        public async Task<IEnumerable<Product>> GetExpensiveProductsAsync(decimal minPrice)
            => await _unitOfWork.Products.GetExpensiveProductsAsync(minPrice);

        public async Task AddProductAsync(Product product)
        {
            if (product.Price <= 0)
                throw new ArgumentException("Fiyat 0'dan büyük olmalı!");

            await _unitOfWork.Products.AddAsync(product);
            await _unitOfWork.CommitAsync();
        }
    }
}
