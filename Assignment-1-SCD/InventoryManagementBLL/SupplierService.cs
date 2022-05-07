using InventoryManagementDTOs;
using InventoryManagementDAL;
using System;
using System.Linq;

namespace InventoryManagementBLL
{
    public class SupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IProductRepository _productRepository;

        // Dependency Injection
        public SupplierService(ISupplierRepository supplierRepository, IProductRepository productRepository)
        {
            _supplierRepository = supplierRepository;
            _productRepository = productRepository;
        }

        // Add Supplier 
        public void AddSupplier(Supplier supplier)
        {
            if (supplier == null) throw new ArgumentNullException(nameof(supplier));

            
            // Ensure SupplierName is unique
            if (_supplierRepository.GetAllSuppliers().Any(s => s.SupplierName == supplier.SupplierName))
                throw new InvalidOperationException("Supplier name must be unique.");

            // Validate Contact Number
            if (supplier.ContactNumber.Length < 10)
                throw new InvalidOperationException("Contact number must be at least 10 digits.");

            // Add supplier to database
            _supplierRepository.AddSupplier(supplier);
        }

        // Update Supplier 
        public void UpdateSupplier(Supplier supplier)
        {
            if (supplier == null) throw new ArgumentNullException(nameof(supplier));

            var existingSupplier = _supplierRepository.GetSupplierById(supplier.SupplierID);
            if (existingSupplier == null) throw new InvalidOperationException("Supplier does not exist.");

            // Ensure SupplierName is unique
            if (_supplierRepository.GetAllSuppliers().Any(s => s.SupplierName == supplier.SupplierName && s.SupplierID != supplier.SupplierID))
                throw new InvalidOperationException("Supplier name must be unique.");

            // Update supplier details
            existingSupplier.SupplierName = supplier.SupplierName;
            existingSupplier.ContactNumber = supplier.ContactNumber;

            _supplierRepository.UpdateSupplier(existingSupplier);
        }

        // Delete Supplier 
        public void DeleteSupplier(int supplierId)
        {
            var supplier = _supplierRepository.GetSupplierById(supplierId);
            if (supplier == null) throw new InvalidOperationException("Supplier not found.");

            // Check if any products are linked to the supplier
            if (_productRepository.GetAllProducts().Any(p => p.SupplierID == supplierId))
                throw new InvalidOperationException("Cannot delete supplier. Products are linked to this supplier.");

            _supplierRepository.DeleteSupplier(supplierId);
        }
        public List<Supplier> GetAllSuppliers()
        {
            List<Supplier> suppliers = _supplierRepository.GetAllSuppliers();
            return suppliers;
        }
    }
}
