using dk.lashout.LARPay.Administration;
using System;

namespace dk.lashout.LARPay.Customers.Events
{
    public class CustomerRegisteredEvent : IEvent
    {
        public int Version => 1;
        public DateTime EventDate { get; }
        public Guid ProcessId { get; }

        public Guid CustomerId { get; }
        public string Username { get; }
        public string Pincode { get; }
        public string Name { get; }

        public CustomerRegisteredEvent(DateTime eventDate, Guid processId, Guid customerId, string username, string pincode, string name)
        {
            EventDate = eventDate;
            ProcessId = processId;
            CustomerId = customerId;
            Username = username;
            Pincode = pincode;
            Name = name;
        }
    }
}
