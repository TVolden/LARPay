using dk.lashout.LARPay.Administration;

namespace dk.lashout.LARPay.Customers.Service
{
    public class IsUsernameAvailableQuery : IQuery<bool>
    {
        public string Username { get; }

        public IsUsernameAvailableQuery(string username)
        {
            Username = username;
        }
    }
}
