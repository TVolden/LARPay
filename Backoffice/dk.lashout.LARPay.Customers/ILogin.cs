namespace dk.lashout.LARPay.Customers
{
    public interface ILogin
    {
        bool Login(string identity, int pincode);
    }
}
