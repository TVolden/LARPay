namespace dk.lashout.LARPay.Bank
{
    public interface ICustomerFacade
    {
        void CreateCustomer(string username, string name, string pincode);
        bool Login(string username, string pincode);
    }
}
