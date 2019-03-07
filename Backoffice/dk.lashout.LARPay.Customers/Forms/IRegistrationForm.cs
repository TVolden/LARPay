namespace dk.lashout.LARPay.Customers.Forms
{
    public interface IRegistrationForm : ICustomer
    {
        string Name { get; }
        string Username { get; }
        string Pincode { get; }
    }
}
