using BusinessObjects;

namespace Repositories
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
        void SaveProduct(Product p);
        void UpdateProduct(Product p);
        void DeleteProduct(Product p);
        Product GetProductById(int id);
    }
}
