using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SpendingCategorizer.Core.ImportTools
{
    internal class CcuTransaction
    {
        public string AccountName { get; set; }
        public DateTime ProcessedDate { get; set; }
        public string Description { get; set; }
        public string CheckNumber { get; set; }
        public string CreditOrDebit { get; set; }
        public float? Amount { get; set; }


    }
}
