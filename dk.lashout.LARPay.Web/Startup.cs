using System;
using System.Collections.Generic;
using System.Text;
using dk.lashout.LARPay.AccountArchive;
using dk.lashout.LARPay.AccountArchive.Applications;
using dk.lashout.LARPay.AccountArchive.EventObservers;
using dk.lashout.LARPay.AccountArchive.QueryHandlers;
using dk.lashout.LARPay.Accounting;
using dk.lashout.LARPay.Accounting.Events;
using dk.lashout.LARPay.Accounting.Forms;
using dk.lashout.LARPay.Administration;
using dk.lashout.LARPay.Bank;
using dk.lashout.LARPay.Clock;
using dk.lashout.LARPay.CustomerArchive;
using dk.lashout.LARPay.CustomerArchive.EventObservers;
using dk.lashout.LARPay.CustomerArchive.QueryHandlers;
using dk.lashout.LARPay.Customers;
using dk.lashout.LARPay.Customers.Events;
using dk.lashout.LARPay.Customers.Forms;
using dk.lashout.MaybeType;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace dk.lashout.LARPay
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var secretKey = Encoding.UTF8.GetBytes(_configuration["jwt:SecretKey"]);


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.IncludeErrorDetails = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(secretKey),
                        ValidAudience = _configuration["jwt:Audience"],
                        ValidIssuer = _configuration["jwt:Issuer"],
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.FromMinutes(0)
                    };
                });

            services.AddSingleton<Messages>();

            services.AddSingleton<AccountStates>();
            services.AddSingleton<CustomerStates>();

            services.AddSingleton<IQueryHandler<GetBalanceQuery, decimal>, GetBalanceQueryHandler>();
            services.AddSingleton<IQueryHandler<GetAccountIdByCustomerIdQuery, Maybe<Guid>>, GetAccountIdByCustomerIdQueryHandler>();
            services.AddSingleton<IQueryHandler<GetCustomerIdByAccountIdQuery, Guid>, GetCustomerIdByAccountIdQueryHandler>();
            services.AddSingleton<IQueryHandler<GetStatementQuery, IEnumerable<TransferDto>>, GetStatementQueryHandler>();
            services.AddSingleton<IQueryHandler<GetAvailableCustomerIdQuery, Guid>, GetAvailableCustomerIdQueryHandler> ();
            services.AddSingleton<IQueryHandler<GetCustomerIdByUsernameQuery, Maybe<Guid>>, GetCustomerIdByUsernameQueryHandler> ();
            services.AddSingleton<IQueryHandler<GetCustomerQuery, Maybe<CustomerDto>>, GetCustomerQueryHandler> ();
            services.AddSingleton<IQueryHandler<GetUsernameByCustomerIdQuery, Maybe<string>>, GetUsernameByCustomerIdQueryHandler> ();
            services.AddSingleton<IQueryHandler<IsUsernameAvailableQuery, bool>, IsUsernameAvailableQueryHandler> ();
            services.AddSingleton<IQueryHandler<LoginQuery, bool>, LoginQueryHandler> ();
            services.AddSingleton<IQueryHandler<GetAvailableAccountIdQuery, Guid>, GetAvailableAccountIdQueryHandler>();
            services.AddSingleton<IQueryHandler<GetDisposableAmountQuery, decimal>, GetDisposableAmountQueryHandler>();
            services.AddSingleton<IQueryHandler<HasAccountQuery, bool>, HasAccountQueryHandler>();
            services.AddSingleton<IQueryHandler<HasCustomerIdQuery, bool>, HasCustomerIdQueryHandler>();

            services.AddSingleton<ICommandHandler<OpenAccountCommand>, OpenAccountCommandHandler>();
            services.AddSingleton<ICommandHandler<TransferAmountCommand>, TransferMoneyCommandHandler>();
            services.AddSingleton<ICommandHandler<RegisterCustomerCommand>, RegisterCustomerCommandHandler> ();
            services.AddSingleton<ICommandHandler<SetCreditLimitForAccountIdCommand>, SetCreditLimitForAccountIdCommandHandler> ();

            services.AddSingleton<IEventObserver<CreditLimitChangedEvent>, CreditLimitChangedEventObserver> ();
            services.AddSingleton<IEventObserver<AmountTransferedEvent>, AmountTransferedEventObserver> ();
            services.AddSingleton<IEventObserver<AccountCreatedEvent>, AccountCreatedEventObserver> ();
            services.AddSingleton<IEventObserver<CustomerRegisteredEvent>, CustomerRegisteredEventObserver> ();

            services.AddSingleton<ITimeProvider, UtcTime>();
            services.AddSingleton<IAccountFacade, AccountFacade>();
            services.AddSingleton<ICustomerFacade, CustomerFacade>();
            services.AddSingleton<TransferDtoVisitorFactory>();
            services.AddSingleton<TransactionAdapterFactory>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

    }

    public class ApplicationUser
    {
    }
}
