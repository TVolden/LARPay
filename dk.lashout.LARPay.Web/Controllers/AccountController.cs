using dk.lashout.LARPay.Bank;
using dk.lashout.LARPay.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;

namespace dk.lashout.LARPay.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountFacade _accountFacade;

        public AccountController(IAccountFacade accountFacade)
        {
            _accountFacade = accountFacade ?? throw new System.ArgumentNullException(nameof(accountFacade));
        }

        public IActionResult Transfer()
        {
            var transaction = new TransferViewModel
            {
                Amount = 0,
                Description = "Description",
                Recipient = "Recipient"
            };
            return Json(transaction);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Transfer(TransferViewModel model)
        {
            var sender = getCurrentUser();
            var result = _accountFacade.Transfer(sender, model.Recipient, model.Amount, model.Description);

            if (!result.Success)
                return BadRequest(result.ErrorMessage);

            return Ok();
        }

        [Authorize]
        public IActionResult Balance()
        {
            var customer = getCurrentUser();
            return Json(_accountFacade.GetBalance(customer));
        }

        [Authorize]
        public IActionResult Statement()
        {
            var customer = getCurrentUser();
            var accountStatement = _accountFacade.GetStatement(customer);
            var transfers = new List<TransferViewModel>();
            foreach (var trx in accountStatement)
            {
                var transfer = new TransferViewModel()
                {
                    Amount = trx.Amount,
                    Description = trx.Description,
                    Recipient = trx.Recipient,
                    Date = trx.Date
                };
                transfers.Add(transfer);
            }
            return Json(transfers.ToArray());
        }

        [Authorize]
        public IActionResult CreditLimit()
        {
            var customer = getCurrentUser();
            return Json(_accountFacade.GetCreditLimit(customer));
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreditLimit(decimal creditLimit)
        {
            var customer = getCurrentUser();
            var result = _accountFacade.SetCreditLimit(customer, creditLimit);

            if (result.Success)
                return Ok();

            return BadRequest(result.ErrorMessage);
        }

        private string getCurrentUser()
        {
            ClaimsPrincipal principal = HttpContext.User;
            return principal.Identity.Name;
        }
    }
}
