using System;
using System.Linq;
using dk.lashout.LARPay.EventArchive;
using dk.lashout.MaybeType;

namespace dk.lashout.LARPay.Bank
{
    public class EventTypeIdentifier : IEventTypeIdentifier
    {
        private readonly Type[] _types;

        public EventTypeIdentifier(params Type[] types)
        {
            _types = types ?? throw new ArgumentNullException(nameof(types));
        }

        public Maybe<Type> GetEventType(string type)
        {
            var maybeType = _types.Where(t => t.Name == type).FirstOrDefault();
            if (maybeType != null)
                return new Maybe<Type>(maybeType);
            return new Maybe<Type>();
        }
    }
}
