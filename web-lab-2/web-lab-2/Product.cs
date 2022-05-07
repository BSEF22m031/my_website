using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Product
    {
        private int ProductId;
        private string ProductName;
        private int Price;
        public void setProductId(int ProductId2)
        {
            ProductId = ProductId2;
        }
        public void setProductName(string ProductName2)
        {
            ProductName = ProductName2;
        }
        public void setPrice(int Price2)
        {
            Price = Price2;
        }
        public int getProductId()
        {
            return ProductId;
        }
        public int getPrice()
        {
            return Price;
        }
        public string getProductName()
        {
            return ProductName;
        }
        /*public virtual void GetProductInfo()
        {
            Console.WriteLine("$ProductName : {ProductName}  \n  ProductId : {ProductId}  \n  Price  : {Price}");
        }*/
        public virtual void GetProductInfo()
        {
            Console.WriteLine(string.Concat("ProductName : ", ProductName, "ProductId : ", ProductId, "Price : ", Price));
        }
    }

