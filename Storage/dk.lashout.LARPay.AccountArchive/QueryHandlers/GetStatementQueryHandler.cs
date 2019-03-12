using dk.lashout.LARPay.Accounting.Forms;
using dk.lashout.LARPay.Administration;
using dk.lashout.LARPay.AccountArchive.Applications;
using System;
using System.Collections.Generic;
using dk.lashout.LARPay.Accounting;

namespace dk.lashout.LARPay.AccountArchive.QueryHandlers
{
    public sealed class GetStatementQueryHandler : IQueryHandler<GetStatementQuery, IEnumerable<TransferDto>>
    {
        private readonly AccountStates _archive;
        private readonly TransferDtoVisitorFactory _visitorFactory;

        public GetStatementQueryHandler(AccountStates archive, TransferDtoVisitorFactory visitorFactory)
        {
            _archive = archive ?? throw new ArgumentNullException(nameof(archive));
            _visitorFactory = visitorFactory ?? throw new ArgumentNullException(nameof(visitorFactory));
        }

        public IEnumerable<TransferDto> Handle(GetStatementQuery query)
        {
            var maybeAccount = _archive.GetAccount(query.account);
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
