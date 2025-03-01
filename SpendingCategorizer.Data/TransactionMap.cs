using CsvHelper.Configuration;
using SpendingCategorizer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpendingCategorizer.Data
{
    public class TransactionMap : ClassMap<Transaction>
    {

        public TransactionMap()
        {
            Map(m => m.TransactionDate)
                .Name("TransactionDate")
                .TypeConverter<MultiFormatDateTimeConverter>(); // Use the custom converter

            Map(m => m.Description);
            Map(m => m.Source);
            Map(m => m.Ammount);
            Map(m => m.Category);
        }
    }
}