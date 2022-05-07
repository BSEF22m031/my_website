using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementDTOs
{
    

    public class Supplier
    {
        [Key]
        public int SupplierID { get; set; } 

        [Required]
        [StringLength(255)] 
        public string SupplierName { get; set; } 

        [Required]
        [MinLength(10)]
        public string ContactNumber { get; set; } 

        public ICollection<Product> Products { get; set; }
    }

}
