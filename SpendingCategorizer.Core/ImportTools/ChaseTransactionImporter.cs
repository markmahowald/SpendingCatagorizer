using CsvHelper;
using CsvHelper.Configuration;
using SpendingCategorizer.Core.Models;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpendingCategorizer.Core.ImportTools
{
    public class ChaseTransactionImporter : ITransactionCsvImporter
    {
        public List<Transaction> Import(string filePath)
        {
            var transactions = new List<Transaction>();

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                IgnoreBlankLines = true
              ,
                Delimiter = ","
               ,
                HeaderValidated = null // to ignore missing headers validation if needed
                ,
                MissingFieldFound = null // to ignore missing fields validation if needed
                ,
                BadDataFound = null
            }))
            {
                csv.Context.RegisterClassMap<ChaseTransactionMap>();
                try
                {
                    List<ChaseTransaction> chaseTransactions = csv.GetRecords<ChaseTransaction>().ToList();

                    foreach (ChaseTransaction chaseTansaction in chaseTransactions)
                    {
                        if (chaseTansaction.Type !="Payment")
                        {
                            transactions.Add(ConvertToTransaction(chaseTansaction));
                        }
                    }


                }
                catch (Exception)
                {

                    throw;
                }
                return transactions;
            }
        }

        private Transaction ConvertToTransaction(ChaseTransaction x)
        {
            //import data
            Transaction t = new Transaction();
            t.TransactionDate = x.TransactionDate;
            t.Description = x.Description;
            t.Ammount = x.Amount*-1;
            t.Category = "";
            t.Source = "Chase";
            return t;
            
        }
    }
}
