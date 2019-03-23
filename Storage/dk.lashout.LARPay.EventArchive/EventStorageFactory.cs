using dk.lashout.LARPay.Administration;
using System.IO;

namespace dk.lashout.LARPay.EventArchive
{
    public class EventStorageFactory
    {
        private readonly Messages _messages;
        private readonly IEventTypeIdentifier _eventTypeIdentifier;

        public EventStorageFactory(Messages messages, IEventTypeIdentifier eventTypeIdentifier)
        {
            _messages = messages ?? throw new System.ArgumentNullException(nameof(messages));
            _eventTypeIdentifier = eventTypeIdentifier ?? throw new System.ArgumentNullException(nameof(eventTypeIdentifier));
        }

        public EventStorage Create(string storePath, string storeFile)
        {
            var eventStorePath = Path.GetFullPath(storePath);
            Directory.CreateDirectory(eventStorePath);
            var eventStore = eventStorePath + storeFile;
            return new EventStorage(_messages, eventStore, _eventTypeIdentifier);
        }
    }
}
