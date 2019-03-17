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
            var benefactor = _archive.GetAccount(@event.BenefactorAccountId).ValueOrDefault(null);
            var recipient = _archive.GetAccount(@event.ReceipientAccountId).ValueOrDefault(null);

            var debit = new Debit(@event.ReceipientAccountId, @event.Amount, @event.Description, @event.EventTime);
            var credit = new Credit(@event.BenefactorAccountId, @event.Amount, @event.Description, @event.EventTime);

            benefactor.AddTransaction(debit);
            recipient.AddTransaction(credit);
        }
    }
}
