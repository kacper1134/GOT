using System;

namespace GOT.Exceptions
{
    public class InvalidPageSizeException : Exception
    {

        public InvalidPageSizeException() : base()
        {
        }

        public InvalidPageSizeException(string message) : base(message)
        {

        }

        public InvalidPageSizeException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
