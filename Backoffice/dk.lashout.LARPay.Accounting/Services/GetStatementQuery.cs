using dk.lashout.LARPay.Accounting.Applications;
using dk.lashout.LARPay.Accounting.Clerks;
using dk.lashout.LARPay.Accounting.Forms;
using dk.lashout.LARPay.Administration;
using System;
using System.Collections.Generic;

namespace dk.lashout.LARPay.Accounting.Services
{
    public class GetStatementQuery : IQuery<IEnumerable<TransferDto>>
    {
        public Guid account;

        public GetStatementQuery(Guid account)
        {
            this.account = account;
        }
    }

    sealed class GetStatementQueryHandler : IQueryHandler<GetStatementQuery, IEnumerable<TransferDto>>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly TransferDtoVisitorFactory _visitorFactory;

        public GetStatementQueryHandler(IAccountRepository accountRepository, TransferDtoVisitorFactory visitorFactory)
        {
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
            _visitorFactory = visitorFactory ?? throw new ArgumentNullException(nameof(visitorFactory));
        }

        public IEnumerable<TransferDto> Handle(GetStatementQuery query)
        {
            var maybeAccount = _accountRepository.GetAccount(query.account);
            if (maybeAccount.HasValue())
            {
                var account = maybeAccount.ValueOrDefault(null);
                foreach (var transaction in account.GetTransactions())
                {
                    var visitor = _visitorFactory.CreateVisitor(account.CustomerId);
                    yield return transaction.Accept(visitor);
                }
            }
        }
    }
}
