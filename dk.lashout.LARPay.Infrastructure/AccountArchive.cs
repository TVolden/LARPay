using System;
using System.Collections.Generic;
using dk.lashout.LARPay.Accounting.Forms;

namespace dk.lashout.LARPay.Archives
{
    class AccountArchive : IAccountArchive
    {
        private readonly Dictionary<Guid, List<ITransaction>> _accounts;

        public AccountArchive()
        {
            _accounts = new Dictionary<Guid, List<ITransaction>>();
        }

        public IEnumerable<ITransaction> this[Guid account] => _accounts[account];

        public void Add(Guid account)
        {
            throw new NotImplementedException();
        }

        public bool Contains(Guid account) => _accounts.ContainsKey(account);
    }
}
