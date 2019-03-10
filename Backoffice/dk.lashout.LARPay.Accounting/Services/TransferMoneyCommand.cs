using dk.lashout.LARPay.Accounting.Applications;
using dk.lashout.LARPay.Accounting.Clerks;
using dk.lashout.LARPay.Accounting.Forms;
using dk.lashout.LARPay.Administration;
using dk.lashout.LARPay.Clock;
using System;

namespace dk.lashout.LARPay.Accounting.Services
{
    public class TransferMoneyCommand : ICommand
    {
        public Guid Benefactor { get; }
        public Guid Recipient { get; }
        public decimal Amount { get; }
        public string Description { get; }

        public TransferMoneyCommand(Guid benefactor, Guid recipient, decimal amount, string description)
        {
            Benefactor = benefactor;
            Recipient = recipient;
            Amount = amount;
            Description = description;
        }

    }

    public sealed class TransferMoneyCommandHandler : ICommandHandler<TransferMoneyCommand>
    {
        private readonly Messages _messages;
        private readonly IAccountRepository _accountRepository;
        private readonly ITimeProvider _timeProvider;

        public TransferMoneyCommandHandler(Messages messages, IAccountRepository accountRepository, ITimeProvider timeProvider)
        {
            _messages = messages ?? throw new ArgumentNullException(nameof(messages));
            _accountRepository = accountRepository;
            _timeProvider = timeProvider ?? throw new ArgumentNullException(nameof(timeProvider));
        }

        public Result Handle(TransferMoneyCommand command)
        {
            try
            {
                var benefactor = GetAccount(command.Benefactor, "Benefactor");
                var recipient = GetAccount(command.Recipient, "Recipient");
                
                var balance = _messages.Dispatch(new GetBalanceQuery(command.Benefactor));
                if (balance + benefactor.creditLimit < command.Amount)
                    return new Result("Amount exceeds account balance.");

                var transferDate = _timeProvider.Now;

                var debit = new Debit(command.Recipient, command.Amount, command.Description, transferDate);
                var credit = new Credit(command.Benefactor, command.Amount, command.Description, transferDate);

                benefactor.AddTransaction(debit);
                recipient.AddTransaction(credit);
            }
            catch (Exception ex)
            {
                return new Result(ex.Message);
            }
            return new Result();
        }

        private IAccount GetAccount(Guid accountId, string who)
        {
            var maybeAccount = _accountRepository.GetAccount(accountId);
            if (!maybeAccount.HasValue())
                throw new Exception(string.Format("{0} account not found.", who));
            return maybeAccount.ValueOrDefault(null);
        }
    }
}
