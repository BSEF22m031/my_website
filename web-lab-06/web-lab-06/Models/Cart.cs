namespace web_lab_06.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        public User User { get; set; }
        public Menu Item { get; set; }
        public int Quantity { get; set; }
    }
}
