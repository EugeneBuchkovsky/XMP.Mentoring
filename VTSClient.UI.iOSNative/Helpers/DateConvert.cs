using Foundation;
using System;
using System.Collections.Generic;
using System.Text;

namespace VTSClient.UI.iOSNative.Helpers
{
    public static class DateConvert
    {
        public static DateTime ToDateTime(this NSDate date)
        {
            DateTime reference = TimeZone.CurrentTimeZone.ToLocalTime(
            new DateTime(2001, 1, 1, 0, 0, 0));
            return reference.AddSeconds(date.SecondsSinceReferenceDate);
        }
    }
}
