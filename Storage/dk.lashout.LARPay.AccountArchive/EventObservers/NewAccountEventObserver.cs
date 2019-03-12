using dk.lashout.LARPay.Accounting.Events;
using dk.lashout.LARPay.Administration;
using dk.lashout.LARPay.AccountArchive.Applications;

namespace dk.lashout.LARPay.AccountArchive.EventObservers
{
    public class AccountCreatedEventObserver : IEventObserver<AccountCreatedEvent>
    {
        private readonly AccountStates _archive;

        public AccountCreatedEventObserver(AccountStates archive)
        {
            _archive = archive ?? throw new System.ArgumentNullException(nameof(archive));
        }

        public void Update(AccountCreatedEvent @event)
        {
            var account = new Account(@event.CustomerId);
            _archive.AddAccount(@event.AccountId, account);
        }
    }
}
