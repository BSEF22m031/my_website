using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace InventoryManagementDAL
{
    public class InventoryManagementDbContextFactory : IDesignTimeDbContextFactory<InventoryManagementDbContext>
    {
        public InventoryManagementDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<InventoryManagementDbContext>();
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=InventoryDB;Integrated Security=True;");

            return new InventoryManagementDbContext(optionsBuilder.Options);
        }
    }
}
