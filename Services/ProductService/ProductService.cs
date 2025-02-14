using DotNetCRUD.DTO.RequestDTO.Product;
using DotNetCRUD.DTO.ResponseDTO.Product;
using DotNetCRUD.IRepositories.IProductRepository;
using DotNetCRUD.IServices.IProductService;
using DotNetCRUD.Models;

namespace DotNetCRUD.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductResponceDTO>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllProductsAsync();

            return products.Select(x => new ProductResponceDTO
            {
                Id=x.Id,
                Name=x.Name,
                Price=x.Price,

            });   
            

        }

        public async Task<Products> GetProductByIdAsync(Guid id)
        {
            return await _productRepository.GetProductByIdAsync(id);
        }

       public async Task<ProductResponceDTO>AddProductAsync(ProductRequestDTO products)
        {
            var product = new Products
            {
                Name = products.Name,
                Price = products.Price,
                Description = products.Description,
            };
            var data = await _productRepository.AddProductAsync(product);
            return new ProductResponceDTO
            {
                Id = data.Id,
                Name = data.Name,
                Price = data.Price
            };

        }

        public async Task UpdateProductAsync(Products product)
        {
            await _productRepository.UpdateProductAsync(product);
        }

        public async Task DeleteProductAsync(Guid id)
        {
            await _productRepository.DeleteProductAsync(id);
        }
    
}
}
