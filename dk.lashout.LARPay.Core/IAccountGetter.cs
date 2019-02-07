using dk.lashout.MaybeType;

namespace dk.lashout.LARPay.CustomerService
{
    public interface IAccountGetter
    {
        Maybe<long> GetAccount(string identifier);
    }
}
