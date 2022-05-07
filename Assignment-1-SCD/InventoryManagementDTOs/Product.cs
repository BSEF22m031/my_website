using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementDTOs
{
   

    public class Product
    {
        [Key]
        public int ProductID { get; set; } 

        [Required]
        [StringLength(255)] 
        public string ProductName { get; set; } 

        [Required]
        public string Category { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int StockQuantity { get; set; }


        [Required]
        public int SupplierID { get; set; }

        public Supplier Supplier { get; set; } 

    }

}
