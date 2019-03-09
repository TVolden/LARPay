using dk.lashout.LARPay.Accounting.Clerks;
using dk.lashout.LARPay.Administration;
using System;

namespace dk.lashout.LARPay.Accounting.Services
{
    public class GetCustomerIdByAccountIdQuery : IQuery<Guid>
    {
        public Guid Account { get; }

        public GetCustomerIdByAccountIdQuery(Guid account)
        {
            Account = account;
        }
    }

    public sealed class GetCustomerIdByAccountIdQueryHandler : IQueryHandler<GetCustomerIdByAccountIdQuery, Guid>
    {
        private readonly IAccountRepository _accountRepository;

        public GetCustomerIdByAccountIdQueryHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public Guid Handle(GetCustomerIdByAccountIdQuery query)
        {
            return _accountRepository.GetAccount(query.Account).ValueOrDefault(null).CustomerId;
        }
    }
}
