using dk.lashout.LARPay.Accounting.Events;
using dk.lashout.LARPay.Administration;
using dk.lashout.LARPay.Archives.Applications;

namespace dk.lashout.LARPay.Archives.EventObservers
{
    public class NewAccountEventObserver : IEventObserver<NewAccountEvent>
    {
        private readonly AccountArchive _archive;

        public NewAccountEventObserver(AccountArchive archive)
        {
            _archive = archive ?? throw new System.ArgumentNullException(nameof(archive));
        }

        public void Update(NewAccountEvent newEvent)
        {
            var account = new Account(newEvent.CustomerId);
            _archive.AddAccount(newEvent.AccountId, account);
        }
    }
}
