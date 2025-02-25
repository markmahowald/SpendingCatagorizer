using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpendingCatagorizer
{
    public class TransactionMap : ClassMap<Transaction>
    {
        public TransactionMap()
        {
            Map(m => m.TransactionDate).Name("TransactionDate").TypeConverterOption.Format("MM/dd/yyyy"); 
            Map(m => m.Description);
            Map(m => m.Source);
            Map(m => m.Ammount);
            Map(m => m.Category);
        }
    }

}
