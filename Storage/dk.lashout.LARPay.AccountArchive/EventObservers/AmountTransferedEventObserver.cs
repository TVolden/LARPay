using dk.lashout.LARPay.Accounting.Events;
using dk.lashout.LARPay.Administration;
using dk.lashout.LARPay.AccountArchive.Applications;
using System;

namespace dk.lashout.LARPay.AccountArchive.EventObservers
{
    public class AmountTransferedEventObserver : IEventObserver<AmountTransferedEvent>
    {
        private readonly AccountStates _archive;

        public AmountTransferedEventObserver(AccountStates archive)
        {
            _archive = archive ?? throw new ArgumentNullException(nameof(archive));
        }

        public void Update(AmountTransferedEvent @event)
        {
            if (@event.EventDate <= _archive.LastEventDate)
                return;

            var benefactor = _archive.GetAccount(@event.BenefactorAccountId).ValueOrDefault(null);
            var recipient = _archive.GetAccount(@event.ReceipientAccountId).ValueOrDefault(null);

            var debit = new Debit(@event.ReceipientAccountId, @event.Amount, @event.Description, @event.EventDate);
            var credit = new Credit(@event.BenefactorAccountId, @event.Amount, @event.Description, @event.EventDate);

            benefactor.AddTransaction(debit);
            recipient.AddTransaction(credit);

            _archive.LastEventDate = @event.EventDate;
        }
    }
}
