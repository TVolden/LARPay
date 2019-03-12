using dk.lashout.LARPay.Administration;

namespace dk.lashout.LARPay.Customers.Service
{
    public class LoginQuery : IQuery<bool>
    {
        public string Username { get; }
        public string Pincode { get; }

        public LoginQuery(string username, string pincode)
        {
            Username = username;
            Pincode = pincode;
        }
    }
}
