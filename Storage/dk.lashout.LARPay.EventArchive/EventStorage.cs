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
        private List<IEvent> _events;
        private DateTime _lastEventDate;
        private bool replaying = false;

        public EventStorage(Messages messages, string eventStore)
        {
            _events = new List<IEvent>();
            _messages = messages ?? throw new ArgumentNullException(nameof(messages));
            _eventStore = eventStore ?? throw new ArgumentNullException(nameof(eventStore));
        }

        public void AddEvent(IEvent @event)
        {
            if (replaying)
                return;

            if (_lastEventDate <= @event.EventDate)
                return;

            var jsonEvent = JsonConvert.SerializeObject(@event);
            var output = $"\"{@event.GetType().AssemblyQualifiedName}\":{jsonEvent}";
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
                    (var type, var data) = eventLine.Split(':', 2);
                    var settings = new JsonSerializerSettings {
                        DateFormatString = "yyyy-MM-ddTH:mm:ss.fffK",
                        DateTimeZoneHandling = DateTimeZoneHandling.Utc
                    };
                    dynamic @event = JsonConvert.DeserializeObject(data, Type.GetType(type.Replace("\"", "")), settings);
                    replaying = true;
                    _messages.Dispatch(@event);
                    replaying = false;
                }
            }
        }
    }
}
