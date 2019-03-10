using dk.lashout.LARPay.Accounting.Clerks;
using dk.lashout.LARPay.Administration;
using System;

namespace dk.lashout.LARPay.Accounting.Services
{
    public class SetCreditLimitForAccountIdCommand : ICommand
    {
        public Guid AccountId { get; }
        public decimal CreditLimit { get; }

        public SetCreditLimitForAccountIdCommand(Guid accountId, decimal creditLimit)
        {
            AccountId = accountId;
            CreditLimit = creditLimit;
        }
    }

    public sealed class SetCreditLimitForAccountIdCommandHandler : ICommandHandler<SetCreditLimitForAccountIdCommand>
    {
        private readonly IAccountRepository _accountRepository;

        public SetCreditLimitForAccountIdCommandHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
        }

        public Result Handle(SetCreditLimitForAccountIdCommand command)
        {
            var account = _accountRepository.GetAccount(command.AccountId);
            if (!account.HasValue())
                return new Result("Account not found");

            account.ValueOrDefault(null).creditLimit = command.CreditLimit;

            return new Result();
        }
    }
}
