namespace dk.lashout.LARPay.Administration
{
    public interface IEventObserver<TEvent> where TEvent : IEvent
    {
        void Update(TEvent @event);
    }
}
