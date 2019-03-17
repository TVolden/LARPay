using System;

namespace dk.lashout.LARPay.Bank
{
    internal class IdTakenException : Exception
    {
        public string Identifier { get; }

        public IdTakenException(string identifier)
        {
            Identifier = identifier;
        }
    }
}