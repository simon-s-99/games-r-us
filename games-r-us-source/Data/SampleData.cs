using games_r_us_source.Data;
using games_r_us_source.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace groceries_webshop.Data
{
    public class SampleData
    {
        public static void Create(AppDbContext database)
        {
            // If no products are found, add sample products.
            //if (!database.Products.Any())
            //{
            //    string filePath = "./Data/product-data.json";
            //    string productData = File.ReadAllText(filePath);
            //    Product[] products = JsonSerializer.Deserialize<Product[]>(productData);

            //    for (int i = 0; i < products.Length; i++)
            //    {
            //        database.Products.Add(products[i]);
            //    }

            //    database.SaveChanges();
            //}
        }
    }
}
