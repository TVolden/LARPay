using dk.lashout.LARPay.Bank;
using Microsoft.AspNetCore.Mvc;

namespace dk.lashout.LARPay.API.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerFacade _facade;

        public CustomerController(CustomerFacade facade)
        {
            _facade = facade;
        }

        public ActionResult Register()
        {
            return Json(new CustomerViewModel("Character name", "Username", "0000"));
        }

        [HttpPost]
        public ActionResult Register(CustomerViewModel customer)
        {
            var result = _facade.CreateCustomer(customer.Username, customer.Name, customer.Pincode);

            return Created($"/credentials/{credentials.Identity}", credentials);
        }

    }
}
