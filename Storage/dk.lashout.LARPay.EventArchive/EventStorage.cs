using dk.lashout.LARPay.Administration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace dk.lashout.LARPay.EventArchive
{
    public class EventStorage
    {
 
        private readonly Messages _messages;
        private readonly string _eventStore;
        private readonly IEventTypeIdentifier _typeIdentifier;
        private List<IEvent> _events;
        private DateTime _lastEventDate;
        private bool replaying = false;

        public EventStorage(Messages messages, string eventStore, IEventTypeIdentifier typeIdentifier)
        {
            _events = new List<IEvent>();
            _messages = messages ?? throw new ArgumentNullException(nameof(messages));
            _eventStore = eventStore ?? throw new ArgumentNullException(nameof(eventStore));
            _typeIdentifier = typeIdentifier ?? throw new ArgumentNullException(nameof(typeIdentifier));
        }

        public void AddEvent(IEvent @event)
        {

            if (replaying)
                return;

            if (@event.EventDate <= _lastEventDate)
                return;

            var jsonEvent = JsonConvert.SerializeObject(@event);
            var output = $"\"{@event.GetType().Name}\":{jsonEvent}";
            using(var eventStoreWriter = new StreamWriter(_eventStore, true)) {
                eventStoreWriter.WriteLine(output);
            }

            _lastEventDate = @event.EventDate;
        }

        public void ReplayEvents(DateTime from)
        {
            if (!File.Exists(_eventStore))
                return;

            using (var eventStoreReader = new StreamReader(_eventStore))
            {
                string eventLine;
                while ((eventLine = eventStoreReader.ReadLine()) != null)
                {
                    (var typeName, var data) = eventLine.Split(':', 2);
                    var type = _typeIdentifier.GetEventType(typeName.Replace("\"", "")).ValueOrDefault(null);

                    if (type == null)
                        throw new UnknownEventType(typeName);
                    dynamic @event = JsonConvert.DeserializeObject(data, type);
                    replaying = true;
                    _messages.Dispatch(@event);
                    replaying = false;
                }
            }
        }
    }
}
