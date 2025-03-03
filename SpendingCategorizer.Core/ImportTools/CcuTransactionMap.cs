using CsvHelper.Configuration;
using SpendingCategorizer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpendingCategorizer.Core.ImportTools
{
    internal class CcuTransactionMap : ClassMap<CcuTransaction>
    {
        public CcuTransactionMap()
        {
            Map(m => m.AccountName).Name("Account Name");
            Map(m => m.ProcessedDate).Name("Processed Date")
                    .TypeConverter<MultiFormatDateTimeConverter>();
            Map(m => m.Description);
            Map(m => m.CheckNumber).Name("Check Number");
            Map(m => m.CreditOrDebit).Name("Credit or Debit");
            Map(m => m.Amount);

                
        }

    }
}


