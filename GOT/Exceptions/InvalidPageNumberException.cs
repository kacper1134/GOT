using System;

namespace GOT.Exceptions
{
    public class InvalidPageNumberException : Exception
    {

        public InvalidPageNumberException() : base()
        {
        }

        public InvalidPageNumberException(string message) : base(message)
        {

        }

        public InvalidPageNumberException(string message, Exception inner) : base(message, inner)
        {

        }

    }
}
