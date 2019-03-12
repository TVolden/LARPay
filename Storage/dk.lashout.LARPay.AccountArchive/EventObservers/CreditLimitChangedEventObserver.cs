using dk.lashout.LARPay.Accounting.Events;
using dk.lashout.LARPay.Administration;

namespace dk.lashout.LARPay.AccountArchive.EventObservers
{
    public class CreditLimitChangedEventObserver : IEventObserver<CreditLimitChangedEvent>
    {
        private readonly AccountStates archive;

        public CreditLimitChangedEventObserver(AccountStates archive)
        {
            this.archive = archive ?? throw new System.ArgumentNullException(nameof(archive));
        }

        public void Update(CreditLimitChangedEvent @event)
        {
            var account = archive.GetAccount(@event.AccountId);
            if (account.HasValue())
                account.ValueOrDefault(null).creditLimit = @event.CreditLimit;
        }
    }
}
