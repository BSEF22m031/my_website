using InventoryManagementDAL;
using InventoryManagementDTOs;
using System;
using System.Collections.Generic;
using System.Linq;

public class ProductSearchService
{
    private readonly IProductRepository _productRepository;
    private readonly ISupplierRepository _supplierRepository;

    public ProductSearchService(IProductRepository productRepository, ISupplierRepository supplierRepository)
    {
        _productRepository = productRepository;
        _supplierRepository = supplierRepository;
    }

    public List<Product> SearchProducts(string searchTerm)
    {
        var products = _productRepository.GetAllProducts(); 
        var suppliers = _supplierRepository.GetAllSuppliers(); 

        return products
            .Where(p => p.ProductName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                        p.Category.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                        suppliers.Any(s => s.SupplierID == p.SupplierID && s.SupplierName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)))
            .ToList();
    }
}
