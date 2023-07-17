using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using SpendingCatagorizer;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections;
using System.ComponentModel;
using System.Numerics;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;
class Program
{
    static void Main(string[] args)
    {
        // Define your categories
        var categories = new Dictionary<string, string[]>
        {

    {"Sara Business", new[] {"SARA LUCHIN", "SARA MAHOWALD", "LIVING YOGA", "LIBRARY-BELMAR", "ZOOM.US", "VENMO CASHOUT"}},
    {"Charity", new[] {"PATREON", "ROCKY MTN PBS", "PARTNERS IN HEALTH", "HEALTHIER COLORADO", "CURIOSITYSTREAM", "MAXIMUM FUN"}},
    {"Fun Money", new[] {"YUMMYS DONUT HOUSE", "3dprinter.com", "AMK GATES CAFE", "LOGAN HOUSE 15TH ST", "BLACK JACK PIZZA", "MOLLYS SPIRITS", "SQ *JOY FILL", "GOOD TIMES DR F", "MICRO CENTER", "Bang up to the Elephant", "SQ *PABLO'S COFFEE", "SQ *THE MOLECULE EFFECT", "SNARFS INSPIRED", "GRUBHUBIMPERIALDRAGON", "BOOKSHOP.ORG", "EINSTEIN BAGELS 1356", "AZUCAR BAKERY", "PARAMOUNT+", "KINDLE SVCS"}},
    {"Travel", new[] {"ROYAL CARIBBEAN CRUISES", "CSA TRAVEL PROTECTION", "SPOTHERO"}},
    {"Utilities", new[] {"MICROSOFT*SUBSCRIPTION", "APPLE.COM/BILL", "DNVRWTR SDPY"}},
    {"House Stuff", new[] {"GOODWILL LAKESIDE STORE", "TJMAXX", "MICHAELS STORES", "DOLLAR TREE", "TARGET", "AMZN Mktp US"}},
    {"Mortgage", new[] {"WF HOME MTG"}},
    {"Transportation", new[] {"PUBLIC WORKS-PRKG METR", "TD AUTO FINANCE", "KING SOOPERS 0619 FUEL", "USAA P&C"}},
    {"Travel", new[] {"ROYAL CARIBBEAN CRUISES", "CSA TRAVEL PROTECTION"}},
    {"Groceries", new[] {"SQ *JOY FILL", "SAFEWAY", "KING SOOPERS", "SPROUTS FARMERS MAR", "VIET HOA SUPERMARKET"}},
    {"Health", new[] {"OVERLAND ANIMAL HOSPITAL"}},
    {"Investments", new[] {"VANGUARD BUY"}},
    {"Cats", new[] {"OVERLAND ANIMAL HOSPITAL", "CHEWY.COM"}},
    {"Gifts", new[] {"BARNES &amp; NOBLE", "HARBOR FREIGHT TOOLS"}},
    {"Lifestyle", new[] {"GOOGLE *replika", "COLPARS HOBBYTOWN", "LATE FEE"}},
    {"Solar", new[] {"GOODLEAP 14"}},
    {"Income", new[] {"GATES CORP"}},
    {"???", new[] {""}}
};


        // Function to categorize transactions
        Func<string, string> categorizeTransaction = (description) =>
        {
            foreach (var category in categories)
            {
                if (category.Value.Any(keyword => description.Contains(keyword, StringComparison.OrdinalIgnoreCase)))
                {
                    return category.Key;
                }
            }

            return "???";
        };

        // Directory to process files from

        // Get CSV files in directory that do not start with "categorized_transactions"
        var files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.csv")
            .Where(path => !Path.GetFileName(path).StartsWith("categorized_transactions"));

        foreach (var filePath in files)
        {
            var transactions = new List<Transaction>();

            // Load the data from CSV
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                transactions = csv.GetRecords<Transaction>().ToList();
            }

            // Categorize each transaction
            foreach (var transaction in transactions)
            {
                transaction.Category = categorizeTransaction(transaction.Description);
            }

            // Save the categorized data to a new  CSV file
            var newFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"categorized_{Path.GetFileName(filePath)}");
            using (var writer = new StreamWriter(newFilePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(transactions);
            }
        }
    }
}