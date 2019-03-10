using dk.lashout.LARPay.Accounting.Clerks;
using dk.lashout.LARPay.Administration;
using System;

namespace dk.lashout.LARPay.Accounting.Services
{
    public class GetCreditLimitForAccountIdQuery : IQuery<decimal>
    {
        public Guid Account { get; }

        public GetCreditLimitForAccountIdQuery(Guid account)
        {
            Account = account;
        }
    }

    public sealed class GetCreditLimitForAccountIdQueryHandler : IQueryHandler<GetCreditLimitForAccountIdQuery, decimal>
    {
        private readonly IAccountRepository _accountRepository;

        public GetCreditLimitForAccountIdQueryHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public decimal Handle(GetCreditLimitForAccountIdQuery query)
        {
            var account = _accountRepository.GetAccount(query.Account);
            if (!account.HasValue())
                return 0;
            return account.ValueOrDefault(null).creditLimit;
        }
    }
}
