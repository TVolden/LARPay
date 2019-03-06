namespace dk.lashout.LARPay.Customers.Forms
{
    public interface IRegistrationForm : ICustomerForm
    {
        string Name { get; }
        string Username { get; }
        string Pincode { get; }
    }
}
