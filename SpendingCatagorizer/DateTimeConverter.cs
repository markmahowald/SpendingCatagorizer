using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using CsvHelper;

public class DateTimeConverter : DefaultTypeConverter
{
    public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
    {
        if (string.IsNullOrEmpty(text))
        {
            return DateTime.MinValue;  // or however you want to handle nulls
        }
        return base.ConvertFromString(text, row, memberMapData);
    }
}
