namespace dk.lashout.LARPay.CustomerService.Clerks
{
    public interface ICustomerReceiver
    {
        void SaveCustomer(string identifier, string name, int pincode);
    }
}
