using InventoryManagementDTOs;
using System.Collections.Generic;

namespace InventoryManagementDAL
{
    public interface ISupplierRepository
    {
        List<Supplier> GetAllSuppliers();
        Supplier GetSupplierById(int id);
        void AddSupplier(Supplier supplier);
        void UpdateSupplier(Supplier supplier);
        void DeleteSupplier(int id);
    }
}
