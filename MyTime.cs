using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTimeNamespace 
{ 
    public class MyTime
    {
        public (string,TimeSpan) CalculateTimeDifference(string startTime, string endTime)
        {
            // Parse the time strings into DateTime objects
            DateTime start = DateTime.ParseExact(startTime, "yyyy-MM-dd HH:mm:ss", null);
            DateTime end = DateTime.ParseExact(endTime, "yyyy-MM-dd HH:mm:ss", null);

            // Calculate the time difference as a TimeSpan
            TimeSpan difference = end - start;

            // Format the time difference as a string in HH:MM:SS format
            string differenceString = difference.ToString(@"hh\:mm\:ss");
            return (differenceString, difference);
        }

        public static int CalculateTimeDifferenceInSeconds(string startTime, string endTime)
        {
            // Parse the time strings into DateTime objects
            DateTime start = DateTime.ParseExact(startTime, "yyyy-MM-dd HH:mm:ss", null);
            DateTime end = DateTime.ParseExact(endTime, "yyyy-MM-dd HH:mm:ss", null);

            // Calculate the time difference as a TimeSpan
            TimeSpan difference = end - start;
            int secondsDifference = (int)difference.TotalSeconds;

            return secondsDifference;
        }


        public static string convertTimeForSQL(string originalDateTimeText)
        {
            // SQL uses ISO8601 format yyyy-MM-ddTHH:mm:ss
            // Parse the text box value to a DateTime object
            DateTime parsedDateTime = DateTime.ParseExact(originalDateTimeText, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            // Reformat it into the ISO 8601 format (with 'T')
            string formattedDateTime = parsedDateTime.ToString("yyyy-MM-ddTHH:mm:ss");
            return formattedDateTime;
        }
    }
}
