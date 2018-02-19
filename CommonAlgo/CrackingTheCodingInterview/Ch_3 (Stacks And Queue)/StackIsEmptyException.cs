using System;

namespace CommonAlgo.CrackingTheCodingInterview
{
    public class StackIsEmptyException : Exception
    {
        public StackIsEmptyException(string msg)
            : base(msg)
        {
        }
    }

    public class InvalidStackIndexException : Exception
    {
        public InvalidStackIndexException(string msg)
            : base(msg)
        {
        }
    }
}