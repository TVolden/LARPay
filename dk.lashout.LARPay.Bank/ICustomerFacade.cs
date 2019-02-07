namespace dk.lashout.LARPay.Bank
{
    interface ICustomerFacade
    {
        void Transfer(string from, string receipant, decimal amount, string description);
    }
}
