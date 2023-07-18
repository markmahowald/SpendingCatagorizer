using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpendingCatagorizer
{
    public class Transaction
    {

        public DateTime? TransactionDate { get; set; }
        public string? Description {get;set;}
        public string? Source { get; set; }
        public float? Ammount { get; set; }

        public string? Category { get; set; }
        public Transaction(DateTime transactionDate, string description, string source, float ammount, string category = "")
        {
            TransactionDate = transactionDate;
            Description = description;
            Source = source;
            Ammount = ammount;
            Category = category;    
        }
        public Transaction()
        {

        }
    }

}
