using dk.lashout.LARPay.Administration;

namespace dk.lashout.LARPay.EventArchive.Decorator
{
    public class EventSaverFactory
    {
        private readonly EventStorage _storage;

        public EventSaverFactory(EventStorage storage)
        {
            _storage = storage ?? throw new System.ArgumentNullException(nameof(storage));
        }

        public IEventObserver<TEvent> Create<TEvent>(IEventObserver<TEvent> observer) where TEvent : IEvent
        {
            return new EventSaver<TEvent>(_storage, observer);            
        }
    }
}
