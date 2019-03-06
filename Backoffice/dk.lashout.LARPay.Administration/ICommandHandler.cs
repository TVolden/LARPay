namespace dk.lashout.LARPay.Administration
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        Result Handle(TCommand command);
    }
}
