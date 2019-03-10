namespace dk.lashout.LARPay.API.Controllers
{
    internal class CustomerViewModel
    {
        public CustomerViewModel(string name, string username, string pincode)
        {
            Name = name;
            Username = username;
            Pincode = pincode;
        }

        public string Name { get; }
        public string Username { get; }
        public string Pincode { get; }
    }
}