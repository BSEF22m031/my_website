using InventoryManagementDTOs;
using InventoryManagementDAL;
using System;
using System.Linq;

namespace InventoryManagementBLL
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly IInventoryTransactionRepository _inventoryTransactionRepository;

        //  Dependency Injection
        public ProductService(IProductRepository productRepository, ISupplierRepository supplierRepository, IInventoryTransactionRepository inventoryTransactionRepository)
        {
            _productRepository = productRepository;
            _supplierRepository = supplierRepository;
            _inventoryTransactionRepository = inventoryTransactionRepository;
        }

        // Add Product
        public void AddProduct(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));

            // Check if product name is unique
            if (_productRepository.GetAllProducts().Any(p => p.ProductName == product.ProductName))
                throw new InvalidOperationException("Product name must be unique.");

            // Check if supplier exists
            if (_supplierRepository.GetAllSuppliers().All(s => s.SupplierID != product.SupplierID))
                throw new InvalidOperationException("Invalid Supplier ID.");

            // Check if price is greater than 0
            if (product.Price <= 0)
                throw new InvalidOperationException("Price must be greater than 0.");

            // Add the product
            _productRepository.AddProduct(product);
        }

        // Update Product
        public void UpdateProduct(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));

            var existingProduct = _productRepository.GetProductById(product.ProductID);
            if (existingProduct == null) throw new InvalidOperationException("Product does not exist.");

            // Check if product name is unique (excluding current product)
            if (_productRepository.GetAllProducts().Any(p => p.ProductName == product.ProductName && p.ProductID != product.ProductID))
                throw new InvalidOperationException("Product name must be unique.");

            // Check if price is greater than 0
            if (product.Price <= 0)
                throw new InvalidOperationException("Price must be greater than 0.");

            // Update product details
            existingProduct.ProductName = product.ProductName;
            existingProduct.Category = product.Category;
            existingProduct.Price = product.Price;
            existingProduct.StockQuantity = product.StockQuantity;
            existingProduct.SupplierID = product.SupplierID;

            _productRepository.UpdateProduct(existingProduct);
        }

        // Delete Product - Only delete if no transactions exist
        public void DeleteProduct(int productId)
        {
            var product = _productRepository.GetProductById(productId);
            if (product == null) throw new InvalidOperationException("Product not found.");

            // Check if any transactions exist for the product
            if (_inventoryTransactionRepository.GetAllTransactions().Any(t => t.ProductID == productId))
                throw new InvalidOperationException("Cannot delete product. Transactions exist.");

            _productRepository.DeleteProduct(productId);
        }
    }
}
