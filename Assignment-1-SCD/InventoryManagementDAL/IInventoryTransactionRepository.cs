using InventoryManagementDTOs;
using System.Collections.Generic;

namespace InventoryManagementDAL
{
    public interface IInventoryTransactionRepository
    {
        List<InventoryTransaction> GetAllTransactions();
        InventoryTransaction GetTransactionById(int id);
        void AddTransaction(InventoryTransaction transaction);
        void UpdateTransaction(InventoryTransaction transaction);
        void DeleteTransaction(int id);
    }
}
