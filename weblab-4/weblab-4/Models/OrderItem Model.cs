namespace weblab_4.Models
{
    public class OrderItem_Model
    {
        public string FoodItem { get; set; }
        public int quantity { get; set; }


        OrderItem_Model(string FoodItem1, int quantity1)
        {
            FoodItem = FoodItem1;
            quantity= quantity1;
        }
    }
}
