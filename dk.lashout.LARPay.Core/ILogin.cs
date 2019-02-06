namespace dk.lashout.LARPay.CustomerService
{
    public interface ILogin
    {
        bool Login(string identity, int pincode);
    }
}
