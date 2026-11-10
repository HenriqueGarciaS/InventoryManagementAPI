using System.ComponentModel;

namespace InventoryManagementAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long Quantity { get; set; }
        public Category Category { get; set; }
        public Supplier? Supplier { get; set; } 
    }
}
