using dk.lashout.LARPay.Core.Entities;

namespace dk.lashout.LARPay.Core.Services
{
    public interface ICustomerRepository
    {
        Customer GetByIdentity(string identity);
    }
}
