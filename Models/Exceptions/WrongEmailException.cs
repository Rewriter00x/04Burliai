using System;

namespace _01Burliai.Models.Exceptions
{
    class WrongEmailException : Exception
    {
        private static readonly string _message = "Error, email does not match regexpr";

        public WrongEmailException() : base(_message)
        {

        }
    }
}
