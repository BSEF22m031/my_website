using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementDTOs
{
    

    public class InventoryTransaction
    {
        [Key]
        public int TransactionID { get; set; } 

        [Required]
        public int ProductID { get; set; } 

        [Required]
        
        public bool TransactionType { get; set; } 

        [Required]
        [Range(1, int.MaxValue)] 
        public int Quantity { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; } = DateTime.UtcNow;

        public Product Product { get; set; }
    }

   

}
