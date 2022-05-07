using InventoryManagementDTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace InventoryManagementDAL
{
    public class InventoryTransactionRepository : IInventoryTransactionRepository
    {
        private readonly InventoryManagementDbContext _context;

        public InventoryTransactionRepository(InventoryManagementDbContext context)
        {
            _context = context;
        }

        public List<InventoryTransaction> GetAllTransactions()
        {
            return _context.InventoryTransactions.Include(t => t.Product).ToList();
        }

        public InventoryTransaction GetTransactionById(int id)
        {
            return _context.InventoryTransactions.Include(t => t.Product).FirstOrDefault(t => t.TransactionID == id);
        }

        public void AddTransaction(InventoryTransaction transaction)
        {
            _context.InventoryTransactions.Add(transaction);
            _context.SaveChanges();
        }

        public void UpdateTransaction(InventoryTransaction transaction)
        {
            _context.InventoryTransactions.Update(transaction);
            _context.SaveChanges();
        }

        public void DeleteTransaction(int id)
        {
            var transaction = _context.InventoryTransactions.Find(id);
            if (transaction != null)
            {
                _context.InventoryTransactions.Remove(transaction);
                _context.SaveChanges();
            }
        }
    }
}
