using dk.lashout.LARPay.Accounting.Services;
using dk.lashout.LARPay.Administration;

namespace dk.lashout.LARPay.Accounting.Checks
{
    class TransferExpensesCoveredCheck : ICommandHandler<TransferMoneyCommand>
    {
        private readonly ICommandHandler<TransferMoneyCommand> _decorated;
        private readonly Messages _messages;

        public TransferExpensesCoveredCheck(ICommandHandler<TransferMoneyCommand> decorated, Messages messages)
        {
            _decorated = decorated ?? throw new System.ArgumentNullException(nameof(decorated));
            _messages = messages ?? throw new System.ArgumentNullException(nameof(messages));
        }

        public Result Handle(TransferMoneyCommand command)
        {
            var balance = _messages.Dispatch(new GetBalanceQuery(command.Benefactor));
            if (balance < command.Amount)
                return new Result("Amount exceeds account balance.");

            return _decorated.Handle(command);
        }
    }
}
