using CsvHelper.Configuration;
using SpendingCategorizer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpendingCategorizer.Core.ImportTools
{
    public  class ChaseTransactionMap : ClassMap<ChaseTransaction>
    {
        public ChaseTransactionMap() 
        {
            Map(m => m.TransactionDate).Name("Transaction Date")
                .TypeConverter<MultiFormatDateTimeConverter>();
            Map(m => m.PostDate).Name("Post Date")
                .TypeConverter<MultiFormatDateTimeConverter>();
            Map(m => m.Description).Name("Description");
            Map(m => m.Category).Name("Category");  
            Map(m => m.Type).Name("Type");
            Map(m => m.Amount).Name("Amount");
            Map(m => m.Memo).Name("Memo");

            
        }
        //Transaction Date	Post Date	Description	Category	Type	Amount	Memo


    }
}


//public TransactionMap()
//{
//    Map(m => m.TransactionDate)
//        .Name("TransactionDate")
//        .TypeConverter<MultiFormatDateTimeConverter>(); // Use the custom converter

//    Map(m => m.Description);
//    Map(m => m.Source);
//    Map(m => m.Ammount);
//    Map(m => m.Category);
//}