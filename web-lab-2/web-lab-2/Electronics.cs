using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Electronics : Product
{
    public string WarrantyPeriod;
    public void setWarrantyPeriod(string WarrantyPeriod2)
    {
        WarrantyPeriod = WarrantyPeriod2;
    }
    public string getWarrantyPeriod()
    {
        return WarrantyPeriod;
    }

    /*public override void GetProductInfo()
    {
        Console.WriteLine("$ProductName : {ProductName}  \n  ProductId : {ProductId}  \n  Price  : {Price} \n WarrantyPeriod : {WarrantyPeriod}");
    }*/

    public override void GetProductInfo()
    {
        Console.WriteLine(string.Concat("ProductName : ", getProductName(), "ProductId : ", getProductId(), "Price : ", getPrice(), "Price : ", WarrantyPeriod));
    }
}
