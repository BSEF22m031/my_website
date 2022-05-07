using InventoryManagementDTOs;
using InventoryManagementDAL;
using System;
using System.Linq;

namespace InventoryManagementBLL
{
    public class StockTransactionService
    {
        private readonly InventoryManagementDbContext _context;

        public StockTransactionService(InventoryManagementDbContext context)
        {
            _context = context;
        }

        // Validate product existence and quantity > 0
        public void StockIn(int productId, int quantity)
        {
            var product = _context.Products.SingleOrDefault(p => p.ProductID == productId);
            if (product == null) throw new InvalidOperationException("Product not found.");

            if (quantity <= 0) throw new InvalidOperationException("Quantity must be greater than 0.");

            // Update product stock quantity
            product.StockQuantity += quantity;
            _context.SaveChanges();
        }

        // Ensure enough stock before processing
        public void StockOut(int productId, int quantity)
        {
            var product = _context.Products.SingleOrDefault(p => p.ProductID == productId);
            if (product == null) throw new InvalidOperationException("Product not found.");

            if (quantity <= 0) throw new InvalidOperationException("Quantity must be greater than 0.");

            if (product.StockQuantity < quantity)
                throw new InvalidOperationException("Not enough stock available.");

            // Update product stock quantity
            product.StockQuantity -= quantity;
            _context.SaveChanges();
        }
    }
}



/*using InventoryManagementDTOs;
using InventoryManagementDAL;
using System;

namespace InventoryManagementBLL
{
    public class StockTransactionService
    {
        private readonly IProductRepository _productRepository;
        private readonly IInventoryTransactionRepository _transactionRepository;

        // Constructor - Dependency Injection
        public StockTransactionService(IProductRepository productRepository, IInventoryTransactionRepository transactionRepository)
        {
            _productRepository = productRepository;
            _transactionRepository = transactionRepository;
        }

        // Stock Addition (IN): Validate product existence and quantity > 0
        public void StockIn(int productId, int quantity)
        {
            var product = _productRepository.GetProductById(productId);
            if (product == null) throw new InvalidOperationException("Product not found.");

            if (quantity <= 0) throw new InvalidOperationException("Quantity must be greater than 0.");

            // Update product stock quantity
            product.StockQuantity += quantity;
            _productRepository.UpdateProduct(product);

            // Log the stock-in transaction
            var transaction = new InventoryTransaction
            {
                ProductID = productId,
                Quantity = quantity,
                TransactionType = "IN", // or any other identifier for "Stock-In"
                TransactionDate = DateTime.Now
            };
            _transactionRepository.AddTransaction(transaction);
        }

        // Stock Removal (OUT): Ensure enough stock before processing
        public void StockOut(int productId, int quantity)
        {
            var product = _productRepository.GetProductById(productId);
            if (product == null) throw new InvalidOperationException("Product not found.");

            if (quantity <= 0) throw new InvalidOperationException("Quantity must be greater than 0.");

            if (product.StockQuantity < quantity)
                throw new InvalidOperationException("Not enough stock available.");

            // Update product stock quantity
            product.StockQuantity -= quantity;
            _productRepository.UpdateProduct(product);

            // Log the stock-out transaction
            var transaction = new InventoryTransaction
            {
                ProductID = productId,
                Quantity = quantity,
                TransactionType = "OUT", // or any other identifier for "Stock-Out"
                TransactionDate = DateTime.Now
            };
            _transactionRepository.AddTransaction(transaction);
        }
    }
}
*/