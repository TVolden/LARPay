using dk.lashout.LARPay.CustomerService.Forms;

namespace dk.lashout.LARPay.Web.Models
{
    public class CredentialsViewModel : ICustomer
    {
        public string Name { get; set; }
        public string Identity { get; set; }
        public int Pincode { get; set; }
    }
}
