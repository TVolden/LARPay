using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using dk.lashout.LARPay.Core.Services;
using dk.lashout.LARPay.Core.Entities;
using dk.lashout.LARPay.Web.Models;
using System.Collections.Generic;

namespace dk.lashout.LARPay.Web.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IAccountService _accountService;

        public TransactionController(ICustomerService customerService, IAccountService accountService)
        {
            _customerService = customerService;
            _accountService = accountService;
        }

        public IActionResult Create()
        {
            var transaction = new TransactionViewModel
            {
                Amount = 0,
                Description = "Description",
                Recipient = "Recipient"
            };
            return Json(transaction);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(TransactionViewModel model)
        {
            var sender = getCurrentUser();
            var recipient = _customerService.GetCustomer(model.Recipient);
            _accountService.Transfer(sender, recipient, model.Amount, model.Description);

            return Ok();
        }

        [Authorize]
        public IActionResult Index()
        {
            var customer = getCurrentUser();
            return Json(_accountService.Balance(customer));
        }

        [Authorize]
        public IActionResult List()
        {
            var customer = getCurrentUser();
            var accountStatement = _accountService.Statement(customer);
            var transactions = new List<TransactionViewModel>();
            foreach(var trx in accountStatement)
            {
                var transaction = new TransactionViewModel()
                {
                    Amount = trx.Amount,
                    Description = trx.Description,
                    Recipient = trx.Linked.Identity
                };
                transactions.Add(transaction);
            }
            return Json(transactions.ToArray());
        }

        private Customer getCurrentUser()
        {
            ClaimsPrincipal principal = HttpContext.User;
            var user = principal.Identity.Name;
            return _customerService.GetCustomer(user);
        }
    }
}