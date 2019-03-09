using System;

namespace dk.lashout.LARPay.Bank
{
    class CustomerNotFoundException : Exception
    {
        public string Username { get; }
        public CustomerNotFoundException(string username)
        {
            Username = username;
        }
    }
}
