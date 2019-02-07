namespace dk.lashout.LARPay.Bank
{
    class CustomerFacade : ICustomerFacade
    {
        public CustomerFacade(IAccountGetter accountGetter)
        {
        }

        public void Transfer(string from, string receipant, decimal amount, string description)
        {
            throw new System.NotImplementedException();
        }
    }
}
