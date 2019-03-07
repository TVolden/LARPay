using System;

namespace dk.lashout.LARPay.Administration
{
    public interface IServiceProvider
    {
        object GetService(Type handlerType);
    }
}