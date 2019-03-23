using dk.lashout.MaybeType;
using System;

namespace dk.lashout.LARPay.EventArchive
{
    public interface IEventTypeIdentifier
    {
        Maybe<Type> GetEventType(string type);
    }
}
