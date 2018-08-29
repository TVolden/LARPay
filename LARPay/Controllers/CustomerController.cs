using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using dk.lashout.LARPay.Core.Entities;
using dk.lashout.LARPay.Core.Services;
using dk.lashout.LARPay.Web.Models;
using dk.lashout.LARPay.Web.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace dk.lashout.LARPay.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IConfiguration _configuration;

        public CustomerController(ICustomerService customerService, IConfiguration configuration)
        {
            _customerService = customerService;
            _configuration = configuration;
        }

        public ActionResult Create()
        {
            var returnValue = new Credentials();
            returnValue.Name = "Full name";
            returnValue.Identity = "Login name";
            returnValue.Pincode = 0000;
            return Json(returnValue);
        }

        [HttpPost]
        public ActionResult Create(Credentials credentials)
        {
            _customerService.Create(credentials, credentials.Pincode);
            return Created($"/credentials/{credentials.Identity}", credentials);
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
                var symmetricKey = Encoding.UTF8.GetBytes(_configuration["jwt:SecretKey"]);

                var tokenHandler = new JwtSecurityTokenHandler();
                var now = DateTime.UtcNow;
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name, model.Identity)
                    }),
                    Issuer = _configuration["jwt:Issuer"],
                    Audience = _configuration["jwt:Audience"],
                    Expires = now.AddMinutes(Convert.ToInt32(20)),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return Ok(tokenHandler.WriteToken(token));
            }

            return new UnauthorizedWithChallengeResult("Bearer realm=\"jwt\"");
        }
       
    }
}