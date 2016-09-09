using MvvmCross.Platform.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace VTSClient.BusinessLogic.Converters
{
    public class StringToDateValueConverter : MvxValueConverter<string, DateTime>
    {
        protected override DateTime Convert(string value, Type targetType, object parameter, CultureInfo culture)
        {
            var stringDate = value.Split('/');
            DateTime result = new DateTime();
            result.AddDays(Int32.Parse(stringDate[1]));
            result.AddMonths(Int32.Parse(stringDate[0]));
            result.AddYears(Int32.Parse(stringDate[2]));
            result.AddHours(8);

            return result;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
