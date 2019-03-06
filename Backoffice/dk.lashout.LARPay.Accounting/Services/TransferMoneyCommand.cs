using dk.lashout.LARPay.Accounting.Applications;
using dk.lashout.LARPay.Accounting.Clerks;
using dk.lashout.LARPay.Administration;
using System;

namespace dk.lashout.LARPay.Accounting.Services
{
    public class TransferMoneyCommand : ICommand
    {
        public Guid Benefactor { get; }
        public Guid Recipient { get; }
        public double Amount { get; }
        public string Description { get; }

        public TransferMoneyCommand(Guid benefactor, Guid recipient, double amount, string description)
        {
            Benefactor = benefactor;
            Recipient = recipient;
            Amount = amount;
            Description = description;
        }

    }

    sealed class TransferMoneyCommandHandler : ICommandHandler<TransferMoneyCommand>
    {
        private readonly IAccountRepository _accountRepository;

        public TransferMoneyCommandHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public Result Handle(TransferMoneyCommand command)
        {
            var benefactor = _accountRepository.GetAccount(command.Benefactor).ValueOrDefault(null);
            var recipient = _accountRepository.GetAccount(command.Recipient).ValueOrDefault(null);

            var debit = new Debit(command.Recipient, command.Amount, command.Description);
            var credit = new Credit(command.Benefactor, command.Amount, command.Description);

            benefactor.AddTransaction(debit);
            recipient.AddTransaction(credit);

            return new Result();
        }
    }
}
