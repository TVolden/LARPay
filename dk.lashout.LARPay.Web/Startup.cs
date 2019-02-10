using System;
using System.Text;
using dk.lashout.LARPay.Accounting;
using dk.lashout.LARPay.Accounting.Clerks;
using dk.lashout.LARPay.Accounting.Service;
using dk.lashout.LARPay.Archives;
using dk.lashout.LARPay.Bank;
using dk.lashout.LARPay.Clock;
using dk.lashout.LARPay.Customers;
using dk.lashout.LARPay.Customers.Clerks;
using dk.lashout.LARPay.Customers.Service;
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

            services.AddSingleton<ICustomerCreator, CustomerService>();
            services.AddSingleton<ILogin, CustomerService>();
            services.AddSingleton<IAccountGetter, CustomerService>();
            services.AddSingleton<ICustomerGetter, CustomerService>();
            services.AddSingleton<ITransfer, AccountService>();
            services.AddSingleton<IStatement, AccountService>();
            services.AddSingleton<IBalance, AccountService>();
            services.AddSingleton<IAccountCreator, AccountService>();
            services.AddSingleton<ITimeProvider, UtcTime>();
            services.AddSingleton<IAccountFacade, AccountFacade>();
            services.AddSingleton<ICustomerFacade, CustomerFacade>();
            services.AddSingleton<IAccountRepository, AccountArchive>();
            services.AddSingleton<ICustomerRepository, CustomerArchive>();
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
