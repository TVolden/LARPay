using System.Collections.Generic;
using dk.lashout.LARPay.Core.Entities;
using dk.lashout.LARPay.Core.Services;

namespace dk.lashout.LARPay.Infrastructure.Services
{
    public class CredentialsRepository : ICredentialsRepository
    {
        private readonly List<Credentials> _credentialses;

        public CredentialsRepository()
        {
            _credentialses = new List<Credentials>();
        }

        public Credentials GetByIdentity(string identity)
        {
            foreach (var customer in _credentialses)
            {
                if (customer.Identity == identity)
                    return customer;
            }

            return null;
        }

        public void Insert(Credentials credentials)
        {
            _credentialses.Add(credentials);
        }
    }
}
