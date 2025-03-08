using System.Collections.Generic;
using System.Linq;
using SpendingCategorizer.Core.Models;

namespace SpendingCategorizer.Core
{
    public static class TransactionCategorizer
    {
        // Example category dictionary (fill in your own keywords)
        // Key: Category Name
        // Value: Array of keywords
        private static TransactionCatagoryLibrary catagoryLibrary = new TransactionCatagoryLibrary();
        public static List<string> GetAllCategories()
        {
            return catagoryLibrary.Categories.Select(x => x.Key).ToList();
        }
        // Public method to categorize an entire list of transactions in place
        public static void Categorize(IEnumerable<Transaction> transactions)
        {
            foreach (var transaction in transactions)
            {
                if (transaction.Description.ToLower().Contains("zel")) 
                {
                    Console.WriteLine( "got here. ");
                }
                transaction.Category = DetermineCategory(transaction.Description);
            }
        }

        // Internal method that checks each category's keywords
        private static string DetermineCategory(string description)
        {
            foreach (var kvp in catagoryLibrary.Categories)
            {
                string categoryName = kvp.Key;
                string[] keywords = kvp.Value;

                if (keywords.Any(kw => description.Contains(kw, System.StringComparison.OrdinalIgnoreCase)))
                {
                    return categoryName;
                }
            }
            return "???"; // default if none matched
        }
    }
}
