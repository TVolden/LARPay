using System;

namespace dk.lashout.LARPay.Accounting.Exceptions
{
    public class AccountNotFoundException : Exception
    {
        public Guid AccountId { get; }

        public AccountNotFoundException(Guid accountId) : this(accountId, "Account not found.") { }

        public AccountNotFoundException(Guid accountId, string message) : base(message + $" AccountId: { accountId}")
        {
            AccountId = accountId;
        }
    }
}
