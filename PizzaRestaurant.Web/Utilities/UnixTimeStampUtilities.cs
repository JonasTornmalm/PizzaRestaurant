using Humanizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaRestaurant.Web.Utilities
{
    public class UnixTimeStampUtilities
    {
        public static string UnixTimeStampToString(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            var createdDateTime = dtDateTime.AddSeconds(unixTimeStamp).AddHours(1);
            var dateTimeString = createdDateTime.ToString("dd/MM/yyyy HH:mm:ss");
            return dateTimeString;
        }

        public static string UnixTimeToRelativeTime(double unixTimeStamp)
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            var createdDateTime = dtDateTime.AddSeconds(unixTimeStamp);
            var dateTimeNow = DateTime.UtcNow;
            TimeSpan diff = dateTimeNow.Subtract(createdDateTime);
            var totalHoursDiff = diff.TotalHours;
            return dateTimeNow.AddHours(-totalHoursDiff).Humanize();
        }
    }
}
