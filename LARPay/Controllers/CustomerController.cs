using dk.lashout.LARPay.Core.Entities;
using dk.lashout.LARPay.Core.Services;
using dk.lashout.LARPay.Web.Models;
using dk.lashout.LARPay.Web.Results;
using Microsoft.AspNetCore.Mvc;

namespace dk.lashout.LARPay.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
           _customerService = customerService;
        }

        public ActionResult Create()
        {
            var returnValue = new Customer();
            returnValue.Name = "Full name";
            returnValue.Identity = "Login name";
            returnValue.Pincode = 0000;
            return Json(returnValue);
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            _customerService.Create(customer);
            return Created($"/customer/{customer.Identity}", customer);
        }

        public ActionResult Login()
        {
            var returnValue = new AuthenticateViewModel();
            returnValue.Identity = "Login name";
            returnValue.Pincode = 0000;
            return Json(returnValue);
        }

        [HttpPost]
        public ActionResult Login(AuthenticateViewModel model)
        {
            if (_customerService.Login(model.Identity, model.Pincode))
            {
                return Ok(model.Identity);

                /*
                string sec = "secret";
                var secKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(sec));
                var jwtHeader = new JwtHeader(new SigningCredentials(secKey, SecurityAlgorithms.HmacSha512));
                var jwtPayload = new JwtPayload("me", "me", new[] {new Claim("identity", model.Identity)}, DateTime.Now, DateTime.Now.AddHours(1));
                var tokenHandler = new JwtSecurityTokenHandler();

                 */
            }

            return new UnauthorizedWithChallengeResult("Bearer realm=\"jwt\"");
        }
       
    }
}