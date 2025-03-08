using CsvHelper.Configuration;
using CsvHelper;
using SpendingCategorizer.Core.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpendingCategorizer.Core.ImportTools
{
    public class CcuTransactionImporter : ITransactionCsvImporter
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
                List<string> descriptionsToReject = new List<string>() { "WITHDRAWAL ACH CHASE CREDIT CRD TYPE" };
                csv.Context.RegisterClassMap<CcuTransactionMap>();
                try
                {
                    var ccuTransactions = csv.GetRecords<CcuTransaction>().ToList();
                    transactions.AddRange(
                        ccuTransactions
                            .Where(item => !descriptionsToReject.Any(x => item.Description.Contains(x)))
                            .Select(item => ConvertToTransaction(item))
                    );


                }
                catch (Exception)
                {

                    throw;
                }
                return transactions;
            }

        }
        private Transaction ConvertToTransaction(CcuTransaction x)
        {
            //import data
            Transaction t = new Transaction();
            t.TransactionDate = x.ProcessedDate;
            t.Description = x.Description+x.CheckNumber;
            t.Ammount =(x.CreditOrDebit == "Credit"? (x.Amount *-1):  (x.Amount));
            t.Category = "";
            t.Source = "CCU";
            return t;

        }
    }
}
