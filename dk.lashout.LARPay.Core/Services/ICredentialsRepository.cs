using dk.lashout.LARPay.Core.Entities;

namespace dk.lashout.LARPay.Core.Services
{
    public interface ICredentialsRepository
    {
        Credentials GetByIdentity(string identity);
        void Insert(Credentials credentials);
    }
}
