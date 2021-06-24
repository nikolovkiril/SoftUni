using Microsoft.VisualBasic;
using System;

namespace DefiningClasses
{
    public class DateModifier
    {
        public static double GetDifferenceDaysBetween(string dateOne, string dateTwo)
        {
            DateTime dateTimeOne = DateTime.Parse(dateOne);
            DateTime dateTimeTwo = DateTime.Parse(dateTwo);
            double daysDifference = Math.Abs((dateTimeOne - dateTimeTwo).TotalDays);
            return daysDifference;
        }
    }
}
