using games_r_us_source.Data;
using games_r_us_source.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace groceries_webshop.Data
{
    public class SampleData
    {
        public static void Create(AppDbContext database)
        {
            // If no accounts are found, add sample accounts
            if (!database.Accounts.Any())
            {
                PopulateTableFromJson<Account>("sample-accounts.json", database.Accounts);

                // SaveChanges is necessary as both Listings and Bids depend on Accounts
                database.SaveChanges();
            }

            if (!database.Listings.Any())
            {
                PopulateTableFromJson<Listing>("sample-listings.json", database.Listings);
                database.SaveChanges();
            }

            if (!database.Bids.Any())
            {
                PopulateTableFromJson<Bid>("sample-bids.json", database.Bids);
                database.SaveChanges();
            }
        }

        // Using generics, pass the data type along with the json file name and the table
        // "where T : class" is required by EF Core to correctly recognize the data type of each table
        private static void PopulateTableFromJson<T>(string jsonFileName, DbSet<T> table) where T : class 
        {
            string filePath = "./Data/" + jsonFileName;
            string textFileRaw = File.ReadAllText(filePath);

            // Get an array of the passed data type containing the deserialized json data
            T[] entries = JsonSerializer.Deserialize<T[]>(textFileRaw);

            foreach (var entry in entries)
            {
                table.Add(entry);
            }
        }

    }
}
