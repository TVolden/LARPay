using dk.lashout.LARPay.Accounting.Events;
using dk.lashout.LARPay.Administration;

namespace dk.lashout.LARPay.Archives.EventObservers
{
    public class CreditLimitChangedEventObserver : IEventObserver<CreditLimitChangedEvent>
    {
        private readonly AccountArchive archive;

        public CreditLimitChangedEventObserver(AccountArchive archive)
        {
            this.archive = archive ?? throw new System.ArgumentNullException(nameof(archive));
        }

        public void Update(CreditLimitChangedEvent newEvent)
        {
            var account = archive.GetAccount(newEvent.AccountId);
            if (account.HasValue())
                account.ValueOrDefault(null).creditLimit = newEvent.CreditLimit;
        }
    }
}
