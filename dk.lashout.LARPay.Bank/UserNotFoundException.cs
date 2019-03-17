using System;

namespace dk.lashout.LARPay.Bank
{
    class UserNotFoundException : Exception
    {
        public string Username { get; }

        public UserNotFoundException(string username) : base($"User not found. Username: {username}")
        {
            Username = username;
        }
    }
}
