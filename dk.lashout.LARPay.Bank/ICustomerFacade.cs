namespace dk.lashout.LARPay.Bank
{
    public interface ICustomerFacade
    {
        void CreateCustomer(string identifier, string name, int pincode);
    }
}
