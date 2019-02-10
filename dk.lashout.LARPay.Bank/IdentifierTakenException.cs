using System;

namespace dk.lashout.LARPay.Bank
{
    internal class IdentifierTakenException : Exception
    {
        public string Identifier { get; }

        public IdentifierTakenException(string identifier)
        {
            Identifier = identifier;
        }
    }
}