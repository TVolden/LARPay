using dk.lashout.LARPay.Administration;
using System;

namespace dk.lashout.LARPay.Customers.Events
{
    public class CustomerRegisteredEvent : IEvent
    {
        public int Version => 1;
        public DateTime EventTime { get; }
        public Guid ProcessId { get; }

        public Guid CustomerId { get; }
        public string Username { get; }
        public string Pincode { get; }
        public string Name { get; }

        public CustomerRegisteredEvent(DateTime eventTime, Guid processId, Guid customerId, string username, string pincode, string name)
        {
            EventTime = eventTime;
            ProcessId = processId;
            CustomerId = customerId;
            Username = username;
            Pincode = pincode;
            Name = name;
        }
    }
}
