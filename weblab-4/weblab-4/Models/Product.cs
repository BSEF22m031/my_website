namespace weblab_4.Models
{
    public class Product
    {
       public int Id { get; set; }
        public string Name { get; set; }
        public float price { get; set; }

        public List<Product> getProduct()
        {
            List<Product> products= new List<Product>();
            Product product = new Product()
            {
                Id = 10,
                Name = "car",
                price = 1000000
            };
            Product product1 = new Product()
            {
                Id = 20,
                Name = "bike",
                price = 100000
            };
            products.Add(product);
            products.Add(product1);
            return products;
        }
    }
}
