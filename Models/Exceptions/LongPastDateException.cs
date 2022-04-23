using System;

namespace _01Burliai.Models.Exceptions
{
    class LongPastDateException : Exception
    {
        public LongPastDateException(DateTime? selected) : base("Selected date is " + Math.Abs((DateTime.Today.AddYears(-135) - selected)?.TotalDays ?? 0.0) + " days behind 135 years")
        {

        }
    }
}
