using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpendingCategorizer.Core.ImportTools
{
    public class ChaseTransaction
    {
        public DateTime TransactionDate { get; set; }
        public DateTime PostDate { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public float? Amount { get; set; }
        public string Memo { get; set; }

    }
}
