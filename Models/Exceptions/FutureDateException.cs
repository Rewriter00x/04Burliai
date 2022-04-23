using System;

namespace _01Burliai.Models.Exceptions
{
    class FutureDateException : Exception
    {
        public FutureDateException(DateTime? selected) : base("Selected date is " + Math.Abs((DateTime.Today - selected)?.TotalDays ?? 0.0) + " days ahead")
        {

        }
    }
}
