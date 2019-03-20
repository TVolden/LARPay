using dk.lashout.LARPay.Administration;
using System.IO;

namespace dk.lashout.LARPay.EventArchive
{
    public class EventStorageFactory
    {
        private readonly Messages _messages;

        public EventStorageFactory(Messages messages)
        {
            _messages = messages ?? throw new System.ArgumentNullException(nameof(messages));
        }

        public EventStorage Create(string storePath, string storeFile)
        {
            var eventStorePath = Path.GetFullPath(storePath);
            Directory.CreateDirectory(eventStorePath);
            var eventStore = eventStorePath + storeFile;
            return new EventStorage(_messages, eventStore);
        }
    }
}
