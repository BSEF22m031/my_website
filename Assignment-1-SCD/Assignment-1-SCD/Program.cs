using InventoryManagementDTOs;
using InventoryManagementDAL;
using InventoryManagementBLL;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment_1_SCD
{
    

    class Program
    {
        private static IProductRepository _productRepository;
        private static ISupplierRepository _supplierRepository;
        private static IInventoryTransactionRepository _inventoryTransactionRepository;
        private static ProductService _productService;
        private static SupplierService _supplierService;
        private static StockTransactionService _stockTransactionService;
        private static InventoryAnalysisService _inventoryAnalysisService;
        private static ProductSearchService _productSearchService;


        static void Main(string[] args)
        {
                // Set up Dependency Injection
                var serviceProvider = new ServiceCollection()
                    .AddDbContext<InventoryManagementDbContext>(options =>
                        options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=InventoryDB;Integrated Security=True;")) 
                    .AddScoped<IProductRepository, ProductRepository>()
                    .AddScoped<ISupplierRepository, SupplierRepository>()
                    .AddScoped<IInventoryTransactionRepository, InventoryTransactionRepository>()
                    .AddScoped<ProductService>()
                    .AddScoped<SupplierService>()
                    .AddScoped<StockTransactionService>()
                    .AddScoped<InventoryAnalysisService>()
                    .AddScoped<ProductSearchService>()
                    .BuildServiceProvider();

                _productRepository = serviceProvider.GetService<IProductRepository>();
                _supplierRepository = serviceProvider.GetService<ISupplierRepository>();
                _inventoryTransactionRepository = serviceProvider.GetService<IInventoryTransactionRepository>();
                _productService = serviceProvider.GetService<ProductService>();
                _supplierService = serviceProvider.GetService<SupplierService>();
                _stockTransactionService = serviceProvider.GetService<StockTransactionService>();
                _inventoryAnalysisService = serviceProvider.GetService<InventoryAnalysisService>();
                _productSearchService = serviceProvider.GetService<ProductSearchService>();


                while (true)
            {
                ShowMenu();
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ListProducts();
                        break;
                    case "2":
                        AddProduct();
                        break;
                    case "3":
                        UpdateProduct();
                        break;
                    case "4":
                        DeleteProduct();
                        break;
                    case "5":
                        ProcessInventoryTransaction();
                        break;
                    case "6":
                        ViewStockLevels();
                        break;
                    case "7":
                        ViewLowStockAlerts();
                        break;
                    case "8":
                        SearchProducts();
                        break;
                    case "9":
                        Console.WriteLine("Exiting...");
                        return;
                    case "11":
                        AddSupplier();
                        return;
                    case "12":
                        ListSuppliers();
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        // Display Menu
        static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("Inventory Management System");
            Console.WriteLine("1. List all products (with supplier details)");
            Console.WriteLine("2. Add a new product");
            Console.WriteLine("3. Update an existing product");
            Console.WriteLine("4. Delete a product");
            Console.WriteLine("5. Process inventory transaction (IN/OUT)");
            Console.WriteLine("6. View stock levels");
            Console.WriteLine("7. View low-stock alerts");
            Console.WriteLine("8. Search products");
            Console.WriteLine("11. Add a new Supplier (with supplier details)");
            Console.WriteLine("12. list all Supplier (with supplier details)");
            Console.WriteLine("9. Exit");
            Console.Write("Enter your choice: ");
        }

        // List all products with supplier details
        static void ListProducts()
        {
            var products = _productRepository.GetAllProducts();
            foreach (var product in products)
            {
                Console.WriteLine($"Product ID: {product.ProductID}, Name: {product.ProductName}, Category: {product.Category}, " +
                                  $"Price: {product.Price}, Stock: {product.StockQuantity}, Supplier: {product.Supplier.SupplierName}");
            }
            Console.WriteLine("Press any key to return to the menu.");
            Console.ReadKey();
        }

        // Add a new product
        static void AddProduct()
        {
            Console.Write("Enter Product Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Category: ");
            string category = Console.ReadLine();
            Console.Write("Enter Price: ");
            decimal price = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Enter Stock Quantity: ");
            int stockQuantity = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Supplier ID: ");
            int supplierId = Convert.ToInt32(Console.ReadLine());

            var product = new Product
            {
                ProductName = name,
                Category = category,
                Price = price,
                StockQuantity = stockQuantity,
                SupplierID = supplierId
            };

            try
            {
                _productService.AddProduct(product);
                Console.WriteLine("Product added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.WriteLine("Press any key to return to the menu.");
            Console.ReadKey();
        }

        static void AddSupplier()
        {
            
            Console.Write("Enter Supplier Name: ");
            string supplierName = Console.ReadLine();
            Console.Write("Enter Contact Phone: ");
            string contactPhone = Console.ReadLine();

            var supplier = new Supplier
            {
                
                SupplierName = supplierName,
                ContactNumber = contactPhone
            };

            try
            {
                _supplierService.AddSupplier(supplier);
                Console.WriteLine("Supplier added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("Press any key to return to the menu.");
            Console.ReadKey();
        }

        static void ListSuppliers()
        {
            var suppliers = _supplierService.GetAllSuppliers();
            foreach (var supplier in suppliers)
            {
                Console.WriteLine($"Supplier ID: {supplier.SupplierID}, Name: {supplier.SupplierName}, " +
                  $"Contact Number: {supplier.ContactNumber}");

            }
            Console.WriteLine("Press any key to return to the menu.");
            Console.ReadKey();
        }

        static void UpdateProduct()
        {
            Console.Write("Enter Product ID to update: ");
            int productId = Convert.ToInt32(Console.ReadLine());

            var existingProduct = _productRepository.GetProductById(productId);
            if (existingProduct == null)
            {
                Console.WriteLine("Product not found.");
                Console.ReadKey();
                return;
            }

            Console.Write("Enter new Product Name (leave blank to keep current): ");
            string name = Console.ReadLine();
            Console.Write("Enter new Category (leave blank to keep current): ");
            string category = Console.ReadLine();
            Console.Write("Enter new Price (leave blank to keep current): ");
            string priceInput = Console.ReadLine();
            Console.Write("Enter new Stock Quantity (leave blank to keep current): ");
            string stockInput = Console.ReadLine();

            existingProduct.ProductName = string.IsNullOrWhiteSpace(name) ? existingProduct.ProductName : name;
            existingProduct.Category = string.IsNullOrWhiteSpace(category) ? existingProduct.Category : category;
            existingProduct.Price = string.IsNullOrWhiteSpace(priceInput) ? existingProduct.Price : Convert.ToDecimal(priceInput);
            existingProduct.StockQuantity = string.IsNullOrWhiteSpace(stockInput) ? existingProduct.StockQuantity : Convert.ToInt32(stockInput);

            try
            {
                _productService.UpdateProduct(existingProduct);
                Console.WriteLine("Product updated successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.WriteLine("Press any key to return to the menu.");
            Console.ReadKey();
        }

        // Delete a product
        static void DeleteProduct()
        {
            Console.Write("Enter Product ID to delete: ");
            int productId = Convert.ToInt32(Console.ReadLine());

            try
            {
                _productService.DeleteProduct(productId);
                Console.WriteLine("Product deleted successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.WriteLine("Press any key to return to the menu.");
            Console.ReadKey();
        }

        // Process Inventory Transaction 
        static void ProcessInventoryTransaction()
        {
            Console.Write("Enter Product ID: ");
            int productId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Quantity (positive for IN, negative for OUT): ");
            int quantity = Convert.ToInt32(Console.ReadLine());

            try
            {
                if (quantity > 0)
                {
                    _stockTransactionService.StockIn(productId, quantity);
                    Console.WriteLine("Stock In transaction processed successfully!");
                }
                else
                {
                    _stockTransactionService.StockOut(productId, -quantity);
                    Console.WriteLine("Stock Out transaction processed successfully!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.WriteLine("Press any key to return to the menu.");
            Console.ReadKey();
        }

        // View stock levels
        static void ViewStockLevels()
        {
            var products = _productRepository.GetAllProducts();
            foreach (var product in products)
            {
                Console.WriteLine($"Product: {product.ProductName}, Stock Level: {product.StockQuantity}");
            }
            Console.WriteLine("Press any key to return to the menu.");
            Console.ReadKey();
        }

        // View low-stock alerts
        static void ViewLowStockAlerts()
        {
            var lowStockProducts = _inventoryAnalysisService.GetLowStockProducts();
            if (lowStockProducts.Count > 0)
            {
                foreach (var product in lowStockProducts)
                {
                    Console.WriteLine($"Low stock alert: {product.ProductName}, Stock Level: {product.StockQuantity}");
                }
            }
            else
            {
                Console.WriteLine("No low-stock products found.");
            }
            Console.WriteLine("Press any key to return to the menu.");
            Console.ReadKey();
        }

        // Search products by name, category, or supplier
        static void SearchProducts()
        {
            Console.Write("Enter search term: ");
            string searchTerm = Console.ReadLine();

            var products = _productSearchService.SearchProducts(searchTerm);
            foreach (var product in products)
            {
                Console.WriteLine($"Product: {product.ProductName}, Category: {product.Category}, Supplier: {product.Supplier.SupplierName}, Stock: {product.StockQuantity}");
            }
            Console.WriteLine("Press any key to return to the menu.");
            Console.ReadKey();
        }
    }

}
