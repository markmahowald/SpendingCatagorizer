using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using SpendingCategorizer.Core;
using SpendingCategorizer.Core.ImportTools;
using SpendingCategorizer.Core.Models;


namespace SpendingCategorizer.Data
{
    public class TransactionCsvService
    {
        private ChaseTransactionImporter chaseImporter = new ChaseTransactionImporter();
        private CcuTransactionImporter ccuImporter = new CcuTransactionImporter();
        // Reads transactions from a CSV file using CsvHelper
        public List<Transaction> ReadTransactions(string filePath)
        {
            var transactions = new List<Transaction>();

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                IgnoreBlankLines = true
              ,
                Delimiter = ";"
               ,
                HeaderValidated = null // to ignore missing headers validation if needed
                ,
                MissingFieldFound = null // to ignore missing fields validation if needed
                ,
                BadDataFound = null
            }))
            {
                csv.Context.RegisterClassMap<TransactionMap>();
                try
                {
                    transactions = csv.GetRecords<Transaction>().ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }

            // If you have a custom map, you can register it here. For a simple case, direct reading is fine.

            return transactions;
        }
        public List<Transaction> ReadChaseCsv(string path) 
        {
            return this.chaseImporter.Import(path);
        }
        public List<Transaction> ReadCcuCsv(string filePath) 
        {
            return this.ccuImporter.Import(filePath);
        } 
        public void WriteTransactions(string filePath, IEnumerable<Transaction> transactions)
        {
            using var writer = new StreamWriter(filePath);
            using var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                ShouldQuote = _ => true // Force quoting if you want
            });

            csv.WriteRecords(transactions);
        }
    }
}
