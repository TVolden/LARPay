using dk.lashout.LARPay.Administration;
using System;

namespace dk.lashout.LARPay.Customers.Events
{
    public class CustomerRegisteredEvent : IEvent
    {
        public Guid CustomerId { get; }
        public string Username { get; }
        public string Pincode { get; }
        public string Name { get; }
        public DateTime Date { get; }

        public CustomerRegisteredEvent(Guid customerId, string username, string pincode, string name, DateTime date)
        {
            CustomerId = customerId;
            Username = username;
            Pincode = pincode;
            Name = name;
            Date = date;
        }
    }
}
