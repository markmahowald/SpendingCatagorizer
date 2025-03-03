using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  SpendingCategorizer.Core.ImportTools

{
    public class MultiFormatDateTimeConverter : ITypeConverter
    {
        private readonly string[] dateFormats = new[]
        {
        "yyyy-MM-dd", "MM/dd/yyyy", "dd-MM-yyyy", "M/d/yy"
    };

        public object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (DateTime.TryParseExact(text, dateFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
            {
                return date;
            }
            throw new TypeConverterException(this, memberMapData, text, row.Context);
        }

        public string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
            return ((DateTime)value).ToString("yyyy-MM-dd"); // Default format for writing
        }
    }
}