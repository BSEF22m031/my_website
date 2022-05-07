using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Groceries : Product
{
    public string ExpiryDate;
    public void setExpiryDate(string ExpiryDate2)
    {
        ExpiryDate = ExpiryDate2;
    }
    public string getExpiryDate()
    {
        return ExpiryDate;
    }

    /*public override void GetProductInfo()
    {
        Console.WriteLine("$ProductName : {ProductName}  \n  ProductId : {ProductId}  \n  Price  : {Price} \n ExpiryDate : {ExpiryDate}");
    }*/
    public override void GetProductInfo()
    {
        Console.WriteLine(string.Concat("ProductName : ", getProductName(), "ProductId : ", getProductId(), "Price : ", getPrice(), "ExpiryDate : ", ExpiryDate));
    }
}
