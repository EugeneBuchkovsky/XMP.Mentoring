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
            var stringDate = value.Split('/');
            var a = Int32.Parse(stringDate[1]);
            var a1 = Int32.Parse(stringDate[0]);
            var a2 = Int32.Parse(stringDate[2]);
            var result = new DateTime(a2, a1, a, 8, 0, 0);

            return result;
        }
    }
}
