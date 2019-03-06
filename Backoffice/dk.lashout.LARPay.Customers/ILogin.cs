namespace dk.lashout.LARPay.Customers
{
    public interface ILogin
    {
        bool Login(string username, string pincode);
    }
}
