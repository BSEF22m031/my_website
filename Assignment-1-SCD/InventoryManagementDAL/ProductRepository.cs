using InventoryManagementDTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace InventoryManagementDAL
{
    public class ProductRepository : IProductRepository
    {
        private readonly InventoryManagementDbContext _context;

        public ProductRepository(InventoryManagementDbContext context)
        {
            _context = context;
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products.Include(p => p.Supplier).ToList();
        }

        public Product GetProductById(int id)
        {
            return _context.Products.Include(p => p.Supplier).FirstOrDefault(p => p.ProductID == id);
        }

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }
    }
}
