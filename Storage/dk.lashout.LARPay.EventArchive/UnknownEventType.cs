using System;

namespace dk.lashout.LARPay.EventArchive
{
    public class UnknownEventType : Exception
    {
        public string EventName { get; }

        public UnknownEventType(string eventName)
        {
            EventName = eventName;
        }
    }
}
