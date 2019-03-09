using dk.lashout.LARPay.Accounting.Clerks;
using dk.lashout.LARPay.Administration;
using dk.lashout.MaybeType;
using System;
using System.Linq;

namespace dk.lashout.LARPay.Accounting.Services
{
    public class GetAccountIdByCustomerIdQuery : IQuery<Maybe<Guid>>
    {
        public Guid CustomerId { get; }

        public GetAccountIdByCustomerIdQuery(Guid customerId)
        {
            CustomerId = customerId;
        }
    }

    public sealed class GetAccountIdByCustomerIdQueryHandler : IQueryHandler<GetAccountIdByCustomerIdQuery, Maybe<Guid>>
    {
        private readonly IAccountRepository _accountRepository;

        public GetAccountIdByCustomerIdQueryHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
        }

        public Maybe<Guid> Handle(GetAccountIdByCustomerIdQuery query)
        {
            return _accountRepository.GetAccountId(query.CustomerId);
        }
    }
}
