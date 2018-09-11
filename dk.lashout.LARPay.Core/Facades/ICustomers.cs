namespace dk.lashout.LARPay.Core.Facades
{
    public interface ICustomers
    {
        void Create(string identity, string name, int pincode);
        bool Login(string identity, int pincode);

    }
}
