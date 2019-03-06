using dk.lashout.LARPay.Accounting.Applications;
using dk.lashout.LARPay.Accounting.Clerks;
using dk.lashout.LARPay.Administration;
using System;

namespace dk.lashout.LARPay.Accounting.Services
{
    public class OpenAccountCommand : ICommand
    {
        public Guid Account { get; }
        public Guid Customer { get; }

        public OpenAccountCommand(Guid account, Guid customer)
        {
            Account = account;
            Customer = customer;
        }
    }

    sealed class OpenAccountCommandHandler : ICommandHandler<OpenAccountCommand>
    {
        private readonly IAccountRepository _accountRepository;

        public OpenAccountCommandHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
        }

        public Result Handle(OpenAccountCommand command)
        {
            if (_accountRepository.HasAccount(command.Account))
                return new Result("Account already exists, try again with an other GUID");

            var account = new Account(command.Customer);
            _accountRepository.AddAccount(command.Account, account);
            return new Result();
        }
    }

}
