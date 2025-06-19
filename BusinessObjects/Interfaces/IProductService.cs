using DataAccess;
using System.Linq; 

namespace BusinessObjects.Interfaces
{
    public interface IProductService
    {
        IQueryable<Product> GetAllProducts();
        Product GetProductById(int id);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);

    }
}