using dk.lashout.LARPay.Accounting.Applications;
using dk.lashout.LARPay.Accounting.Clerks;
using dk.lashout.LARPay.Administration;
using System;

namespace dk.lashout.LARPay.Accounting.Services
{
    public class OpenAccountCommand : ICommand
    {
        public Guid AccountId { get; }
        public Guid CustomerId { get; }

        public OpenAccountCommand(Guid accountId, Guid customerId)
        {
            AccountId = accountId;
            CustomerId = customerId;
        }
    }

    public sealed class OpenAccountCommandHandler : ICommandHandler<OpenAccountCommand>
    {
        private readonly IAccountRepository _accountRepository;

        public OpenAccountCommandHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
        }

        public Result Handle(OpenAccountCommand command)
        {
            if (_accountRepository.HasAccount(command.AccountId))
                return new Result("AccountId already exists, try again with an other GUID");

            var account = new Account(command.CustomerId);
            _accountRepository.AddAccount(command.AccountId, account);
            return new Result();
        }
    }

}
