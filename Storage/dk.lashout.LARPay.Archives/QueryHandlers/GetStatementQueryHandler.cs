using dk.lashout.LARPay.Accounting.Forms;
using dk.lashout.LARPay.Accounting.Services;
using dk.lashout.LARPay.Administration;
using dk.lashout.LARPay.Archives.Applications;
using System;
using System.Collections.Generic;

namespace dk.lashout.LARPay.Archives.QueryHandlers
{
    public sealed class GetStatementQueryHandler : IQueryHandler<GetStatementQuery, IEnumerable<TransferDto>>
    {
        private readonly AccountArchive _archive;
        private readonly TransferDtoVisitorFactory _visitorFactory;

        public GetStatementQueryHandler(AccountArchive archive, TransferDtoVisitorFactory visitorFactory)
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
