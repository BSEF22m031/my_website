using InventoryManagementDTOs;
using System.Collections.Generic;

namespace InventoryManagementDAL
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();
        Product GetProductById(int id);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
    }
}
