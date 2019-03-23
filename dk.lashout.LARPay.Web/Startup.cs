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
using dk.lashout.LARPay.EventArchive;
using dk.lashout.LARPay.EventArchive.Decorator;
using dk.lashout.MaybeType;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

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

            services.AddSingleton<IEventTypeIdentifier, EventTypeIdentifier>(provider => 
            new EventTypeIdentifier(
                typeof(AccountCreatedEvent),
                typeof(AmountTransferedEvent),
                typeof(CreditLimitChangedEvent),
                typeof(CustomerRegisteredEvent)
                ));
            services.AddSingleton<EventStorageFactory>();
            services.AddSingleton(provider => provider.GetService<EventStorageFactory>().Create(_configuration["EventStore:path"], _configuration["EventStore:file"]));

            services.AddQueryHandlers();
            services.AddCommandHandlers();
            services.AddEventObservers();

            services.AddSingleton<ITimeProvider, UtcTime>();
            services.AddSingleton<AccountFacade>();
            services.AddSingleton<CustomerFacade>();

            services.AddSingleton<TransferDtoVisitorFactory>();
            services.AddSingleton<TransactionAdapterFactory>();
            services.AddMvc()
                   .AddJsonOptions(options =>
                    {
                        options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                    });
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

            app.ApplicationServices.GetService<EventStorage>().ReplayEvents(DateTime.MinValue);

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
