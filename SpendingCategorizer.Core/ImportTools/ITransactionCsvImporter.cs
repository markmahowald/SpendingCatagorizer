using SpendingCategorizer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpendingCategorizer.Core.ImportTools
{
    public interface ITransactionCsvImporter
    {
        List<Transaction> Import(string filePath);
    }
}
