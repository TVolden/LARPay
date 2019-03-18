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
        private readonly FileStream _eventStore;
        private List<IEvent> _events;
        public DateTime LastEventDate { get; set; }

        public EventStorage(Messages messages, FileStream eventStore)
        {
            _events = new List<IEvent>();
            _messages = messages ?? throw new ArgumentNullException(nameof(messages));
            _eventStore = eventStore ?? throw new ArgumentNullException(nameof(eventStore));
        }

        public void AddEvent(IEvent @event)
        {
            var jsonEvent = JsonConvert.SerializeObject(@event);
            var output = $"{@event.GetType()}:{jsonEvent}";
            var eventStoreWriter = new StreamWriter(_eventStore);
            eventStoreWriter.WriteLine(output);
            eventStoreWriter.Dispose();
        }

        public void ReplayEvents(DateTime from)
        {
            foreach (var @event in _events.Select(e => e.EventDate >= from))
            {
                _messages.Dispatch((dynamic)@event);
            }
        }
    }
}
