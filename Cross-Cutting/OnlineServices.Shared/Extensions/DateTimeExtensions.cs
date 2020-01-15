using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineServices.Common.Extensions
{
    public static class DateTimeExtensions
    {
        public static bool IsSameDate(this DateTime Extended, DateTime dateToCompareTo)
        {
            return ((Extended.Day == dateToCompareTo.Day) 
                && (Extended.Month == dateToCompareTo.Month) 
                && (Extended.Year == dateToCompareTo.Year));
        }
    }
}
