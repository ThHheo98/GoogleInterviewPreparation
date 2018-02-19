using System;

namespace CommonAlgo.CrackingTheCodingInterview
{
    public class FullStackException : Exception
    {
        public FullStackException(string msg)
            : base(msg)
        {
        }
    }
}