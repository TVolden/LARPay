using dk.lashout.LARPay.Accounting.Clerks;
using dk.lashout.LARPay.Administration;
using System;

namespace dk.lashout.LARPay.Accounting.Services
{
    public class GetCustomerIdQuery : IQuery<Guid>
    {
        public Guid Account { get; }

        public GetCustomerIdQuery(Guid account)
        {
            Account = account;
        }
    }

    sealed class GetCustomerIdQueryHandler : IQueryHandler<GetCustomerIdQuery, Guid>
    {
        private readonly IAccountRepository _accountRepository;

        public GetCustomerIdQueryHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public Guid Handle(GetCustomerIdQuery query)
        {
            return _accountRepository.GetAccount(query.Account).ValueOrDefault(null).Customer;
        }
    }
}
