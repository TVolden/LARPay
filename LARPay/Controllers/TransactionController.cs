using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using dk.lashout.LARPay.Web.Models;
using System.Collections.Generic;
using dk.lashout.LARPay.Core.Facades;

namespace dk.lashout.LARPay.Web.Controllers
{
    public class TransactionController : Controller
    {
        private readonly IAccounts _accounts;

        public TransactionController(IAccounts accounts)
        {
            _accounts = accounts;
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
            _accounts.Transfer(sender, model.Recipient, model.Amount, model.Description);

            return Ok();
        }

        [Authorize]
        public IActionResult Index()
        {
            var customer = getCurrentUser();
            return Json(_accounts.Balance(customer));
        }

        [Authorize]
        public IActionResult List()
        {
            var customer = getCurrentUser();
            var accountStatement = _accounts.Statement(customer);
            var transactions = new List<TransactionViewModel>();
            foreach(var trx in accountStatement)
            {
                var transaction = new TransactionViewModel()
                {
                    Amount = trx.Amount,
                    Description = trx.Description,
                    Recipient = trx.Linked.Identity,
                    Date = trx.Date
                };
                transactions.Add(transaction);
            }
            return Json(transactions.ToArray());
        }

        private string getCurrentUser()
        {
            ClaimsPrincipal principal = HttpContext.User;
            return principal.Identity.Name;
        }
    }
}