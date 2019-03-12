namespace dk.lashout.LARPay.CustomerArchive.Applications
{
    public class Customer
    {
        public string Username { get; }
        public string Pincode { get; }
        public string Name { get; }

        public Customer(string username, string pincode, string name)
        {
            Username = username;
            Pincode = pincode;
            Name = name;
        }
    }
}
