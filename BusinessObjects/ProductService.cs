using BusinessObjects.Interfaces;
using DataAccess; 
using Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessObjects.Services
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> _productRepository;

        public ProductService(IGenericRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public IQueryable<Product> GetAllProducts()
        {
            return _productRepository.GetAllAsQueryable();
        }

        public Product GetProductById(int id)
        {
            return _productRepository.GetAsync(p => p.ProductId == id).Result;
        }

        public void AddProduct(Product product)
        {

            _productRepository.CreateAsync(product).Wait(); 
            _productRepository.SaveAsync().Wait();        
        }

        public void UpdateProduct(Product product)
        {
            
            _productRepository.UpdateAsync(product).Wait(); 
            _productRepository.SaveAsync().Wait();
        }

        public void DeleteProduct(int id)
        {
            var productToDelete = _productRepository.GetAsync(p => p.ProductId == id).Result;
            if (productToDelete != null)
            {
                _productRepository.RemoveAsync(productToDelete).Wait();
                _productRepository.SaveAsync().Wait();
            }
        }
    }
}