using dk.lashout.LARPay.Accounting.Events;
using dk.lashout.LARPay.Administration;

namespace dk.lashout.LARPay.AccountArchive.EventObservers
{
    public class CreditLimitChangedEventObserver : IEventObserver<CreditLimitChangedEvent>
    {
        private readonly AccountStates _archive;

        public CreditLimitChangedEventObserver(AccountStates archive)
        {
            _archive = archive ?? throw new System.ArgumentNullException(nameof(archive));
        }

        public void Update(CreditLimitChangedEvent @event)
        {
            if (@event.EventDate <= _archive.LastEventDate)
                return;

            var account = _archive.GetAccount(@event.AccountId);
            if (account.HasValue())
                account.ValueOrDefault(null).creditLimit = @event.CreditLimit;

            _archive.LastEventDate = @event.EventDate;
        }
    }
}
