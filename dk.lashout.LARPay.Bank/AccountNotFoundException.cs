using System;

namespace dk.lashout.LARPay.Bank
{
    class AccountNotFoundException : Exception
    {
        public string Identifier { get; }
        public AccountNotFoundException(string identifier)
        {
            Identifier = identifier;
        }
    }
}
