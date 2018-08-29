using System.Security.Claims;
using dk.lashout.LARPay.Core.Services;
using dk.lashout.LARPay.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
            ClaimsPrincipal principal = HttpContext.User;

            var user = principal.Identity.Name;
            var sender = _customerService.GetCustomer(user);
            var recipient = _customerService.GetCustomer(model.Recipient);
            _accountService.Transfer(sender, recipient, model.Amount, model.Description);

            return Ok();
        }

        public IActionResult Index(string id)
        {
            var customer = _customerService.GetCustomer(id);
            return Json(_accountService.Balance(customer));
        }
    }
}