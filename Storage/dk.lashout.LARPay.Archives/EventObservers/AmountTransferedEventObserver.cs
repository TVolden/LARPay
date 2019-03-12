using dk.lashout.LARPay.Accounting.Events;
using dk.lashout.LARPay.Administration;
using dk.lashout.LARPay.Archives.Applications;
using System;

namespace dk.lashout.LARPay.Archives.EventObservers
{
    public class AmountTransferedEventObserver : IEventObserver<AmountTransferedEvent>
    {
        private readonly AccountArchive _archive;

        public AmountTransferedEventObserver(AccountArchive archive)
        {
            _archive = archive ?? throw new ArgumentNullException(nameof(archive));
        }

        public void Update(AmountTransferedEvent newEvent)
        {
            var benefactor = _archive.GetAccount(newEvent.BenefactorAccountId).ValueOrDefault(null);
            var recipient = _archive.GetAccount(newEvent.ReceipientAccountId).ValueOrDefault(null);

            var debit = new Debit(newEvent.ReceipientAccountId, newEvent.Amount, newEvent.Description, newEvent.Date);
            var credit = new Credit(newEvent.BenefactorAccountId, newEvent.Amount, newEvent.Description, newEvent.Date);

            benefactor.AddTransaction(debit);
            recipient.AddTransaction(credit);
        }
    }
}
