using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessObjects;
using BusinessObjects;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        public List<Product> GetProducts() => ProductDAO.GetProducts();
        public Product GetProductById(int id) => ProductDAO.GetProductById(id);
        public void SaveProduct(Product p) => ProductDAO.SaveProduct(p);
        public void UpdateProduct(Product p) => ProductDAO.UpdateProduct(p);
        public void DeleteProduct(Product p) => ProductDAO.DeleteProduct(p);
    }
}
