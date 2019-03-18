using dk.lashout.LARPay.Administration;

namespace dk.lashout.LARPay.EventArchive.Decorator
{
    public class EventSaver<TEvent> : IEventObserver<TEvent> where TEvent : IEvent
    {
        private readonly EventStorage _archive;
        private readonly IEventObserver<TEvent> _observer;

        public EventSaver(EventStorage storage, IEventObserver<TEvent> observer)
        {
            _archive = storage ?? throw new System.ArgumentNullException(nameof(storage));
            _observer = observer ?? throw new System.ArgumentNullException(nameof(observer));
        }

        public void Update(TEvent @event)
        {
            if (@event.EventDate <= _archive.LastEventDate)
                return;

            _archive.AddEvent(@event);
            _observer.Update(@event);

            _archive.LastEventDate = @event.EventDate;
        }
    }
}
