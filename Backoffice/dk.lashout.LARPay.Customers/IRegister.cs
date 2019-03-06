using dk.lashout.LARPay.Customers.Forms;

namespace dk.lashout.LARPay.Customers
{
    public interface IRegister
    {
        IRegistrationForm GetRegistrationForm();
        void FileRegistrationForm(IRegistrationForm registrationForm);
        bool UsernameAvailable(string username);
    }
}
