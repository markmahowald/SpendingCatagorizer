using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpendingCatagorizer
{
    public class ShortDateTypeConverter : DefaultTypeConverter
    {
        public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
            if (value is DateTime date)
            {
                return date.ToShortDateString();
            }

            return base.ConvertToString(value, row, memberMapData);
        }
    }

}
