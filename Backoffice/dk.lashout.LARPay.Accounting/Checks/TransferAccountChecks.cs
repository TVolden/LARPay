using dk.lashout.LARPay.Accounting.Clerks;
using dk.lashout.LARPay.Accounting.Services;
using dk.lashout.LARPay.Administration;

namespace dk.lashout.LARPay.Accounting.Checks
{
    class TransferAccountChecks : ICommandHandler<TransferMoneyCommand>
    {
        private readonly ICommandHandler<TransferMoneyCommand> _decorated;
        private readonly IAccountRepository _accountRepository;

        public TransferAccountChecks(ICommandHandler<TransferMoneyCommand> decorated, IAccountRepository accountRepository)
        {
            _decorated = decorated;
            _accountRepository = accountRepository;
        }

        public Result Handle(TransferMoneyCommand command)
        {
            var benefactor = _accountRepository.GetAccount(command.Benefactor);
            if (!benefactor.HasValue())
                return new Result("Benefactor account not found.");

            var recipient = _accountRepository.GetAccount(command.Recipient);
            if (!recipient.HasValue())
                return new Result("Recipient account not found.");

            return _decorated.Handle(command);
        }
    }
}
