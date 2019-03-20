using dk.lashout.LARPay.AccountArchive.EventObservers;
using dk.lashout.LARPay.AccountArchive.QueryHandlers;
using dk.lashout.LARPay.Accounting;
using dk.lashout.LARPay.Accounting.Events;
using dk.lashout.LARPay.Accounting.Forms;
using dk.lashout.LARPay.Administration;
using dk.lashout.LARPay.CustomerArchive.EventObservers;
using dk.lashout.LARPay.CustomerArchive.QueryHandlers;
using dk.lashout.LARPay.Customers;
using dk.lashout.LARPay.Customers.Events;
using dk.lashout.LARPay.Customers.Forms;
using dk.lashout.MaybeType;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace dk.lashout.LARPay.Bank
{
    public static class DIHelper
    {
        public static void AddQueryHandlers(this IServiceCollection services)
        {
            services.AddSingleton<IQueryHandler<GetBalanceQuery, decimal>, GetBalanceQueryHandler>();
            services.AddSingleton<IQueryHandler<GetAccountIdByCustomerIdQuery, Maybe<Guid>>, GetAccountIdByCustomerIdQueryHandler>();
            services.AddSingleton<IQueryHandler<GetCustomerIdByAccountIdQuery, Guid>, GetCustomerIdByAccountIdQueryHandler>();
            services.AddSingleton<IQueryHandler<GetStatementQuery, IEnumerable<TransferDto>>, GetStatementQueryHandler>();
            services.AddSingleton<IQueryHandler<GetAvailableCustomerIdQuery, Guid>, GetAvailableCustomerIdQueryHandler>();
            services.AddSingleton<IQueryHandler<GetCustomerIdByUsernameQuery, Maybe<Guid>>, GetCustomerIdByUsernameQueryHandler>();
            services.AddSingleton<IQueryHandler<GetCustomerQuery, Maybe<CustomerDto>>, GetCustomerQueryHandler>();
            services.AddSingleton<IQueryHandler<GetUsernameByCustomerIdQuery, Maybe<string>>, GetUsernameByCustomerIdQueryHandler>();
            services.AddSingleton<IQueryHandler<IsUsernameAvailableQuery, bool>, IsUsernameAvailableQueryHandler>();
            services.AddSingleton<IQueryHandler<LoginQuery, bool>, LoginQueryHandler>();
            services.AddSingleton<IQueryHandler<GetAvailableAccountIdQuery, Guid>, GetAvailableAccountIdQueryHandler>();
            services.AddSingleton<IQueryHandler<GetDisposableAmountQuery, decimal>, GetDisposableAmountQueryHandler>();
            services.AddSingleton<IQueryHandler<HasAccountQuery, bool>, HasAccountQueryHandler>();
            services.AddSingleton<IQueryHandler<HasCustomerIdQuery, bool>, HasCustomerIdQueryHandler>();
        }

        public static void AddCommandHandlers(this IServiceCollection services)
        {
            services.AddSingleton<ICommandHandler<OpenAccountCommand>, OpenAccountCommandHandler>();
            services.AddSingleton<ICommandHandler<TransferAmountCommand>, TransferMoneyCommandHandler>();
            services.AddSingleton<ICommandHandler<RegisterCustomerCommand>, RegisterCustomerCommandHandler>();
            services.AddSingleton<ICommandHandler<SetCreditLimitForAccountIdCommand>, SetCreditLimitForAccountIdCommandHandler>();
        }
    }
}
