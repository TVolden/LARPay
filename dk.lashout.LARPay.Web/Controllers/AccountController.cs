using dk.lashout.LARPay.Bank;
using dk.lashout.LARPay.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace dk.lashout.LARPay.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountFacade _accountFacade;

        public AccountController(AccountFacade accountFacade)
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
            try
            {
                _accountFacade.Transfer(sender, model.Recipient, model.Amount, model.Description);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

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
            try
            {
                _accountFacade.SetCreditLimit(customer, creditLimit);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        private string getCurrentUser()
        {
            ClaimsPrincipal principal = HttpContext.User;
            return principal.Identity.Name;
        }
    }
}
