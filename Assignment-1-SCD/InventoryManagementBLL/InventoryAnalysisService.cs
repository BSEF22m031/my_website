using InventoryManagementDTOs;
using InventoryManagementDAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InventoryManagementBLL
{
    public class InventoryAnalysisService
    {
        private readonly IProductRepository _productRepository;

        //Dependency Injection
        public InventoryAnalysisService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // Calculate total stock value per category
        public Dictionary<string, decimal> CalculateTotalStockValue()
        {
            var products = _productRepository.GetAllProducts(); 

            var result = products
                .GroupBy(p => p.Category)
                .ToDictionary(
                    g => g.Key,
                    g => g.Sum(p => p.Price * p.StockQuantity)
                );

            return result;
        }

        // Show low-stock alerts for products with StockQuantity < 5
        public List<Product> GetLowStockProducts()
        {
            // Fetch all products using repository
            var products = _productRepository.GetAllProducts(); 

            return products
                .Where(p => p.StockQuantity < 5)
                .ToList();
        }
    }
}
