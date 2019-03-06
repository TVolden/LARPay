using dk.lashout.LARPay.Accounting.Clerks;
using dk.lashout.LARPay.Administration;
using System;
using System.Linq;

namespace dk.lashout.LARPay.Accounting.Services
{
    public class GetBalanceQuery : IQuery<double>
    {
        public Guid Account { get; }

        public GetBalanceQuery(Guid account)
        {
            Account = account;
        }
    }

    sealed class GetBalanceQueryHandler : IQueryHandler<GetBalanceQuery, double>
    {
        private readonly IAccountRepository _accountRepository;

        public GetBalanceQueryHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public double Handle(GetBalanceQuery query)
        {
            var account = _accountRepository.GetAccount(query.Account).ValueOrDefault(null);
            return account.GetTransactions().Sum(t => t.Amount);
        }
    }
}
