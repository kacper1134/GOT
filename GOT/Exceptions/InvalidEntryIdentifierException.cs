using System;

namespace GOT.Exceptions
{
    public class InvalidEntryIdentifierException : Exception
    {

        public InvalidEntryIdentifierException() : base()
        {
        }

        public InvalidEntryIdentifierException(string message) : base(message)
        {

        }

        public InvalidEntryIdentifierException(string message, Exception inner) : base(message, inner)
        {

        }

    }
}
