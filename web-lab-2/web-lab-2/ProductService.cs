using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Formats.Asn1;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
//using ThirdParty.Json.LitJson;
//using static System.Net.WebRequestMethods;

public class ProductDetail
{
    [JsonPropertyName("idddddddddddd")]

    public int id { get; set; }
    [JsonIgnore]
    public string name { get; set; }   
    public string description { get; set; }


}
class ProductService
{

    public void fileOperation()
    {
        if (!File.Exists("myfile.txt"))
        {
            using (StreamWriter writer1 = new StreamWriter("myfile.txt"))
            {
                writer1.WriteLine("hi");
            }
        }
        else
        {
            using (StreamWriter writer1 = new StreamWriter("myfile.txt", true))
            {
                ProductDetail productDetail=new ProductDetail();    
                productDetail.id = 1;
                productDetail.name = "book";
                productDetail.description = "this is self help book";
                string data = JsonSerializer.Serialize(productDetail);
                writer1.WriteLine(data);
            }
        }
        using(StreamReader streamReader=new StreamReader("myfile.txt"))
        {
            string data= streamReader.ReadLine();
            ProductDetail productDetail = JsonSerializer.Deserialize<ProductDetail>(data);
            Console.WriteLine(productDetail.id);
            Console.WriteLine(productDetail.name);
            Console.WriteLine(productDetail.description);
            /*string line;
            while((line = streamReader.ReadLine()) != null)
            {
                *//*string[] words = line.Split(',');
                for (int i = 0; i < words.Length; i++)
                {
                    if (words[i] == "200")
                    {
                        Console.WriteLine(words[i]);
                        Console.WriteLine(words[++i]);
                        Console.WriteLine(words[++i]);
                        break;
                    }
                }*//*
            }*/
        }

    }
    
    /*string[] words = line.Split(' ');
    for (int i = 0; i<words.Length; i++)
    {
       Console.WriteLine(fruits[i]);
    }*/

}






























