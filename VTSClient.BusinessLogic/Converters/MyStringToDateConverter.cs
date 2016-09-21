using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTSClient.BusinessLogic.Converters
{
    public static class MyStringToDateConverter
    {
        public static DateTime Convert(string value)
        {
            DateTime result;

            if (value != null)
            {
                var stringDate = value.Split('/');
                var day = Int32.Parse(stringDate[1]);
                var month = Int32.Parse(stringDate[0]);
                var year = Int32.Parse(stringDate[2]);
                result = new DateTime(year, month, day, 8, 0, 0);
                return result;
            }

            return new DateTime();
        }
    }
}
